using ApexCharts;
using DNSLab.Web.DTOs.Repositories.DNSLog;
using DNSLab.Web.DTOs.Repositories.Zone;
using DNSLab.Web.Interfaces.Repositories;
using Markdig.Extensions.TaskLists;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.DNSLogs;

partial class QueryCountChart
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
    private ApexChart<QueryCountDTO> _Chart;
    ApexChartOptions<QueryCountDTO> _LineOptions = new ApexChartOptions<QueryCountDTO>
    {
        Legend = new Legend
        {
            Position = LegendPosition.Bottom
        },
        Stroke = new Stroke { Curve = Curve.Smooth , Width = new ApexCharts.Size(1) },
        Tooltip =  new Tooltip
        {
           Theme = Mode.Dark
        },
        Grid = new Grid
        {
            Yaxis = new GridYAxis
            {
                Lines = new Lines
                {
                    Show = false ,
                }
            }
        },
        Chart = new Chart
        {
            Type = ApexCharts.ChartType.Bar,
            ForeColor = "var(--mud-palette-text-primary)",
            Background = "transparent",
            Toolbar = new Toolbar
            {
                Show = false,
            },
            Zoom = new Zoom
            {
                Enabled = false,
            },
            Height = "100%",
        },
    };

    IEnumerable<QueryCountDTO>? _Counts { get; set; }
    bool _IsLoading = false;
    Guid _LastSelectedZoneId = Guid.Empty;
    async Task ZoneOnChanged(ZoneDTO zone)
    {
        _IsLoading = true;
        _LastSelectedZoneId = zone.Id;
        _Counts = await _DNSLogRepository.GetQueriesChart(zone.Id);
        _IsLoading = false;
    }

    async Task Refresh()
    {
        _IsLoading = true;
        _Counts = await _DNSLogRepository.GetQueriesChart(_LastSelectedZoneId);
        _IsLoading = false;
    }
}
