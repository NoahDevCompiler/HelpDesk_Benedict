using System.ComponentModel.DataAnnotations;

namespace HelpDesk_Benedict.Models
{
    public class TicketComment
    {
        public int Id { get; set; }

        [Required]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }

        [Required]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [Required]
        public CommentVisibility Visibility { get; set; }
    }
    public enum CommentVisibility
    {
        Public,
        Internal
    }
}
