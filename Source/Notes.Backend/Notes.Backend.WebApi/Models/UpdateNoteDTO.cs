namespace Notes.Backend.WebApi.Models
{
    public class UpdateNoteDTO
    {
        public Guid UserId { get; set; }
        public Guid NoteId { get; set; }
        public string NoteName { get; set; } = string.Empty;
        public string NoteText { get; set; } = string.Empty;
    }
}
