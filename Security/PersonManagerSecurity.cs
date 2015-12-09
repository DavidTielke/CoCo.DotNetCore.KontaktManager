using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using Bremacon.CorePersonManager.CrossCutting.DataClasses;
using Bremacon.CorePersonManager.Logic.PersonManagement.Contracts;

using Configuration.Contracts;

using Security.Contracts;

using UserManagement.Contracts;

namespace Security
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class PersonManagerSecurity : IPersonManagerSecurity, IPersonStatisticsSecurity
    {
        private readonly IPersonManager _manager;
        private readonly IPersonStatistics _statistics;
        private readonly IFieldAuthorizator _authorizator;
        private DataObjectCutter _cutter;

        public PersonManagerSecurity(
            IPersonManager manager, 
            IPersonStatistics statistics,
            IFieldAuthorizator authorizator)
        {
            _manager = manager;
            _statistics = statistics;
            _authorizator = authorizator;

            _cutter = new DataObjectCutter(_authorizator);
        }

        public IQueryable<Person> GetAllAdults()
        {
            var adults = _manager.GetAllAdults().ToList();
            return CutPersonList(adults);
        }

        private IQueryable<Person> CutPersonList(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                _cutter.Cut(person);
            }
            return persons.AsQueryable();
        }

        public IQueryable<Person> GetAllChildren()
        {
            var children =  _manager.GetAllChildren();
            return CutPersonList(children);
        }

        public PersonAgeStatistic GetAgeStatistic()
        {
            return _statistics.GetAgeStatistic();
        }
    }

    public class DataObjectCutter
    {
        private readonly IFieldAuthorizator _authorizator;

        public DataObjectCutter(IFieldAuthorizator authorizator)
        {
            _authorizator = authorizator;
        }

        public T Cut<T>(T obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var canView = _authorizator.CanViewField<T>(property.Name);
                if (!canView)
                {
                    property.SetValue(obj, default(T));
                }
            }

            return obj;
        }
    }
}
