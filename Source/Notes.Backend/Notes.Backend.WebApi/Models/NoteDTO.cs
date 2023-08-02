namespace Notes.Backend.WebApi.Models
{
    public class NoteDTO
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
