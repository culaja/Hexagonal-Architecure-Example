using Domain;
using FluentAssertions;
using Xunit;

namespace Tests
{
    public class InMemoryBookRepositoryTests
    {
        private readonly IBookRepository _bookRepository = new InMemoryBookRepository();
        
        [Fact]
        public void returns_null_if_book_doesnt_exist()
        {
            _bookRepository.FindBy("War and Peace")
                .Should().BeNull();
        }

        [Fact]
        public void returns_exact_object_if_exists()
        {
            _bookRepository.Store(new Book
            {
                Name = "War and Peace",
                IsBorrowed = true,
                Borrower = "John Doe"
            });
            
            _bookRepository.FindBy("War and Peace")
                .Should().BeEquivalentTo(new Book
                {
                    Name = "War and Peace",
                    IsBorrowed = true,
                    Borrower = "John Doe"
                });
        }

        [Fact]
        public void returns_latest_stored_object()
        {
            _bookRepository.Store(new Book
            {
                Name = "War and Peace",
                IsBorrowed = true,
                Borrower = "John Doe"
            });
            
            _bookRepository.Store(new Book
            {
                Name = "War and Peace",
                IsBorrowed = false,
                Borrower = null
            });
            
            _bookRepository.FindBy("War and Peace")
                .Should().BeEquivalentTo(new Book
                {
                    Name = "War and Peace",
                    IsBorrowed = false,
                    Borrower = null
                });
        }
    }
}