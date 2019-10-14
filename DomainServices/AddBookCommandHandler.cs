using Domain;
using Infrastructure;
using Ports;

namespace DomainServices
{
    public sealed class AddBookCommandHandler : ICommandHandler<AddBookCommand>
    {
        private readonly IBookRepository _repository;

        public AddBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        
        public void Execute(AddBookCommand command) =>
            _repository.Insert(Book.NewOf(command.Name));
    }
}