using dogs_test.src.models;

namespace dogs_test.src.services
{
    public class DogService:IDogs
    {
        private readonly List<Dogs> _dogs;
        public DogService()
        {
            _dogs = new List<Dogs>()
            {
                new Dogs() { Id = 1, Name = "Fido", DogBreed = "Labrador" },
                new Dogs() { Id = 2, Name = "Rex", DogBreed = "German Shepherd" },
                new Dogs() { Id = 3, Name = "Snoopy", DogBreed = "Beagle" },
                new Dogs() { Id = 4, Name = "Scooby", DogBreed = "Great Dane" },
                new Dogs() { Id = 5, Name = "Clifford", DogBreed = "Big Red Dog" }
            };
        }
        public IEnumerable<Dogs> GetDogs()
        {
            return _dogs;
        }
        public Dogs GetDog(int id)
        {
            return _dogs.FirstOrDefault(d => d.Id == id);
        }
    }
}
