namespace HelpDesk_Benedict.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Floor { get; set; }
        
        public ICollection<Ticket> Tickets { get; set; }
    }
}
