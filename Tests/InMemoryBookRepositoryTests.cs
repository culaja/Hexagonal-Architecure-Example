using Domain;
using FluentAssertions;
using Ports;
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
        public void adds_new_book_if_book_is_not_in_the_repository()
        {
            _bookRepository.Insert(UnborrowedWarAndPeace);
            
            _bookRepository.FindBy("War and Peace")
                .Should().BeEquivalentTo(UnborrowedWarAndPeace);
        }

        [Fact]
        public void throws_book_already_exists_exception()
        {
            _bookRepository.Insert(UnborrowedWarAndPeace);
            
            _bookRepository.Invoking(br => br.Insert(UnborrowedWarAndPeace))
                .Should().Throw<BookAlreadyExistsException>()
                .WithMessage($"Book 'War and Peace' already exists.");
        }

        [Fact]
        public void transform_throws_exception_if_book_doesnt_exist()
        {
            _bookRepository.Invoking(br => br.Transform("War and Peace", _ => _))
                .Should().Throw<BookDoesntExistException>();
        }

        [Fact]
        public void if_book_exists_it_is_transformed()
        {
            _bookRepository.Insert(UnborrowedWarAndPeace);
            
            _bookRepository.Transform(
                "War and Peace",
                book => WarAndPeaceBorrowedToJohnDoe);

            _bookRepository.FindBy("War and Peace")
                .Should().BeEquivalentTo(WarAndPeaceBorrowedToJohnDoe);
        }
    }
}
