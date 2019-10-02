using Domain;

namespace MongoDbAdapter
{
    internal static class BookExtensions
    {
        public static BookDto ToDto(this Book book) => new BookDto
        {
            Name = book.Name,
            IsBorrowed = book.IsBorrowed,
            Borrower = book.Borrower
        };
    }
}