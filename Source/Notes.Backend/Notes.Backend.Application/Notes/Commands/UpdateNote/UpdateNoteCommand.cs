namespace Notes.Backend.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
