namespace Mappings
{
    public interface IImplementationMapping
    {
        IInjectScope To<TImpl>();
    }
}