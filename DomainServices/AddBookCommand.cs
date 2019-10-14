

using Infrastructure;

namespace DomainServices
{
    public sealed class AddBookCommand : ICommand
    {
        public string Name { get; }

        public AddBookCommand(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}";
        }
    }
}