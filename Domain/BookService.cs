using MongoDB.Driver;

namespace Domain
{
    public sealed class BookService
    {
        private readonly IMongoCollection<Book> _bookCollection;
        
        public BookService(string databaseConnectionString)
        {
            var mongoClient = new MongoClient(databaseConnectionString);
            _bookCollection = mongoClient.GetDatabase("Library").GetCollection<Book>(nameof(Book));
        }

        public void AddBook(string bookId)
        {
            var book = new Book()
            {
                Id = bookId,
                IsBorrowed = false,
                Borrower = null
            };
            
            _bookCollection.InsertOne(book);
        }
        
        public void BorrowBook(string bookId, string userId)
        {
            var book = _bookCollection.Find(b => b.Id == bookId).FirstOrDefault();
            if (book == null)
            {
                throw new BookDoesntExistException(bookId);
            }

            if (book.IsBorrowed)
            {
                throw new BookAlreadyBorrowedException(book);
            }

            book.IsBorrowed = true;
            book.Borrower = userId;

            _bookCollection.ReplaceOne(b => b.Id == bookId, book);
        }
    }
}