using DomainServices;
using Infrastructure;
using MongoDbAdapter;

namespace ApplicationWireUp
{
    public sealed class ApplicationContainer : ICommandHandler<AddBookCommand>, ICommandHandler<BorrowBookCommand>
    {
        private readonly AddBookCommandHandler _addBookCommandHandler;
        private readonly BorrowBookCommandHandler _borrowBookCommandHandler;

        private ApplicationContainer(
            AddBookCommandHandler addBookCommandHandler,
            BorrowBookCommandHandler borrowBookCommandHandler)
        {
            _addBookCommandHandler = addBookCommandHandler;
            _borrowBookCommandHandler = borrowBookCommandHandler;
        }

        public static ApplicationContainer BuildUsing(string mongoDbConnectionString)
        {
            var mongoDbRepository = new MongoDbBookRepository(mongoDbConnectionString);
            var noBlacklistedUsersProvider = new NoBlacklistedUsersProvider();
            
            return new ApplicationContainer(
                new AddBookCommandHandler(mongoDbRepository),
                new BorrowBookCommandHandler(mongoDbRepository, noBlacklistedUsersProvider));
        }

        public void Execute(AddBookCommand command) => _addBookCommandHandler.Execute(command);

        public void Execute(BorrowBookCommand command) => _borrowBookCommandHandler.Execute(command);
    }
}