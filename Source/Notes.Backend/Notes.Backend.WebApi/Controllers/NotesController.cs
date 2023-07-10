﻿using Microsoft.AspNetCore.Mvc;
using Notes.Backend.Application.Services;
using Notes.Backend.Domain.Models;
using Notes.Backend.WebApi.Models;

namespace Notes.Backend.WebApi.Controllers
{
    /// <summary>
    /// Conroller for a notes.
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        /// <summary>
        /// Returns a list of all notes.
        /// </summary>
        /// <returns>Presentation with notes.</returns>
        [HttpGet]
        public async Task<ActionResult> GetNotes()
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var notes = await _noteService.GetNotesAsync();
            return Ok(notes);
        }

        /// <summary>
        /// Returns a note by ID.
        /// </summary>
        /// <param name="id">ID of the note you are looking for.</param>
        /// <returns>Presentation with note.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(Guid id)
        {
            var note = await _noteService.GetNoteAsync(id);
            return Ok(note);
        }

        /// <summary>
        /// Creating a new note.
        /// </summary>
        /// <param name="note">The completed data model.</param>
        /// <returns>ID of the created note.</returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create(NoteDTO note)
        {
            var noteId = await _noteService.CreateNoteAsync(note.Name, note.Text);
            return Ok(noteId);
        }

        /// <summary>
        /// Updating a note.
        /// </summary>
        /// <param name="note">The completed data model.</param>
        /// <returns>ID of the updated note.</returns>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateNoteDTO note)
        {
            var noteId = await _noteService.UpdateNoteAsync(note.NoteId, note.NoteName, note.NoteText);
            return Ok(noteId);
        }

        /// <summary>
        /// Deleting a note.
        /// </summary>
        /// <param name="id">ID of the note you are looking for.</param>
        /// <returns>ID of the deleted note.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var noteId = await _noteService.DeleteNoteAsync(id);
            return Ok(noteId);
        }
    }
}
