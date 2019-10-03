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
            _bookRepository.Store(Book.NewOf(bookId));

        public void BorrowBook(string bookId, string userId)
        {
            var book = _bookRepository.FindBy(bookId);
            if (book == null)
            {
                throw new BookDoesntExistException(bookId);
            }
            
            book.BorrowTo(userId);

            _bookRepository.Store(book);
        }
    }
}