namespace Domain
{
    public interface IBookRepository
    {
        void Insert(Book book);
        
        Book FindBy(string bookId);

        void Store(Book book);
    }
}