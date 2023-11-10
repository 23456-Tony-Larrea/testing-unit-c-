using dogs_test.src.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dogs_test.src
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IDogs _dogs;
        public DogsController(IDogs dogs)
        {
            _dogs = dogs;
        }
        [HttpGet]
        public IActionResult GetDogs()
        {
            return Ok(_dogs.GetDogs());
        }
        [HttpGet("{id}")]
        public IActionResult GetDog(int id)
        {
            var dog = _dogs.GetDog(id);
            if (dog == null)
            {
                return NotFound();
            }
            return Ok(dog);
        }
    }
}
