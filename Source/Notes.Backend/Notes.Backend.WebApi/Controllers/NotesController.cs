using Microsoft.AspNetCore.Mvc;
using Notes.Backend.Application.Notes.Queries;
using Notes.Backend.Application.Services;

namespace Notes.Backend.WebApi.Controllers
{
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
            var notes = await _noteService.GetNotesAsync();
            return Ok(notes);
        }
    }
}
