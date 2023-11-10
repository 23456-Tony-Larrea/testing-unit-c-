using dogs_test.src;
using dogs_test.src.models;
using dogs_test.src.services;
using Microsoft.AspNetCore.Mvc;

namespace TestDogs
{
    public class DogTest
    {
        private readonly DogsController _controller;
        private readonly IDogs _service;

        public DogTest()
        {
            _service = new DogService();
            _controller = new DogsController(_service);
        }

        [Fact]
        public void Get_OK()
        {
            var okResult = _controller.GetDogs();
            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void Get_NotFound()
        {
            var notFoundResult = _controller.GetDog(0);
            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        [Fact]
        public void Get_Found()
        {
            var okResult = _controller.GetDog(1);
            Assert.IsType<OkObjectResult>(okResult);
        }
        [Fact]
        public void Get_FoundDog()
        {
            var okResult = _controller.GetDog(1) as OkObjectResult;
            var dog = Assert.IsType<Dogs>(okResult.Value);
            Assert.Equal("Fido", dog.Name);
        }
    }
}