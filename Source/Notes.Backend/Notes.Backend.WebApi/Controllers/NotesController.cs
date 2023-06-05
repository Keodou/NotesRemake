using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notes.Backend.Application.Queries;

namespace Notes.Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetNotes()
        {
            return Ok();
        }
    }
}
