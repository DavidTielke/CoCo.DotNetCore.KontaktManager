using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UserManagement;
using UserManagement.Contracts;

namespace Mappings.Logic
{
    public class UserManagementMappings : IComponentMapping
    {
        public IEnumerable<Mapping> CreateComponentMappings() => new[]
        {
            Map.From<IFieldAuthorizator>().To<FieldAuthorizator>().AsTransient()
        };
    }
}
