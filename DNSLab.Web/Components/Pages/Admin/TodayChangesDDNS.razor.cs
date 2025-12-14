using DNSLab.Web.Components.Dialogs.Record;
using DNSLab.Web.Components.Dialogs;
using DNSLab.Web.DTOs.Repositories.Record;
using DNSLab.Web.Interfaces.Repositories;
using DNSLab.Web.Repositories;
using Microsoft.AspNetCore.Components;
using DNSLab.Web.DTOs.Repositories.Zone;
using static MudBlazor.CategoryTypes;
using System.Net.Http;

namespace DNSLab.Web.Components.Pages.Admin
{
    partial class TodayChangesDDNS
    {
        [Inject] IDDNSRepository _DDNSRepository { get; set; }

        private async Task<GridData<BaseRecordDTO>> ServerReload(GridState<BaseRecordDTO> state)
        {
            IEnumerable<Tuple<ZoneDTO, IEnumerable<BaseRecordDTO>>>? data = await _DDNSRepository.GetTodayChangesDDNSDomainAndRecords();

            if (data is null)
            {
                return new GridData<BaseRecordDTO>();
            }

            var totalItems = data.SelectMany(x => x.Item2).Count();
            data.ToList().ForEach(x =>
            {
                x.Item2.ToList().ForEach(y =>
                {
                    y.Name = $"{y.Name}.{x.Item1.Name}";
                });
            });
            var pagedData = data.SelectMany(x => x.Item2).Skip(state.Page * state.PageSize).Take(state.PageSize).ToArray();

            return new GridData<BaseRecordDTO>
            {
                TotalItems = totalItems,
                Items = pagedData.AsEnumerable()
            };
        }
    }
}
