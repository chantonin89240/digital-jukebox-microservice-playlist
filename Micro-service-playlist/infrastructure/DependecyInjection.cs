﻿using infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<PlaylistDbContext>((sp, options) =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped(provider => provider.GetRequiredService<PlaylistDbContext>());

            //services.AddScoped<IDomainEventService, DomainEventService>();

            //services.AddScoped<ApplicationDbContextInitialiser>();

            //var context = services.BuildServiceProvider().GetRequiredService<PlaylistDbContext>();
            //context.Database.Migrate();

            return services;
        }
    }
}
