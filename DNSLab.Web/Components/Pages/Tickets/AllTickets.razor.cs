using DNSLab.Web.Components.Dialogs.Record;
using DNSLab.Web.Components.Dialogs.Ticket;
using DNSLab.Web.DTOs.Repositories.Record;
using DNSLab.Web.DTOs.Repositories.Ticket;
using DNSLab.Web.Enums;
using DNSLab.Web.Interfaces.Repositories;
using DNSLab.Web.Repositories;
using Microsoft.AspNetCore.Components;

namespace DNSLab.Web.Components.Pages.Tickets;

partial class AllTickets
{
    [Inject] ITicketRepository _TicketRepository { get; set; }
    [Inject] IDialogService _DialogService { get; set; }

    IEnumerable<TicketDTO>? _Tickets { get; set; }

    bool _IsLoading = true;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _IsLoading = true;

            _Tickets = await _TicketRepository.GetAllTickets();

            _IsLoading = false;
            await InvokeAsync(() => StateHasChanged());
        }
    }

    async Task OnStatusChanged(TicketDTO ticket, TicketStatusEnum status)
    {
        if (await _TicketRepository.ChangeTicketStatus(ticket.Id, status)) 
        {
            ticket.Status!.Id = (int)status;
        }
    }
}
