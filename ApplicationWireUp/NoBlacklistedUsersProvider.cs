using Domain;

namespace ConsoleUi
{
    internal sealed class NoBlacklistedUsersProvider : IUserBlackListProvider
    {
        public bool IsInBlacklist(string userName) => false;
    }
}