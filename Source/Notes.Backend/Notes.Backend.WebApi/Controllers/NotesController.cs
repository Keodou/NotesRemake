using Microsoft.AspNetCore.Mvc;
using Notes.Backend.Application.Notes.Queries;

namespace Notes.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly GetNotesQueryHandler _getNotesQueryHandler;

        public NotesController(GetNotesQueryHandler getNotesQueryHandler)
        {
            _getNotesQueryHandler = getNotesQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult> GetNotes()
        {
            GetNotesQuery query = new();
            var notes = await _getNotesQueryHandler.ExecuteAsync(query);
            return Ok(notes);
        }
    }
}
