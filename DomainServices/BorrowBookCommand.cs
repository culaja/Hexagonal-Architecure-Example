using Infrastructure;

namespace DomainServices
{
    public sealed class BorrowBookCommand : ICommand
    {
        public string BookName { get; }
        public string Borrower { get; }

        public BorrowBookCommand(
            string bookName,
            string borrower)
        {
            BookName = bookName;
            Borrower = borrower;
        }

        public override string ToString()
        {
            return $"{nameof(BookName)}: {BookName}, {nameof(Borrower)}: {Borrower}";
        }
    }
}