using MediatR;

namespace Notes.Backend.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
