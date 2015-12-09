using System.Collections.Generic;

using Bremacon.CorePersonManager.Logic.PersonManagement;
using Bremacon.CorePersonManager.Logic.PersonManagement.Contracts;

namespace Mappings.Logic
{
    public class PersonManagementMappings : IComponentMapping
    {
        public IEnumerable<Mapping> CreateComponentMappings()
        {
            return new[]
            {
                Map.From<IPersonManager>().To<PersonManager>().AsTransient(),
                Map.From<IPersonStatistics>().To<PersonManager>().AsTransient(),
            };
        }
    }
}