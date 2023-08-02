using MediatR;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Notes.Queries.GetNotes
{
    public class GetNotesQuery : IRequest<List<Note>>
    {
        public Guid UserId { get; set; }
    }
}
