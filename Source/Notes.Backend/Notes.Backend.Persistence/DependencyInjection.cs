using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Backend.Application.Interfaces;
using Notes.Backend.Application.Notes.Queries;

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
            services.AddScoped<INotesDbContext>(provider =>
                provider.GetService<NotesDbContext>());
            return services;
        }
    }
}
