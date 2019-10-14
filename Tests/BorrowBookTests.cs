using Domain;
using FluentAssertions;
using Xunit;
using static Tests.TestValues;

namespace Tests
{
    public class BorrowBookTests
    {
        [Fact]
        public void book_can_be_borrowed_to_user_if_exists_and_if_is_not_borrowed()
        {
            var book = CreateUnBorrowedWarAndPeace();
                
            book.BorrowTo("John Doe", _ => false);
            
            book.IsBorrowed.Should().BeTrue();
            book.Borrower.Should().Be("John Doe");
        }

        [Fact]
        public void book_cant_be_borrower_if_already_borrowed()
        {
            var book = CreateUnBorrowedWarAndPeace();
            book.BorrowTo("John Doe", _ => false);
            
            book.Invoking(s => s.BorrowTo("John Doe", _ => false))
                .Should()
                .Throw<BookAlreadyBorrowedException>()
                .WithMessage($"Book 'War and Peace' is already borrowed to 'John Doe'.");
        }

        [Fact]
        public void book_cant_be_borrower_if_user_is_blacklisted()
        {
            var book = CreateUnBorrowedWarAndPeace();
            
            book.Invoking(b => b.BorrowTo("John Doe", user => user == "John Doe"))
                .Should().Throw<UserBlacklistedException>();
        }
    }
}