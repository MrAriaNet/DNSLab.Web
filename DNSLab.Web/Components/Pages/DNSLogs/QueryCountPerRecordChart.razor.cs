using ApexCharts;
using DNSLab.Web.DTOs.Repositories.DNSLog;
using DNSLab.Web.DTOs.Repositories.Record;
using DNSLab.Web.DTOs.Repositories.Zone;
using DNSLab.Web.Enums;
using DNSLab.Web.Interfaces.Repositories;
using Markdig.Extensions.TaskLists;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.DNSLogs;

partial class QueryCountPerRecordChart
{
    [Inject] public IDDNSRepository _DDNSRepository { get; set; }
    [Inject] IDNSLogRepository _DNSLogRepository { get; set; }
    IEnumerable<Tuple<ZoneDTO, IEnumerable<BaseRecordDTO>>>? _AllRecords { get; set; }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _AllRecords = await _DDNSRepository.GetDDNSDomainAndRecordsForToken();
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
        Stroke = new Stroke { Curve = Curve.Smooth, Width = new ApexCharts.Size(1) },
        Tooltip = new Tooltip
        {
            Theme = Mode.Dark
        },
        Chart = new Chart
        {
            Type = ApexCharts.ChartType.Line,
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
    Tuple<Guid, RecordTypeEnum>? _LastSelectedRecord = null;
    async Task RecordOnChanged(Tuple<Guid, RecordTypeEnum> record)
    {
        _IsLoading = true;
        _LastSelectedRecord = record;
        _Counts = await _DNSLogRepository.GetQueriesByRecordChart(record.Item1, record.Item2);
        _IsLoading = false;
    }

    async Task Refresh()
    {
        _IsLoading = true;
        _Counts = await _DNSLogRepository.GetQueriesByRecordChart(_LastSelectedRecord.Item1, _LastSelectedRecord.Item2);
        _IsLoading = false;
    }
}
