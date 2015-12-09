using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Configuration;
using Configuration.Contracts;

namespace Mappings.CrossCutting
{
    public class ConfigurationMappings : IComponentMapping
    {
        public IEnumerable<Mapping> CreateComponentMappings()
        {
            return new[]
            {
                Map.From<IConfigurator>().To<Configurator>().AsSingleton()
            };
        }
    }
}
