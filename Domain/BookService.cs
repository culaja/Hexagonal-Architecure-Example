namespace Domain
{
    public sealed class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(string bookId) => 
            _bookRepository.Insert(Book.NewOf(bookId));

        public void BorrowBook(string bookId, string userId)
        {
            _bookRepository.Transform(
                bookId,
                book => book.BorrowTo(userId));
        }
    }
}