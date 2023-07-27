using MediatR;

namespace Notes.Backend.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid NoteId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
