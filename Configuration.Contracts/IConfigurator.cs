namespace Configuration.Contracts
{
    public interface IConfigurator
    {
        T Get<T>(string area, string key);

        void Set(string area, string key, object value, bool persist);
    }
}