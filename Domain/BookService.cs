namespace Domain
{
    public sealed class BookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(string bookId)
        {
            var book = new Book()
            {
                Name = bookId,
                IsBorrowed = false,
                Borrower = null
            };

            if (_bookRepository.FindBy(bookId) != null)
            {
                throw new BookAlreadyExistsException(bookId);
            }
            
            _bookRepository.Store(book);
        }
        
        public void BorrowBook(string bookId, string userId)
        {
            var book = _bookRepository.FindBy(bookId);
            if (book == null)
            {
                throw new BookDoesntExistException(bookId);
            }

            if (book.IsBorrowed)
            {
                throw new BookAlreadyBorrowedException(book);
            }

            book.IsBorrowed = true;
            book.Borrower = userId;

            _bookRepository.Store(book);
        }
    }
}