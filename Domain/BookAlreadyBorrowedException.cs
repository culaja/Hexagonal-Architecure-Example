using System;

namespace Domain
{
    public sealed class BookAlreadyBorrowedException : Exception
    {
        public BookAlreadyBorrowedException(Book book)
            : base($"Book '{book.Id}' is already borrowed to '{book.Borrower}'.")
        {
        }
    }
}