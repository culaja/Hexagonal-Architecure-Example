using ApplicationWireUp;
using DomainServices;

namespace ConsoleUi
{
    internal class Program
    {
        static void Main()
        {
            var applicationContainer = ApplicationContainer.BuildUsing("mongodb://localhost:27017/");
            
            applicationContainer.Execute(new AddBookCommand("War and Peace"));
            applicationContainer.Execute(new BorrowBookCommand("War and Peace", "John Doe"));
        }
    }
}