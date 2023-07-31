using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Notes.Backend.Identity
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddNotesIdentity(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAuthentication().AddJwtBearer();
            return services;
        }
    }
}