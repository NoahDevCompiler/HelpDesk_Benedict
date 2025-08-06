using HelpDesk_Benedict.Data;
using HelpDesk_Benedict.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace HelpDesk_Benedict.Services
{
    public class TicketService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserDataService _userDataService;
        public TicketService(ApplicationDbContext context, UserDataService userDataService)
        {
            _context = context;
            _userDataService = userDataService;
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
                return await _context.Tickets.Where(t => t.UserId == userId).ToListAsync();
            } catch (Exception ex) {
                return null;
            }
        }
        public async Task<List<Ticket>> GetTicketsAsync() {
            try {
                return await _context.Tickets.Include(r => r.Room).ToListAsync();
            } catch (Exception ex) {
                return null;
            }
        }
        public async Task<List<Ticket>> GetRoomTicketsAsync(Room room) {
            try {
                return await _context.Tickets.Where(t => t.RoomId == room.Id).ToListAsync();
            } catch (Exception ex) {
                return null;
            }
        }

    }
}
