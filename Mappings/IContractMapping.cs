namespace Mappings
{
    public interface IContractMapping
    {
        IImplementationMapping From<TContract>();
    }
}