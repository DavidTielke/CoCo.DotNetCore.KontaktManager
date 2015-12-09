using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Bremacon.CorePersonManager.CrossCutting.DataClasses;
using Bremacon.CorePersonManager.Logic.PersonManagement.Contracts;

namespace WebClient.Models.Home
{
    public class HomeIndexModel
    {
        public List<Person> Adults { get; set; }
        public List<Person> Children { get; set; }
        public PersonAgeStatistic Statistics { get; set; }
    }
}
