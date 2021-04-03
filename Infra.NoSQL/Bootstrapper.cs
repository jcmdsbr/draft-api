using Core.Contracts;
using Core.Entities;
using Infra.NoSQL.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Infra.NoSQL
{
    public static class Bootstrapper
    {
        public static void AddRepositoryContext(this IServiceCollection services, IConfiguration configuration)
        {
            var mongoClientSettings =
                MongoClientSettings.FromConnectionString(configuration.GetConnectionString("DefaultConnection"));

            services.AddSingleton(mongoClientSettings);

            services.AddSingleton<IConventionPack>(new ConventionPack
            {
                new EnumRepresentationConvention(BsonType.String),
                new IgnoreExtraElementsConvention(true),
                new IgnoreIfNullConvention(true)
            });

            var client = new MongoClient(mongoClientSettings);
            services.AddSingleton<IMongoClient>(client);
            services.AddSingleton(client.GetDatabase("Sample").GetCollection<Product>(nameof(Product)));
            services.AddSingleton<IProductRepository, ProductRepository>();
        }
    }
}