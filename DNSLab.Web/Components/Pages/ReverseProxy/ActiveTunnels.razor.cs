
using DNSLab.Web.DTOs.Repositories.ReeverseProxy;
using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.ReverseProxy;

partial class ActiveTunnels
{
    [Inject] IReverseProxyRepository ReverseProxyRepository { get; set; }

    IEnumerable<ReverseProxyTunnelDTO>? _Tunnels { get; set; }
    
    bool _Loading = true;
    protected override async Task OnInitializedAsync()
    {
        _Tunnels = await ReverseProxyRepository.GetActiveTunnels();

        _Loading = false;
    }
}
