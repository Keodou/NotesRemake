using Microsoft.EntityFrameworkCore;
using Notes.Backend.Application.Interfaces;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Queries
{
    public class GetNotesQuery
    {
        private readonly INotesDbContext _context;

        public GetNotesQuery(INotesDbContext context)
        {
            _context = context;
        }

        public List<Note> Execute()
        {
            //return _context.Notes;
            return null;
        }
    }
}
