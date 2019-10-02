namespace Domain
{
    public interface IBookRepository
    {
        Book FindBy(string bookId);

        void Store(Book book);
    }
}