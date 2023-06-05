using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Notes.Backend.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration["ServerConnection"];
            services.AddScoped<NotesDbContext>();
            services.AddTransient<GetNotesQuery>();
            return services;
        }
    }
}
