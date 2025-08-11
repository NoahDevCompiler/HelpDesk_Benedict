using HelpDesk_Benedict.Models.DTO;
using Microsoft.AspNetCore.SignalR;

namespace HelpDesk_Benedict.Services
{
    public class TicketCommentHub : Hub
    {
        public async Task SendComment(TicketCommentDTO comment)
        {

            if (Clients != null) {
                await Clients.All.SendAsync("ReceiveComment", comment);
            }
        }
    }
}
