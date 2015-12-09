using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Mappings.CrossCutting;
using Mappings.Data;
using Mappings.Logic;
using Mappings.Security;

namespace Mappings
{
    public static class Aggregator
    {
        public static IEnumerable<Mapping> Mappings =>
            new ComponentMappings()
                .AddMappingsFor<DataStoringMappings>()
                .AddMappingsFor<PersonManagementMappings>()
                .AddMappingsFor<SecurityMappings>()
                .AddMappingsFor<ConfigurationMappings>()
            .AddMappingsFor<UserManagementMappings>();

    }
}
