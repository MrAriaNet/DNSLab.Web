using DNSLab.Web.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MudBlazor;

namespace DNSLab.Web.Components.Custom;

partial class DarkModeSwitcher
{
    [Inject] public ProtectedLocalStorage _LocalStorage { get; set; }
    [Parameter] public DarkModeEnum DarkMode { get; set; }
    [Parameter] public EventCallback<DarkModeEnum> DarkModeChanged { get; set; }

    private async Task HandleToggleChanged(DarkModeEnum newValue)
    {
        await _LocalStorage.SetAsync("DarkMode", newValue);
        DarkMode = newValue;
        await DarkModeChanged.InvokeAsync(newValue);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var data = await _LocalStorage.GetAsync<DarkModeEnum>("DarkMode");
            if (data.Success)
            {
                await HandleToggleChanged(data.Value);
                DarkMode = data.Value;
            }
            else
            {
                await HandleToggleChanged(DarkModeEnum.Auto);
                DarkMode = DarkModeEnum.Auto;
            }
        }
    }
}