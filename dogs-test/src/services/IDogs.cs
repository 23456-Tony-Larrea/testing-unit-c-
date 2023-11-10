using dogs_test.src.models;

namespace dogs_test.src.services
{
    public interface IDogs
    {
        public IEnumerable<Dogs> GetDogs();
        public Dogs GetDog(int id);
    }
}
