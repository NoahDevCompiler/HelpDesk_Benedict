using HelpDesk_Benedict.Data;
using HelpDesk_Benedict.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HelpDesk_Benedict.Services
{
    public class TicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserDataService _userDataService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public TicketService(ApplicationDbContext context, UserDataService userDataService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userDataService = userDataService;
            _httpContextAccessor = httpContextAccessor;
        }   

        public async Task CreateTicketAsync(Ticket ticket)
        {
            try {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw;
            }
        }
        public async Task<List<Ticket>> GetClientTicketsAsync() {
            string userId = await _userDataService.GetUserIdAsync();

            if (string.IsNullOrEmpty(userId)) {
                return [];
            }

            try {
                return await _context.Tickets.Where(t => t.UserId == userId).Include(t => t.TicketComments).ToListAsync();
            } catch (Exception ex) {
                return null;
            }
        }
        public async Task<List<Ticket>> GetTicketsAsync() {
            try {
                return await _context.Tickets.Include(r => r.Room).Include(t => t.TicketComments).ToListAsync();
            } catch (Exception ex) {
                return null;
            }
        }
        public async Task<List<Ticket>> GetRoomTicketsAsync(Room room) {
            try {
                return await _context.Tickets.Where(t => t.RoomId == room.Id).Include(t => t.TicketComments).ToListAsync();
            } catch (Exception ex) {
                return null;
            }
        }
        public async Task ChangeStatus(Ticket ticket, TicketStatus status) {
            var user = _httpContextAccessor.HttpContext.User;
            var currentUser = await _userDataService.GetCurrentUserAsync();

            bool isOwner = ticket.User == currentUser;
            bool isPrivileged = user.IsInRole("Admin") || user.IsInRole("Support");

            if (!isOwner ||!isPrivileged) {
                throw new UnauthorizedAccessException("You do not have permission to change the status of this ticket.");
            }

            await _context.Tickets.Where(t => t.Id == ticket.Id)
                .ExecuteUpdateAsync(t => t.SetProperty(t => t.Status, status));
        }
    }
}
