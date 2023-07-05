using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Services
{
    public interface INoteService
    {
        Task<List<Note>> GetNotesAsync();
        Task<Note> GetNoteAsync(Guid id);
        Task<Guid> CreateNoteAsync(string name, string text);
        Task<Guid> UpdateNoteAsync(Guid id, string name, string text);
        Task<Guid> DeleteNoteAsync(Guid id);
    }
}
