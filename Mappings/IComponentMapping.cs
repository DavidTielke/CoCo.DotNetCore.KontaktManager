using System.Collections.Generic;

namespace Mappings
{
    public interface IComponentMapping
    {
        IEnumerable<Mapping> CreateComponentMappings();
    }
}