using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Backend.Application.Notes.Commands.CreateNote;
using Notes.Backend.Application.Notes.Commands.DeleteNote;
using Notes.Backend.Application.Notes.Commands.UpdateNote;
using Notes.Backend.Application.Notes.Queries.GetNote;
using Notes.Backend.Application.Notes.Queries.GetNotes;
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
        private readonly IMediator _mediator;

        public NotesController(IMediator mediator, INoteService noteService)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns a list of all notes.
        /// </summary>
        /// <returns>Presentation with notes.</returns>
        [HttpGet]
        public async Task<ActionResult> GetNotes()
        {
            var notes = await _mediator.Send(new GetNotesQuery());
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
            var note = await _mediator.Send(new GetNoteQuery() { NoteId = id });
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
            CreateNoteCommand command = new()
            {
                Name = note.Name,
                Text = note.Text,
            };
            var noteId = await _mediator.Send(command);
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
            UpdateNoteCommand command = new()
            {
                Id = note.NoteId,
                Name = note.NoteName,
                Text = note.NoteText
            };
            var noteId = await _mediator.Send(command);
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
            DeleteNoteCommand command = new()
            {
                NoteId = id
            };
            var noteId = await _mediator.Send(command);
            return Ok(noteId);
        }
    }
}
