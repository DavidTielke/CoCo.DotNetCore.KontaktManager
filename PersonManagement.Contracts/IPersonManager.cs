using System.Linq;

using Bremacon.CorePersonManager.CrossCutting.DataClasses;

namespace Bremacon.CorePersonManager.Logic.PersonManagement.Contracts
{
    public interface IPersonManager
    {
        IQueryable<Person> GetAllAdults();

        IQueryable<Person> GetAllChildren();
    }
}