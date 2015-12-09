using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataStoring.EF;

using Bremacon.CorePersonManager.Data.DataStoring.Contracts;

namespace Mappings.Data
{
    public class DataStoringMappings : IComponentMapping
    {
        public IEnumerable<Mapping> CreateComponentMappings()
        {
            return new[]
            {
                Map.From<IPersonRepository>().To<PersonRepository>().AsTransient()
            };
        }
    }
}
