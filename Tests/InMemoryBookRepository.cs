using System.Collections.Generic;
using Domain;

namespace Tests
{
    public sealed class InMemoryBookRepository : IBookRepository
    {
        private readonly IDictionary<string, Book> _bookById = new Dictionary<string, Book>();
        
        public Book FindBy(string bookId)
        {
            _bookById.TryGetValue(bookId, out var book);
            return book;
        }

        public void Store(Book book)
        {
            _bookById[book.Name] = book;
        }
    }
}