using Microsoft.AspNetCore.Mvc;
using Notes.Backend.Application.Services;
using Notes.Backend.Domain.Models;
using Notes.Backend.WebApi.Models;

namespace Notes.Backend.WebApi.Controllers
{
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

        [HttpGet]
        public async Task<ActionResult> GetNotes()
        {
            //string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var notes = await _noteService.GetNotesAsync();
            return Ok(notes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(Guid id)
        {
            var note = _noteService.GetNoteAsync(id);
            return Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(NoteDTO note)
        {
            var noteId = await _noteService.CreateNoteAsync(note.Name, note.Text);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateNoteDTO note)
        {
            var noteId = await _noteService.UpdateNoteAsync(note.NoteId, note.NoteName, note.NoteText);
            return Ok(noteId);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var noteId = await _noteService.DeleteNoteAsync(id);
            return Ok(noteId);
        }
    }
}
