namespace HelpDesk_Benedict.Models.DTO
{
    public class TicketCommentDTO
    {
        public static TicketCommentDTO ToDto(TicketComment comment) {
            return new TicketCommentDTO {
                TicketId = comment.TicketId,
                Message = comment.Message,
                UserId = comment.UserId,
                Visibility = comment.Visibility,
                Timestamp = comment.Timestamp
            };
        }
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; } 
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public CommentVisibility Visibility { get; set; }

    }
}
