using MediatR;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Notes.Queries.GetNote
{
    public class GetNoteQuery : IRequest<Note>
    {
        public Guid NoteId { get; set; }
    }
}
