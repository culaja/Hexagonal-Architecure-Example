using System;

namespace Domain
{
    public sealed class BookAlreadyExistsException : Exception
    {
        public BookAlreadyExistsException(string bookId)
            : base($"Book '{bookId}' already exists.")
        {
        }
    }
}