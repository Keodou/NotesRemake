using Microsoft.EntityFrameworkCore;
using Notes.Backend.Application.Common.Exceptions;
using Notes.Backend.Application.Interfaces;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Notes.Queries.GetNote
{
    public class GetNoteQueryHandler
    {
        private readonly INotesDbContext _dbContext;

        public GetNoteQueryHandler(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Finds an object by ID from an incoming request
        /// </summary>
        /// <param name="query">Request to be executed</param>
        /// <returns>The found entity by ID</returns>
        public async Task<Note> ExecuteAsync(GetNoteQuery query)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == query.NoteId);

            if (entity != null)
                return entity;

            throw new NotFoundException("Note not found. Probably, there is no object with such an identifier in the database.");
        }
    }
}
