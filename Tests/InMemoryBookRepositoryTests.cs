using Domain;
using FluentAssertions;
using Xunit;
using static Tests.TestValues;

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
            _bookRepository.Store(TestValues.WarAndPeaceBorrowedToJohnDoe);

            _bookRepository.FindBy("War and Peace")
                .Should().BeEquivalentTo(WarAndPeaceBorrowedToJohnDoe);
        }

        [Fact]
        public void returns_latest_stored_object()
        {
            _bookRepository.Store(WarAndPeaceBorrowedToJohnDoe);
            
            _bookRepository.Store(UnborrowedWarAndPeace);
            
            _bookRepository.FindBy("War and Peace")
                .Should().BeEquivalentTo(UnborrowedWarAndPeace);
        }
    }
}