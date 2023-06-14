using Notes.Backend.Application.Notes.Queries;

namespace Notes.Backend.Application.Services
{
    public interface INoteService
    {
        Task<List<GetNotesViewModel>> GetNotesAsync();
    }
}
