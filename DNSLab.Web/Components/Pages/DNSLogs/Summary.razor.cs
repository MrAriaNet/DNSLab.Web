using ApexCharts;
using DNSLab.Web.DTOs.Repositories.DNSLog;
using DNSLab.Web.DTOs.Repositories.Record;
using DNSLab.Web.DTOs.Repositories.Zone;
using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.DNSLogs;

partial class Summary
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

    long? _TotalRequests { get; set; } = null;
    IEnumerable<TimeAndCountDTO>? _TimeAndCounts { get; set; }
    bool _IsLoading = false;
    string _LastSelectedQName = String.Empty;
    async Task QueryOnChange(string? qName = null)
    {
        _IsLoading = true;
        if (String.IsNullOrEmpty(qName))
        {
            qName = _LastSelectedQName;
        }
        _LastSelectedQName = qName;
        _TotalRequests = await _DNSLogRepository.GetTotalRequest(qName);
        _TimeAndCounts = await _DNSLogRepository.GetTotalRequestChartByTime(qName);
        _IsLoading = false;
    }

    private ApexChart<TimeAndCountDTO> _Chart;
    ApexChartOptions<TimeAndCountDTO> _LineOptions = new ApexChartOptions<TimeAndCountDTO>
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
        Grid = new Grid
        {
            Yaxis = new GridYAxis
            {
                Lines = new Lines
                {
                    Show = false,
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

}
