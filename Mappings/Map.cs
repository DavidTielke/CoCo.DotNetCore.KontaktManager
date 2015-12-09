namespace Mappings
{
    public static class Map
    {
        public static IImplementationMapping From<T>()
        {
            return new Mapping().From<T>();
        }
    }
}