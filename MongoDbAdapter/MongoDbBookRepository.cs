using System;
using Domain;
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

        public void Insert(Book book)
        {
            try
            {
                _bookCollection.InsertOne(book.ToDto());
            }
            catch (MongoWriteException)
            {
                throw new BookAlreadyExistsException(book.Name);
            }
        }

        public Book FindBy(string bookId) => 
            _bookCollection.Find(b => b.Name == bookId).FirstOrDefault()
                ?.ToDomainObject();

        private void Store(Book book)
        {
            _bookCollection.ReplaceOne(
                b => b.Name == book.Name, 
                book.ToDto(),
                new UpdateOptions { IsUpsert = true });
        }

        public void Transform(string bookName, Func<Book, Book> bookTransformer)
        {
            var book = FindBy(bookName);
            if (book == null)
            {
                throw new BookDoesntExistException(bookName);
            }
            
            Store(bookTransformer(book));
        }
    }
}