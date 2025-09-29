
using DNSLab.Web.Components.Dialogs;
using DNSLab.Web.Components.Dialogs.Zone;
using DNSLab.Web.DTOs.Repositories.Zone;
using DNSLab.Web.Interfaces.Repositories;
using DNSLab.Web.Repositories;
using Microsoft.AspNetCore.Components;
using MudBlazor.Charts;
using static MudBlazor.CategoryTypes;

namespace DNSLab.Web.Components.Pages.Zone
{
    partial class AllZones
    {
        [Inject] IZoneRepository _ZoneRepository { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] ISubscriptionRepository _SubscriptionRepository { get; set; }

        IEnumerable<ZoneDTO>? _Zones { get; set; }
        bool _IsLoading = false;
        bool? _IsSubscribeThisFeature { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            _IsSubscribeThisFeature = await _SubscriptionRepository.CheckSbscriptionFeature(Enums.FeatureEnum.PrivateZone);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _IsLoading = true;

                _Zones = await _ZoneRepository.GetZones();

                _IsLoading = false;
                await InvokeAsync(() => StateHasChanged());
            }
        }

        Task Refresh()
        {
            return OnAfterRenderAsync(true);
        }

        async Task NewZone()
        {
            var options = new DialogOptions() { CloseButton = true, FullWidth = true, MaxWidth = MaxWidth.Small };

            var dialog = await _DialogService.ShowAsync<AddZoneDialog>("اضافه کردن دامنه جدید", options);
            var result = await dialog.Result;
            if (!result!.Canceled)
            {
                await Refresh();
            }
        }

        async Task DeleteZone(ZoneDTO zone)
        {
            var parameters = new DialogParameters<BaseDialog>
            {
                { x => x.ContentText, $"شما در حال حذف {zone.Name} میباشید آیا تایید میکنید؟" },
                { x => x.ButtonText, "حذف" },
                { x => x.Color, Color.Error }
            };

            var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

            var dialog = await _DialogService.ShowAsync<BaseDialog>("حذف", parameters, options);
            var result = await dialog.Result;
            if (!result!.Canceled)
            {
                if (await _ZoneRepository.DeleteZone(zone.Id))
                {
                    await Refresh();
                }
            }
        }

        async Task DisableZone(ZoneDTO zone)
        {
            bool _continue = true;

            if (zone.Disable == false)
            {
                var parameters = new DialogParameters<BaseDialog>
                {
                    { x => x.ContentText, $"شما در حال غیر فعال سازی {zone.Name} میباشید آیا تایید میکنید؟" },
                    { x => x.ButtonText, "غیر فعال" },
                    { x => x.Color, Color.Warning }
                };

                var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

                var dialog = await _DialogService.ShowAsync<BaseDialog>("غیر فعال سازی", parameters, options);
                var result = await dialog.Result;

                if (result!.Canceled)
                {
                    _continue = false;
                }
            }

            if (_continue && await _ZoneRepository.DisableZone(zone.Id))
            {
                zone.Disable = !zone.Disable;
            }
        }
    }
}
