using System;

namespace Ports
{
    public sealed class BookAlreadyExistsException : Exception
    {
        public BookAlreadyExistsException(string bookId)
            : base($"Book '{bookId}' already exists.")
        {
        }
    }
}