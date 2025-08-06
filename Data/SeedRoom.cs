using HelpDesk_Benedict.Models;

namespace HelpDesk_Benedict.Data
{
    public class SeedRoom
    {
        public static async Task SeedRoomsAsync(ApplicationDbContext context) {
            if(context.Rooms.Any()) {
                return;
            }
            var rooms = new List<Room> {
                new() { Name = "Atlas", Description = "Conference Room", Floor = "1.Stock" },
                new() { Name = "Genf", Description = "Meeting Room", Floor = "3.Stock" },
                new() { Name = "Monaco", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Stockholm", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Nassau", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Berlin", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Lissabon", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Paris", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Rom", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Ontario", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Tokyo", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Prag", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Wien", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Vaduz", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Prag", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "Madrid", Description = "Breakout Room", Floor = "3.Stock" },
                new() { Name = "SMS", Description = "Breakout Room", Floor = "4.Stock" },
                new() { Name = "Byte", Description = "Breakout Room", Floor = "4.Stock" },
                new() { Name = "USB", Description = "Breakout Room", Floor = "4.Stock" },
                new() { Name = "Pilatus", Description = "Breakout Room", Floor = "4.Stock" },
                new() { Name = "Sprachlabor", Description = "Breakout Room", Floor = "4.Stock" },

            };
            context.Rooms.AddRange(rooms);
            await context.SaveChangesAsync();
        }
    }
}
