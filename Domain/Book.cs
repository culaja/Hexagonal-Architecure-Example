namespace Domain
{
    public sealed class Book
    {
        public string Name { get; set; }
        
        public bool IsBorrowed { get; set; }
        
        public string Borrower { get; set; }
    }
}