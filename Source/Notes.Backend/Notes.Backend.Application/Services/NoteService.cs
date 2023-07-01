﻿using Notes.Backend.Application.Notes.Commands.CreateNote;
using Notes.Backend.Application.Notes.Commands.UpdateNote;
using Notes.Backend.Application.Notes.Queries;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly GetNotesQueryHandler _getNotesQueryHandler;
        private readonly CreateNoteCommandHandler _createNoteCommandHandler;
        private readonly UpdateNoteCommandHandler _updateNoteCommandHandler;

        public NoteService(GetNotesQueryHandler getNotesQueryHandler, CreateNoteCommandHandler createNoteCommandHandler,
            UpdateNoteCommandHandler updateNoteCommandHandler)
        {
            _getNotesQueryHandler = getNotesQueryHandler;
            _createNoteCommandHandler = createNoteCommandHandler;
            _updateNoteCommandHandler = updateNoteCommandHandler;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            GetNotesQuery getNotesQuery = new();
            var notes = await _getNotesQueryHandler.ExecuteAsync(getNotesQuery);
            return notes;
        }

        public async Task<Guid> CreateNoteAsync(string name, string text)
        {
            CancellationToken cancellationToken = CancellationToken.None;
            CreateNoteCommand command = new()
            {
                Name = name,
                Text = text,
            };

            var noteId = await _createNoteCommandHandler.ExecuteAsync(command, cancellationToken);
            return noteId;
        }

        public async Task<Guid> UpdateNoteAsync(Guid id, string name, string text)
        {
            CancellationToken cancellationToken = CancellationToken.None;
            UpdateNoteCommand command = new()
            {
                Id = id,
                Name = name,
                Text = text
            };
            var noteId = await _updateNoteCommandHandler.ExecuteAsync(command, cancellationToken);
            return noteId;
        }
    }
}
