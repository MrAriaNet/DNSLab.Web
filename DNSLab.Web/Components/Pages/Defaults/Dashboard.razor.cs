using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Defaults;

partial class Dashboard
{
    [Inject] IStaticRepository _StaticRepository { get; set; }

    int? ZoneCount { get; set; }
    int? RecordsCount { get; set; }
    int? DDNSsCount { get; set; }

    protected override async Task OnInitializedAsync()
    {
        ZoneCount = await _StaticRepository.GetZonesCount();
        RecordsCount = await _StaticRepository.GetRecordsCount();
        DDNSsCount = await _StaticRepository.GetDDNSsCount();
    }
}
