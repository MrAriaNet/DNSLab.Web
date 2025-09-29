using DNSLab.Web.Components.Dialogs;
using DNSLab.Web.Interfaces.Repositories;
using DNSLab.Web.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.ReverseProxy;

partial class ReverseProxy
{
    [Inject] IReverseProxyRepository _ReverseProxyRepository { get; set; }
    [Inject] IDialogService _DialogService { get; set; }

    string _Token = "XXXXXXX-XX-XXXXXXXX";

    protected override async Task OnInitializedAsync()
    {
        _Token = await _ReverseProxyRepository.GetClientToken() ?? String.Empty;
    }

    async Task RevokeClientToken()
    {
        var parameters = new DialogParameters<BaseDialog>
            {
                { x => x.ContentText, $"شما در حال تغییر کلید {_Token} میباشید آیا تایید میکنید؟" },
                { x => x.ButtonText, "تفییر کلید" },
                { x => x.Color, Color.Warning }
            };

        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };

        var dialog = await _DialogService.ShowAsync<BaseDialog>("تغییر کلید", parameters, options);
        var result = await dialog.Result;
        if (!result!.Canceled)
        {
            _Token = await _ReverseProxyRepository.RevokeClientToken() ?? String.Empty;
        }
    }
}
