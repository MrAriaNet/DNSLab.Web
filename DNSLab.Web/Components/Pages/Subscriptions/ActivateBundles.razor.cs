using DNSLab.Web.DTOs.Repositories.Bundle;
using DNSLab.Web.Helpers;
using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Subscriptions;

partial class ActivateBundles
{
    [Inject] IBudleRepository _SubscriptionRepository { get; set; }
    [Inject] ISnackbar _Snackbar { get; set; }
    [Inject] NavigationManager _NavigationManager { get; set; }

    IEnumerable<FeatureSectionDTO>? _FeatureSections { get; set; }
    IEnumerable<BundleDurationDTO>? _BundleDurations { get; set; }

    protected override async Task OnInitializedAsync()
    {
        _FeatureSections = await _SubscriptionRepository.GetFeatures();
        _BundleDurations = await _SubscriptionRepository.GetBundleDurations();
    }


    void ToggleFeatureChanged(FeatureDTO feature, bool value)
    {
        if (value)
        {
            _ActiveBundle.Features.Add(new ActiveFeatureDTO { Id = feature.Id });
        }
        else
        {
            var exist = _ActiveBundle.Features.FirstOrDefault(x => x.Id == feature.Id);

            if (exist != null)
            {
                _ActiveBundle.Features.Remove(exist);
            }
        }
    }

    void CountableFeatureChanged(FeatureDTO feature, int count)
    {
        var exist = _ActiveBundle.Features.FirstOrDefault(x => x.Id == feature.Id);

        if (exist != null)
        {
            if (feature.Pricing != null && feature.Pricing.FreeCount != null && feature.Pricing.FreeCount >= count)
            {
                _ActiveBundle.Features.Remove(exist);
            }
            else
            {
                exist.RequestCount = count;
            }
        }
        else
        {
            _ActiveBundle.Features.Add(new ActiveFeatureDTO { Id = feature.Id, RequestCount = count });
        }
    }

    long CalculatePrice()
    {
        long total = 0;

        var features = _FeatureSections!.SelectMany(x => x.Features);
        foreach (var feature in _ActiveBundle.Features)
        {
            var existFeature = features.FirstOrDefault(x => x.Id == feature.Id);
            if (existFeature != null)
            {
                switch (existFeature.Type)
                {
                    case Enums.FeatureTypeEnum.Countable:
                        total += (long)((feature.RequestCount - existFeature.Pricing.FreeCount) * existFeature.Pricing.UnitPrice ?? 0);
                        break;
                    case Enums.FeatureTypeEnum.Toggle:
                        total += (long)(existFeature.Pricing.ActivationPrice ?? 0);
                        break;
                    default:
                        break;
                }
            }
        }

        if (_BundleDuration != null)
        {
            total *= _BundleDuration.Duration;

            if (_BundleDuration.Discount.Percent > 0)
            {
                total = total - (total * _BundleDuration.Discount.Percent / 100);
            }
        }
        return total;
    }

    ActiveBundleDTO _ActiveBundle { get; set; } = new ActiveBundleDTO { Features = new List<ActiveFeatureDTO>() };

    BundleDurationDTO? _BundleDuration { get; set; }

    void SelectDuration(BundleDurationDTO selectedDuration)
    {
        _BundleDuration = selectedDuration;
    }

    async Task Activate()
    {
        if (_BundleDuration != null)
        {

            _ActiveBundle.DurationId = _BundleDuration.Id;

            if (await _SubscriptionRepository.Activate(_ActiveBundle))
            {
                _Snackbar.Add($"به مدت {_BundleDuration.Description} برای شما فعال شد", Severity.Success);
                _NavigationManager.NavigateTo(AllRoutes.Dashboard);
            }
        }
    }
}
