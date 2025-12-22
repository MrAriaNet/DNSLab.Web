using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace DNSLab.Web.Components.Custom;

partial class DarkModeSwitcher
{
    [Inject] public ProtectedLocalStorage _LocalStorage { get; set; }
    [Parameter] public bool IsDarkModeToggle { get; set; }
    [Parameter] public EventCallback<bool> IsDarkModeToggleChanged { get; set; }

    private async Task HandleToggleChanged(bool newValue)
    {
        await _LocalStorage.SetAsync("ThemeMode", newValue);
        IsDarkModeToggle = newValue;
        await IsDarkModeToggleChanged.InvokeAsync(newValue);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var data = await _LocalStorage.GetAsync<bool>("ThemeMode");
            if (data.Success)
            {
                await HandleToggleChanged(data.Value);
                IsDarkModeToggle = data.Value;
            }
        }
    }
}
