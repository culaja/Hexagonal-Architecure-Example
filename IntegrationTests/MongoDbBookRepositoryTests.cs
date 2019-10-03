using System;
using Domain;
using FluentAssertions;
using Mongo2Go;
using MongoDbAdapter;
using Xunit;
using static Tests.TestValues;

namespace IntegrationTests
{
    public class MongoDbBookRepositoryTests : IDisposable
    {
        private readonly MongoDbRunner _mongoDbRunner = MongoDbRunner.Start();
        private readonly IBookRepository _bookRepository;

        public MongoDbBookRepositoryTests()
        {
            _bookRepository = new MongoDbBookRepository(_mongoDbRunner.ConnectionString);
        }
        
        public void Dispose()
        {
            _mongoDbRunner?.Dispose();
        }
        
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
                book => book.BorrowTo("John Doe"));

            _bookRepository.FindBy("War and Peace")
                .Should().BeEquivalentTo(WarAndPeaceBorrowedToJohnDoe);
        }
    }
}