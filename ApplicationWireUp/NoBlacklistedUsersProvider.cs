using Ports;

namespace ApplicationWireUp
{
    internal sealed class NoBlacklistedUsersProvider : IUserBlackListProvider
    {
        public bool IsInBlacklist(string userName) => false;
    }
}