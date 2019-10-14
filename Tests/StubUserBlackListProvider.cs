using Domain;
using Ports;
using static Tests.TestValues;

namespace Tests
{
    public sealed class StubUserBlackListProvider : IUserBlackListProvider
    {
        public bool IsInBlacklist(string userName)
        {
            switch (userName)
            {
                case BlacklistedUser:
                    return true;
                default:
                    return false;
            }
        }
    }
}