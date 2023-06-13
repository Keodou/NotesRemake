using Notes.Backend.Application.Notes.Queries;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly GetNotesQueryHandler _queryHandler;

        public NoteService(GetNotesQueryHandler queryHandler)
        {
            _queryHandler = queryHandler;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            GetNotesQuery getNotesQuery = new();
            return await _queryHandler.ExecuteAsync(getNotesQuery);
        }
    }
}
