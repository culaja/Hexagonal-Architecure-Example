using System;
using Domain;

namespace Ports
{
    public interface IBookRepository
    {
        void Insert(Book book);
        
        Book FindBy(string bookId);

        void Transform(string bookName, Func<Book, Book> bookTransformer);
    }
}