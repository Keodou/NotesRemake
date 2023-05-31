namespace Notes.Backend.Domain.Models
{
    public class UserNote
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid NoteId { get; set; }
    }
}
