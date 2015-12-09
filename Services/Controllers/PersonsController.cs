using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Bremacon.CorePersonManager.CrossCutting.DataClasses;
using Bremacon.CorePersonManager.Logic.PersonManagement.Contracts;

using Security.Contracts;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        private readonly IPersonManagerSecurity _manager;
        private readonly IPersonStatisticsSecurity _statistics;

        public PersonsController(IPersonManagerSecurity manager, IPersonStatisticsSecurity statistics)
        {
            _manager = manager;
            _statistics = statistics;
        }

        [HttpGet("Adults")]
        public IEnumerable<Person> GetAdults()
        {
            var adults =  _manager.GetAllAdults();
            return adults;
        }

        [HttpGet("Children")]
        public IEnumerable<Person> GetChildren()
        {
            return _manager.GetAllChildren();
        }

        [HttpGet("Statistics")]
        public PersonAgeStatistic GetStatistics()
        {
            return _statistics.GetAgeStatistic();
        }

    }
}
