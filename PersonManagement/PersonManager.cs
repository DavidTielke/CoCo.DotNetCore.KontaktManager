using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bremacon.CorePersonManager.CrossCutting.DataClasses;
using Bremacon.CorePersonManager.Data.DataStoring.Contracts;
using Bremacon.CorePersonManager.Logic.PersonManagement.Contracts;

using Configuration.Contracts;

namespace Bremacon.CorePersonManager.Logic.PersonManagement
{
    public class PersonManager : IPersonManager, IPersonStatistics
    {
        private readonly IPersonRepository _repository;
        private readonly IConfigurator _config;
        private readonly int _ageTreshold;

        public PersonManager(IPersonRepository repository, IConfigurator config)
        {
            _repository = repository;
            _config = config;
            _ageTreshold = config.Get<int>("Filters", "AgeTreshold");
        }

        public PersonAgeStatistic GetAgeStatistic()
        {
            return new PersonAgeStatistic
            {
                AdultsCount = GetAllAdults().Count(),
                ChildrenCount = GetAllChildren().Count(),
            };
        }

        public IQueryable<Person> GetAllAdults()
        {
            return _repository.CreateQuery().Where(p => p.Age >= _ageTreshold).AsQueryable();
        }

        public IQueryable<Person> GetAllChildren()
        {
            return _repository.CreateQuery().Where(p => p.Age < _ageTreshold).AsQueryable();
        }
    }
}
