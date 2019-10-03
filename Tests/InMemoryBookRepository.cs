using System.Collections.Generic;
using Domain;

namespace Tests
{
    public sealed class InMemoryBookRepository : IBookRepository
    {
        private readonly IDictionary<string, Book> _bookById = new Dictionary<string, Book>();

        public void Insert(Book book)
        {
            if (_bookById.ContainsKey(book.Name))
            {
                throw new BookAlreadyExistsException(book.Name);
            }
            
            _bookById[book.Name] = book;
        }

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