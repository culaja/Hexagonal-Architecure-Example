using Domain;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbAdapter
{
    internal sealed class BookDto
    {
        [BsonId]
        public string Name { get; set; }
        
        public bool IsBorrowed { get; set; }
        
        public string Borrower { get; set; }

        public Book ToDomainObject() => new Book
        {
            Name = Name,
            IsBorrowed = IsBorrowed,
            Borrower = Borrower
        };
    }
}