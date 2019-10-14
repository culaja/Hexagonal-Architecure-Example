using Domain;

namespace Tests
{
    public static class TestValues
    {
        public static Book CreateUnBorrowedWarAndPeace() => Book.NewOf("War and Peace");
        public static Book WarAndPeaceBorrowedToJohnDoe => Book.NewOf("War and Peace")
            .BorrowTo("John Doe", _ => false);

        public const string BlacklistedUser = nameof(BlacklistedUser);
    }
}