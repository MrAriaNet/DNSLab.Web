using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Tools;

partial class Ping
{
    [Inject] IToolRepository _ToolRepository { get; set; }

    string _Host;

    string? _Result { get; set; }
    async Task CalcPing()
    {
        _Result = await _ToolRepository.Ping(_Host);
    }
}
