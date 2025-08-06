using HelpDesk_Benedict.Data;
using HelpDesk_Benedict.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace HelpDesk_Benedict.Services
{
    public class RoomService
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }   

        public async Task<List<Room>> GetRoomAsync() {
            if (_context.Rooms.Any())
            {
                return await _context.Rooms.ToListAsync();
            }
            else
            {
                throw new InvalidOperationException("No rooms available in the database.");
            }
        }
    }
}
