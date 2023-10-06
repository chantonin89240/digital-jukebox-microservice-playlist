using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PlaylistDbContext>((options) =>
            {
                options.UseSqlServer(connectionString);
            });

            //services.AddScoped<IDomainEventService, DomainEventService>();

            //services.AddScoped<ApplicationDbContextInitialiser>();

            //var context = services.BuildServiceProvider().GetRequiredService<PlaylistDbContext>();
            //context.Database.Migrate();

            return services;
        }
    }
}
