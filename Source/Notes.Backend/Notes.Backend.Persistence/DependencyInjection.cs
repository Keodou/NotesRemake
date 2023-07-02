using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Backend.Application.Interfaces;
using Notes.Backend.Application.Notes.Commands.CreateNote;
using Notes.Backend.Application.Notes.Commands.DeleteNote;
using Notes.Backend.Application.Notes.Commands.UpdateNote;
using Notes.Backend.Application.Notes.Queries.GetNote;
using Notes.Backend.Application.Notes.Queries.GetNotes;
using Notes.Backend.Application.Services;

namespace Notes.Backend.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("LocalConnection");
            services.AddDbContext<NotesDbContext>(options =>
            options.UseSqlServer(connectionString)
            );
            services.AddTransient<GetNotesQueryHandler>();
            services.AddTransient<GetNoteQueryHandler>();
            services.AddTransient<CreateNoteCommandHandler>();
            services.AddTransient<UpdateNoteCommandHandler>();
            services.AddTransient<DeleteNoteCommandHandler>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<INotesDbContext>(provider =>
                provider.GetService<NotesDbContext>());
            return services;
        }
    }
}
