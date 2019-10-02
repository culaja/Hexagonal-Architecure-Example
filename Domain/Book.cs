using MongoDB.Bson.Serialization.Attributes;

namespace Domain
{
    public sealed class Book
    {
        [BsonId]
        public string Id { get; set; }
        
        public bool IsBorrowed { get; set; }
        
        public string Borrower { get; set; }
    }
}