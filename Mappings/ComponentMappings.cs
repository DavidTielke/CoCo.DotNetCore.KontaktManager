using System;
using System.Collections;
using System.Collections.Generic;

namespace Mappings
{
    public class ComponentMappings : IEnumerable<Mapping>
    {
        public List<Mapping> Mappings { get; set; }

        public ComponentMappings()
        {
            Mappings = new List<Mapping>();
        }

        public ComponentMappings AddMappingsFor<T>()
            where T : IComponentMapping
        {
            IComponentMapping instance = Activator.CreateInstance<T>();
            var mappings = instance.CreateComponentMappings();
            Mappings.AddRange(mappings);
            return this;
        }

        public IEnumerator<Mapping> GetEnumerator()
        {
            return Mappings.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Mappings.GetEnumerator();
        }
    }
}