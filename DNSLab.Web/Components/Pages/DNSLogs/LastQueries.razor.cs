using DNSLab.Web.DTOs.Repositories.DNSLog;
using DNSLab.Web.DTOs.Repositories.Zone;
using DNSLab.Web.Interfaces.Repositories;
using Markdig.Extensions.TaskLists;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.DNSLogs;

partial class LastQueries
{
    [Inject] IZoneRepository _ZoneRepository { get; set; }
    [Inject] IDNSLogRepository _DNSLogRepository { get; set; }
    IEnumerable<ZoneDTO>? _Zones { get; set; }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _Zones = await _ZoneRepository.GetZones();
            await InvokeAsync(() => StateHasChanged());
        }
    }

    IEnumerable<QueryLogDTO>? _Logs { get; set; }
    bool _IsLoading = false;
    Guid _LastSelectedZoneId = Guid.Empty;
    async Task ZoneOnChanged(ZoneDTO zone)
    {
        _IsLoading = true;
        _LastSelectedZoneId = zone.Id;
        _Logs = await _DNSLogRepository.GetLastQueries(zone.Id);
        _IsLoading = false;
    }

    async Task Refresh()
    {
        _IsLoading = true;
        _Logs = await _DNSLogRepository.GetLastQueries(_LastSelectedZoneId);
        _IsLoading = false;
    }
}
