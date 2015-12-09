using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Security;
using Security.Contracts;

namespace Mappings.Security
{
    public class SecurityMappings : IComponentMapping
    {
        public IEnumerable<Mapping> CreateComponentMappings()
        {
            return new[]
            {
                Map.From<IPersonManagerSecurity>().To<PersonManagerSecurity>().AsTransient(),
                Map.From<IPersonStatisticsSecurity>().To<PersonManagerSecurity>().AsTransient(),
            };
        }
    }
}
