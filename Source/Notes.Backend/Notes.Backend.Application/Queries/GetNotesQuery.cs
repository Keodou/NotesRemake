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

        public async Task<List<Note>> ExecuteAsync()
        {
            return await _context.Notes.ToListAsync();
        }
    }
}
