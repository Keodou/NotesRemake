using Microsoft.AspNetCore.Mvc;
using Notes.Backend.Application.Queries;

namespace Notes.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly GetNotesQuery _getNotesQuery;

        public NotesController(GetNotesQuery query)
        {
            _getNotesQuery = query;
        }

        [HttpGet]
        public async Task<ActionResult> GetNotes()
        {
            var notes = await _getNotesQuery.ExecuteAsync();
            return Ok(notes);
        }
    }
}
