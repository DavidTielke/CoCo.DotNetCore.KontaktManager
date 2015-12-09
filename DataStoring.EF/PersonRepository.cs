using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bremacon.CorePersonManager.CrossCutting.DataClasses;
using Bremacon.CorePersonManager.Data.DataStoring.Contracts;

using Configuration.Contracts;

namespace DataStoring.EF
{
    public class PersonRepository : IPersonRepository
    {
        private readonly StorageContext _db;

        public PersonRepository(IConfigurator config)
        {
            _db = new StorageContext(config);
        }

        public IQueryable<Person> CreateQuery()
        {
            return _db.Persons;
        }
    }
}
