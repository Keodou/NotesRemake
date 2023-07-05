namespace Notes.Backend.WebApi.Models
{
    public class UpdateNoteDTO
    {
        public Guid NoteId { get; set; }
        public string NoteName { get; set; }
        public string NoteText { get; set; }
    }
}
