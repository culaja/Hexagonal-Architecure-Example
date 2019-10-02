﻿using Domain;
using MongoDB.Driver;

namespace MongoDbAdapter
{
    public sealed class MongoDbBookRepository : IBookRepository
    {
        private readonly IMongoCollection<BookDto> _bookCollection;
        
        public MongoDbBookRepository(string databaseConnectionString)
        {
            var mongoClient = new MongoClient(databaseConnectionString);
            _bookCollection = mongoClient.GetDatabase("Library").GetCollection<BookDto>(nameof(Book));
        }
        
        public Book FindBy(string bookId) => 
            _bookCollection.Find(b => b.Name == bookId).FirstOrDefault()
                ?.ToDomainObject();

        public void Store(Book book)
        {
            _bookCollection.ReplaceOne(
                b => b.Name == book.Name, 
                book.ToDto(),
                new UpdateOptions { IsUpsert = true });
        }
    }
}