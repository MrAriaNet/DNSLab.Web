using DNSLab.Web.DTOs.Repositories.Record;
using DNSLab.Web.Interfaces.Repositories;
using DNSLab.Web.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Records;

partial class RecordChangesHistory
{
    [Inject] IRecordRepository _RecordRepository { get; set; }
    [Inject] ISubscriptionRepository _SubscriptionRepository { get; set; }

    [Parameter] public Guid RecordId { get; set; }

    IEnumerable<RecordChangeDTO>? _RecordChanges { get; set; }
    bool? _IsSubscribeThisFeature { get; set; } = null;

    bool _Loading = true;
    protected override async Task OnInitializedAsync()
    {
        _IsSubscribeThisFeature = await _SubscriptionRepository.CheckSbscriptionFeature(Enums.FeatureEnum.RecordChangesHistory);

        if (_IsSubscribeThisFeature is not null && _IsSubscribeThisFeature == true)
        {
            _RecordChanges = await _RecordRepository.GetRecordChangesHistory(RecordId);
        }
        _Loading = false;
    }


}
