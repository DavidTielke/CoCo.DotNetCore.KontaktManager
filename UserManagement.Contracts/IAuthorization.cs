namespace UserManagement.Contracts
{
    public interface IAuthorization
    {
        bool HasFlag(string username, string flag);
    }
}