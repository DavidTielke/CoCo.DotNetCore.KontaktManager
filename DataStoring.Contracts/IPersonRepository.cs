using System.Linq;

using Bremacon.CorePersonManager.CrossCutting.DataClasses;

namespace Bremacon.CorePersonManager.Data.DataStoring.Contracts
{
    public interface IPersonRepository
    {
        IQueryable<Person> CreateQuery();
    }
}