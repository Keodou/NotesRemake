using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Services
{
    public interface INoteService
    {
        Task<List<Note>> GetNotesAsync();
        Task<Guid> CreateNoteAsync(string name, string text);
    }
}
