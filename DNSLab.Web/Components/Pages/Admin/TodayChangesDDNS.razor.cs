using DNSLab.Web.Components.Dialogs.Record;
using DNSLab.Web.Components.Dialogs;
using DNSLab.Web.DTOs.Repositories.Record;
using DNSLab.Web.Interfaces.Repositories;
using DNSLab.Web.Repositories;
using Microsoft.AspNetCore.Components;
using DNSLab.Web.DTOs.Repositories.Zone;

namespace DNSLab.Web.Components.Pages.Admin
{
    partial class TodayChangesDDNS
    {
        [Inject] IDDNSRepository _DDNSRepository { get; set; }
        [Inject] IRecordRepository _RecordRepository { get; set; }
        [Inject] IDialogService _DialogService { get; set; }
        [Inject] ISnackbar _Snackbar { get; set; }

        IEnumerable<Tuple<ZoneDTO, IEnumerable<BaseRecordDTO>>>? _AllRecords { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _AllRecords = await _DDNSRepository.GetTodayChangesDDNSDomainAndRecords();
        }
    }
}
