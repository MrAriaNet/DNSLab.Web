using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Tools;

partial class PortChecker
{
    [Inject] IToolRepository _ToolRepository { get; set; }

    string _Host;
    int _Port = 80;

    bool? _Result { get; set; }
    async Task CalcPing()
    {
        _Result = null;
        _Result = await _ToolRepository.IsPortOpen(_Host, _Port);
    }
}
