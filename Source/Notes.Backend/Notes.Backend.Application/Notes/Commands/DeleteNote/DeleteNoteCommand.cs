using MediatR;

namespace Notes.Backend.Application.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest<Guid>
    {
        public Guid NoteId { get; set; }
    }
}
