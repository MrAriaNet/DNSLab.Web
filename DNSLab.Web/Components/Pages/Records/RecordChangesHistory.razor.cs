using DNSLab.Web.DTOs.Repositories.Record;
using DNSLab.Web.Interfaces.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Records;

partial class RecordChangesHistory
{
    [Inject] IRecordRepository _RecordRepository { get; set; }

    [Parameter] public Guid RecordId { get; set; }

    IEnumerable<RecordChangeDTO>? _RecordChanges {  get; set; }

    bool _Loading = true;
    protected override async Task OnInitializedAsync()
    {
        _RecordChanges = await _RecordRepository.GetRecordChangesHistory(RecordId);
        _Loading = false;
    }
}
