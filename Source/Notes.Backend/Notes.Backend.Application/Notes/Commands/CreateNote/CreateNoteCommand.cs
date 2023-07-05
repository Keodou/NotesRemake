namespace Notes.Backend.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand
    {
        public Guid NoteId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
