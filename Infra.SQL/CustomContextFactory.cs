using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infra.SQL
{
    public class CustomContextFactory : IDesignTimeDbContextFactory<CustomContext>
    {
        private readonly IConfiguration _configuration;

        public CustomContextFactory()
        {   
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CustomerApi" ))
                .AddJsonFile("appsettings.json")
                .Build();
        }
        
        public CustomContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CustomContext>();
            builder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            return new CustomContext(builder.Options);
        }
    }
}