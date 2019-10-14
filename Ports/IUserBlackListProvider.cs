namespace Ports
{
    public interface IUserBlackListProvider
    {
        bool IsInBlacklist(string userName);
    }
}