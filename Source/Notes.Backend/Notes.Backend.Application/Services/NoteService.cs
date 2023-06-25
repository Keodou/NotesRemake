using Notes.Backend.Application.Notes.Commands.CreateNote;
using Notes.Backend.Application.Notes.Queries;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly GetNotesQueryHandler _queryHandler;
        private CreateNoteCommandHandler _createNoteCommandHandler;

        public NoteService(GetNotesQueryHandler queryHandler, CreateNoteCommandHandler createNoteCommandHandler)
        {
            _queryHandler = queryHandler;
            _createNoteCommandHandler = createNoteCommandHandler;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            GetNotesQuery getNotesQuery = new();
            var notes = await _queryHandler.ExecuteAsync(getNotesQuery);
            return notes;
        }

        public async Task<Guid> CreateNoteAsync(string name, string text)
        {
            CreateNoteCommand command = new()
            {
                Name = name,
                Text = text,
            };

            var noteId = await _createNoteCommandHandler.ExecuteAsync(command);
            return noteId;
        }
    }
}
