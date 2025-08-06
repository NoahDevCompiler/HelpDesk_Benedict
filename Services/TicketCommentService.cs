using HelpDesk_Benedict.Data;
using HelpDesk_Benedict.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk_Benedict.Services
{
    public class TicketCommentService
    {
        private readonly ApplicationDbContext _dbContext;
        public TicketCommentService( ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddCommentAsync(TicketComment comment)
        {
            _dbContext.TicketComments.Add(comment);
            await _dbContext.SaveChangesAsync();
        }
    }
}
