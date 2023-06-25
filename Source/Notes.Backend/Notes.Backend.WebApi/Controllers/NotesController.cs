using Microsoft.AspNetCore.Mvc;
using Notes.Backend.Application.Services;
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

        public async Task<ActionResult<Guid>> Create(NoteDTO note)
        {
            var NoteId = await _noteService.CreateNoteAsync(note.Name, note.Text);
            return Ok(NoteId);
        }
    }
}
