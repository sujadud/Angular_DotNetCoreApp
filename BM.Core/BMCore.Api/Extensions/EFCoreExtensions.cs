﻿using BMCore.Database.DatabaseContexts;
using Microsoft.EntityFrameworkCore;

namespace BMCore.Api.Extensions
{
    public static class EFCoreExtensions
    {
        public static IServiceCollection InjectDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Add database connection string
            services.AddDbContext<DatabaseContext>(option => option.UseSqlServer(configuration.GetConnectionString("Default")));

            return services;
        }
    }
}