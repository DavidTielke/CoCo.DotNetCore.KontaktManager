using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mappings
{
    public class Mapping : IContractMapping, IImplementationMapping, IInjectScope
    {
        public Scope Scope { get; set; }
        public Type ContractType { get; set; }
        public Type ImplementationType { get; set; }

        public IImplementationMapping From<TContract>()
        {
            ContractType = typeof(TContract);
            return this;
        }

        public IInjectScope To<TImpl>()
        {
            ImplementationType = typeof(TImpl);
            return this;
        }

        public Mapping AsSingleton()
        {
            Scope = Scope.Singleton;
            return this;

        }

        public Mapping AsTransient()
        {
            Scope = Scope.Transient;
            return this;
        }
    }
}
