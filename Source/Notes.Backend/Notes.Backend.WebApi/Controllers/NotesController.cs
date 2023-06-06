using Microsoft.AspNetCore.Mvc;
using Notes.Backend.Application.Queries;

namespace Notes.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly GetNotesQuery _query;

        public NotesController(GetNotesQuery query)
        {
            _query = query;
        }

        [HttpGet]
        public ActionResult GetNotes()
        {
            var notes = _query.Execute();
            return Ok(notes);
        }
    }
}
