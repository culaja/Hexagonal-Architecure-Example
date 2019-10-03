namespace Domain
{
    public interface IUserBlackListProvider
    {
        bool IsInBlacklist(string userName);
    }
}