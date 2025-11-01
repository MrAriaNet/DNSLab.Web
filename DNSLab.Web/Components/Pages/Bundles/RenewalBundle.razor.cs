
using DNSLab.Web.Components.Dialogs;
using DNSLab.Web.DTOs.Repositories.Bundle;
using DNSLab.Web.Helpers;
using DNSLab.Web.Interfaces.Repositories;
using DNSLab.Web.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Bundles;

partial class RenewalBundle
{
    [Inject] IBudleRepository _SubscriptionsRepository { get; set; }
    [Inject] IDialogService _DialogService { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; }

    IEnumerable<UserBundleDTO>? _UserBundles;
    bool _Loading = false;
    protected override async Task OnInitializedAsync()
    {
        _Loading = true;
        _UserBundles = await _SubscriptionsRepository.GetExpiringBundles();
        _Loading = false;
    }

    async Task Renewal(UserBundleDTO userBundle)
    {
        var parameters = new DialogParameters<BaseDialog>
            {
                { x => x.ContentText, $"شما در حال تمدید اشتراک به مبلغ {CalculatePrice(userBundle)} ریال میباشید در صورت اطمینان تایید کنید" },
                { x => x.ButtonText, "تایید" },
                { x => x.Color, Color.Success }
            };

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Small };

        var dialog = await _DialogService.ShowAsync<BaseDialog>("تایید", parameters, options);
        var result = await dialog.Result;
        if (!result!.Canceled)
        {
            if (await _SubscriptionsRepository.RenewalBundle(userBundle.Id))
            {
                _NavigationManager.NavigateTo(AllRoutes.MyBundles);
            }
        }
    }

    long CalculatePrice(UserBundleDTO userBundle)
    {
        long total = 0;

        var features = userBundle.Bundle.Features.Select(x => x.Feature);
        foreach (var requestFeature in userBundle.Bundle.Features)
        {
            var existFeature = features.FirstOrDefault(x => x.Id == requestFeature.Feature.Id);
            if (existFeature != null)
            {
                switch (existFeature.Type)
                {
                    case Enums.FeatureTypeEnum.Countable:
                        total += (long)((requestFeature.Count - existFeature.Pricing.FreeCount) * existFeature.Pricing.UnitPrice ?? 0);
                        break;
                    case Enums.FeatureTypeEnum.Toggle:
                        total += (long)(existFeature.Pricing.ActivationPrice ?? 0);
                        break;
                    default:
                        break;
                }
            }
        }

        total *= userBundle.Duration.Duration;


        if (userBundle.Duration.Discount != null && userBundle.Duration.Discount.Percent > 0)
        {
            total = total - (total * userBundle.Duration.Discount.Percent / 100);
        }

        return total;
    }
}
