using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Configuration.Contracts;

namespace Configuration
{
    public class Configurator : IConfigurator
    {
        private readonly Dictionary<string, object> _items;

        public Configurator()
        {
            _items = new Dictionary<string, object>();
        } 

        public T Get<T>(string area, string key)
        {
            return (T)_items[area + "." + key];
        }

        public void Set(string area, string key, object value, bool persist)
        {
            _items[area + "." + key] = value;
        }
    }
}
