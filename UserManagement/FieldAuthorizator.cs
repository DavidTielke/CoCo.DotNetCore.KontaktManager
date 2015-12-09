using UserManagement.Contracts;

namespace UserManagement
{
    public class FieldAuthorizator : IFieldAuthorizator
    {
        public bool CanViewField<T>(string field) => field != "Lastname";

        public bool CanWriteField<T>(string field) => field != "Lastname";
    }
}