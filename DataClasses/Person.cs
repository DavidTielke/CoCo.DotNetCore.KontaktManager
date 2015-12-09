using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bremacon.CorePersonManager.CrossCutting.DataClasses
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class Person
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public Person(int id, string firstname, string lastname, int age)
        {
            ID = id;
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
        }

        public Person()
        {
            
        }
    }
}
