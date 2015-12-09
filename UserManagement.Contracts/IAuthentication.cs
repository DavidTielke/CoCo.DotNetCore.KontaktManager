namespace UserManagement.Contracts
{
    public interface IAuthentication
    {
        bool Validate(string username, string password);
    }
}