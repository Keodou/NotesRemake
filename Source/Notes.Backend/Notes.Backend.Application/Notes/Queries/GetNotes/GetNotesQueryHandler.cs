using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Backend.Application.Interfaces;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Notes.Queries.GetNotes
{
    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, List<Note>>
    {
        private readonly INotesDbContext _dbContext;

        public GetNotesQueryHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Execute query for returns all notes from the database.
        /// </summary>
        /// <param name="query">Request to be executed.</param>
        /// <returns>All notes.</returns>
        public async Task<List<Note>> Handle(GetNotesQuery query, CancellationToken cancellationToken)
        {
            return await _dbContext.Notes
                .Where(note => note.UserId == query.UserId)
                .ToListAsync(cancellationToken);
        }
    }
}
