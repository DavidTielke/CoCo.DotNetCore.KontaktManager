namespace Mappings
{
    public interface IInjectScope
    {
        Mapping AsSingleton();

        Mapping AsTransient();
    }
}