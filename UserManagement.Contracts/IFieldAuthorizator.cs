namespace UserManagement.Contracts
{
    public interface IFieldAuthorizator
    {
        bool CanViewField<T>(string field);

        bool CanWriteField<T>(string field);
    }
}