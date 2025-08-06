using System.ComponentModel.DataAnnotations;

namespace HelpDesk_Benedict.Models
{
    public enum TicketStatus
    {
        Open,
        InProgress,
        Completed,
        Closed
    }

    public enum TicketPriority
    {
        Low,
        Medium,
        High,
        Urgent
    }

    public enum TicketCategory
    {
        Hardware,
        Software,
        Network,
        Other
    }
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [Required]
        public TicketStatus Status { get; set; }
        [Required]
        public TicketPriority Priority { get; set; }
        public TicketCategory Category { get; set; }
        // Foreign key for ApplicationUser
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        // Foreign key for Room
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public ICollection<TicketComment> TicketComments { get; set; }
    }
   

}
