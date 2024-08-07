﻿using Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace Catalog.Infrastructure.Data
{
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<Product> typeCollection)
        {
            bool checkTypes = typeCollection.Find(b => true).Any();
            string path = Path.Combine("Data", "SeedData", "types.json");
            if (!checkTypes)
            {
                var typeData = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<Product>>(typeData);
                if (types != null)
                {
                    foreach (var type in types)
                    {
                        typeCollection.InsertOneAsync(type);
                    }
                }

            }
        }


    }
}