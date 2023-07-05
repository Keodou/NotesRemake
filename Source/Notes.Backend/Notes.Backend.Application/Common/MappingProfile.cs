using AutoMapper;
using Notes.Backend.Application.Notes.Commands.CreateNote;
using Notes.Backend.Domain.Models;

namespace Notes.Backend.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Note, CreateNoteCommand>();
        }
    }
}
