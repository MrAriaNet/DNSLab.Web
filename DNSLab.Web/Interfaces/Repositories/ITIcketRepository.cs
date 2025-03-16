using DNSLab.Web.DTOs.Repositories.Ticket;
using DNSLab.Web.Enums;

namespace DNSLab.Web.Interfaces.Repositories
{
    public interface ITicketRepository
    {
        Task<bool> AddTicket(TicketDTO model);
        Task<bool> DeleteTicket(Guid id);
        Task<bool> AddTicketMessage(TicketMessageDTO model);
        Task<bool> ChangeTicketStatus(Guid id, TicketStatusEnum status);
        Task<List<TicketDTO>?> GetAllTickets();
        Task<List<TicketDTO>?> GetMyTickets();
        Task<TicketDTO?> GetTicketMessages(Guid ticketId);
    }
}
