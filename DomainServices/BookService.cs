using Domain;
using Ports;

namespace DomainServices
{
    public sealed class BookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserBlackListProvider _userBlackListProvider;

        public BookService(
            IBookRepository bookRepository,
            IUserBlackListProvider userBlackListProvider)
        {
            _bookRepository = bookRepository;
            _userBlackListProvider = userBlackListProvider;
        }

        public void AddBook(string bookId) => 
            _bookRepository.Insert(Book.NewOf(bookId));

        public void BorrowBook(string bookId, string userId) =>
            _bookRepository.Transform(
                bookId,
                book => book.BorrowTo(
                    userId,
                    _userBlackListProvider.IsInBlacklist));
    }
}