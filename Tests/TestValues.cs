using Domain;

namespace Tests
{
    public static class TestValues
    {
        public static Book UnborrowedWarAndPeace => Book.NewOf("War and Peace");
        public static Book WarAndPeaceBorrowedToJohnDoe => Book.NewOf("War and Peace")
            .BorrowTo("John Doe");
    }
}