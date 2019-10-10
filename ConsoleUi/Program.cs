using Domain;
using DomainServices;
using MongoDbAdapter;

namespace ConsoleUi
{
    class Program
    {
        static void Main()
        {
            var bookService = new BookService(
                new MongoDbBookRepository(
                    "mongodb://localhost:27017/"),
                new NoBlacklistedUsersProvider());
            
            bookService.AddBook("War and Peace");
            bookService.BorrowBook("War and Peace", "John Doe");
        }
    }
}