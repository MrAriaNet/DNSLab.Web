namespace DNSLab.Web.Components.Pages.ReverseProxy;

partial class Download
{
    public enum OS
    {
        Windows,
        Linux,
    }

    OS _SelectedOs = OS.Windows;

    void ChangeOS(OS selectedOS)
    {
        _SelectedOs = selectedOS;
        StateHasChanged();
    }
}
