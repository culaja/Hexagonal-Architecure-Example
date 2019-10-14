using Domain;
using Infrastructure;
using Ports;

namespace DomainServices
{
    public sealed class BorrowBookCommandHandler : ICommandHandler<BorrowBookCommand>
    {
        private readonly IBookRepository _repository;
        private readonly IUserBlackListProvider _userBlackListProvider;

        public BorrowBookCommandHandler(
            IBookRepository repository,
            IUserBlackListProvider userBlackListProvider)
        {
            _repository = repository;
            _userBlackListProvider = userBlackListProvider;
        }

        public void Execute(BorrowBookCommand command) =>
            _repository.Transform(command.BookName, b =>
                b.BorrowTo(command.Borrower, _userBlackListProvider.IsInBlacklist));
    }
}