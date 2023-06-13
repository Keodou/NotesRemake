using Microsoft.EntityFrameworkCore;
using Notes.Backend.Application.Interfaces;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Notes.Queries
{
    public class GetNotesQueryHandler
    {
        private readonly INotesDbContext _dbContext;

        public GetNotesQueryHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Returns all notes from the database.
        /// </summary>
        /// <param name="query"></param>
        /// <returns>All notes</returns>
        public async Task<List<Note>> ExecuteAsync(GetNotesQuery query)
        {
            return await _dbContext.Notes.ToListAsync();
        }
    }
}
