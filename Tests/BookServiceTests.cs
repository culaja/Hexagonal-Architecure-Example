using Domain;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class BookServiceTests
    {
        private readonly IBookRepository _bookRepository = new InMemoryBookRepository();
        private readonly BookService _bookService;

        public BookServiceTests()
        {
            _bookService = new BookService(_bookRepository);
        }

        [Fact]
        public void book_doesnt_exist_exception_thrown_when_borrowing_unknown_book()
        {
            _bookService.AddBook("War and Peace");

            _bookService.Invoking(s => s.BorrowBook("Lord of the Rings", "John Doe"))
                .Should()
                .Throw<BookDoesntExistException>()
                .WithMessage($"Book 'Lord of the Rings' doesn't exist.'");
        }

        [Fact]
        public void book_can_be_borrowed_to_user_if_exists_and_if_is_not_borrowed()
        {
           _bookService.AddBook("War and Peace");
            
            _bookService.BorrowBook("War and Peace", "John Doe");
            
            var book = _bookRepository.FindBy("War and Peace");
            book.IsBorrowed.Should().BeTrue();
            book.Borrower.Should().Be("John Doe");
        }

        [Fact]
        public void book_cant_be_borrower_if_already_borrower()
        {
            _bookService.AddBook("War and Peace");
            _bookService.BorrowBook("War and Peace", "John Doe");
            
            _bookService.Invoking(s => s.BorrowBook("War and Peace", "Jane Doe"))
                .Should()
                .Throw<BookAlreadyBorrowedException>()
                .WithMessage($"Book 'War and Peace' is already borrowed to 'John Doe'.");
        }
    }
}