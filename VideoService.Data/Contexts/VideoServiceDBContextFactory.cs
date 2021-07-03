using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VideoService.DB.Migrations.Contexts
{
    /// <summary>
    /// Required for migration.
    /// </summary>
    public class VideoServiceDBContextFactory : IDesignTimeDbContextFactory<VideoServiceDbContext>
    {
        public VideoServiceDbContext CreateDbContext(string[] args)
        {
            // Get environment
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Build config
            IConfigurationRoot configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("migration.json")
                .AddEnvironmentVariables()
                .Build();

            string connectionString = configurationBuilder.GetConnectionString(nameof(DbContext));

            DbContextOptionsBuilder<VideoServiceDbContext> builder =
                new DbContextOptionsBuilder<VideoServiceDbContext>();
            builder.UseSqlServer(
                connectionString,
                x =>
                    x.MigrationsHistoryTable(
                        "__MigrationsHistory",
                        VideoServiceDbContext.SCHEMA));

            return new VideoServiceDbContext(builder.Options);
        }
    }
}