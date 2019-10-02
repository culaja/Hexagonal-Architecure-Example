using System;

namespace Domain
{
    public sealed class BookDoesntExistException : Exception
    {
        public BookDoesntExistException(string bookId)
            : base($"Book '{bookId}' doesn't exist.'")
        {
            
        }
    }
}