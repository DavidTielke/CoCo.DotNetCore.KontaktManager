using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bremacon.CorePersonManager.CrossCutting.DataClasses;
using Bremacon.CorePersonManager.Data.DataStoring.Contracts;

namespace Bremacon.CorePersonManager.Data.DataStoring
{
    public class PersonRepository : IPersonRepository
    {
        public IQueryable<Person> CreateQuery()
        {
            return new List<Person>
            {
                new Person(1,"David","Tielke",31),
                new Person(2,"Lena","Tielke",28),
                new Person(3,"Maximilian","Tielke",3),
                new Person(4,"Teddy","Tielke",1),
            }.AsQueryable();
        }
    }
}
