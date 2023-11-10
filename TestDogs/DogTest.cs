    using dogs_test.src;
    using dogs_test.src.models;
    using dogs_test.src.services;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using Xunit;

    namespace TestDogs
    {
        public class DogTest
        {
            private readonly DogsController _controller;
            private readonly Mock<IDogs> _serviceMock; // Cambiar a Mock<IDogs>

            public DogTest()
            {
                _serviceMock = new Mock<IDogs>(); // Inicializa el mock

                // Configura el controlador para usar el servicio simulado
                _controller = new DogsController(_serviceMock.Object);
            }

            [Fact]
            public void Get_OK()
            {
                // Configura el comportamiento esperado del servicio para la prueba Get_OK
                _serviceMock.Setup(service => service.GetDogs()).Returns(new List<Dogs>()); // Simula que devuelve una lista vacía de perros

                var okResult = _controller.GetDogs();

                // Verifica que el resultado sea un OkObjectResult
                Assert.IsType<OkObjectResult>(okResult);
            }

            [Fact]
            public void Get_NotFound()
            {
                // Configura el comportamiento esperado del servicio para la prueba Get_NotFound
                _serviceMock.Setup(service => service.GetDog(It.IsAny<int>())).Returns((Dogs)null); // Simula que no se encuentra ningún perro

                var notFoundResult = _controller.GetDog(0);

                // Verifica que el resultado sea un NotFoundResult
                Assert.IsType<NotFoundResult>(notFoundResult);
            }

            [Fact]
            public void Get_Found()
            {
                // Configura el comportamiento esperado del servicio para la prueba Get_Found
                _serviceMock.Setup(service => service.GetDog(It.IsAny<int>())).Returns(new Dogs { Id = 1, Name = "SomeDog" }); // Simula que se encuentra un perro con el ID 1

                var okResult = _controller.GetDog(1);

                // Verifica que el resultado sea un OkObjectResult
                Assert.IsType<OkObjectResult>(okResult);
            }

            [Fact]
            public void Get_FoundDog()
            {
                // Configura el comportamiento esperado del servicio para la prueba Get_FoundDog
                _serviceMock.Setup(service => service.GetDog(It.IsAny<int>())).Returns(new Dogs { Id = 1, Name = "Fido" }); // Simula que se encuentra un perro con el ID 1 y nombre "Fido"

                var okResult = _controller.GetDog(1) as OkObjectResult;
                var dog = Assert.IsType<Dogs>(okResult.Value);

                // Verifica que el nombre del perro sea "Fido"
                Assert.Equal("Fido", dog.Name);
            }
        }
    }
