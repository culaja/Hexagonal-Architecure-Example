namespace Domain
{
    public sealed class Book
    {
        // this should be private, but because of mapping with db object we need to expose it
        public Book(string name, bool isBorrowed, string borrower)
        {
            Name = name;
            IsBorrowed = isBorrowed;
            Borrower = borrower;
        }

        public static Book NewOf(string name) => new Book(
            name,
            false,
            null);

        public Book BorrowTo(string user)
        {
            if (IsBorrowed)
            {
                throw new BookAlreadyBorrowedException(this);
            }
            
            IsBorrowed = true;
            Borrower = user;

            return this;
        }
        
        public string Name { get; }
        
        public bool IsBorrowed { get; private set; }
        
        public string Borrower { get; private set; }
    }
}