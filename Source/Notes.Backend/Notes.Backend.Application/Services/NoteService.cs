using AutoMapper;
using Notes.Backend.Application.Notes.Queries;
using Notes.Backend.Domain.Models;
using System.Runtime.CompilerServices;

namespace Notes.Backend.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly IMapper _mapper;
        private readonly GetNotesQueryHandler _queryHandler;

        public NoteService(IMapper mapper, GetNotesQueryHandler queryHandler)
        {
            _mapper = mapper;
            _queryHandler = queryHandler;
        }

        public async Task<List<GetNotesViewModel>> GetNotesAsync()
        {
            GetNotesQuery getNotesQuery = new();
            var notes = await _queryHandler.ExecuteAsync(getNotesQuery);
            var notesViewModel = _mapper.Map<List<GetNotesViewModel>>(notes);
            return notesViewModel;
        }
    }
}
