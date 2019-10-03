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
        public void returns_exact_object_if_exists()
        {
            _bookRepository.Store(WarAndPeaceBorrowedToJohnDoe);
            
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