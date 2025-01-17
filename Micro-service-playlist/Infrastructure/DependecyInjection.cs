﻿using Infrastructure.Data;
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

            services.AddScoped<PlaylistDbContextInitialiser>();

            var context = services.BuildServiceProvider().GetRequiredService<PlaylistDbContext>();
            context.Database.MigrateAsync();

            return services;
        }
    }
}
