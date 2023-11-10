using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DogsFunction
{
    public static class DogFunction
    {
        [FunctionName("GetDog")]
        public static async Task<IActionResult> GetDog(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "dog/{id}")] HttpRequest req,
            int id,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request to get dog with ID: {id}.");

            // Aqu� podr�as tener una l�gica para obtener datos del perro con el ID proporcionado (desde una base de datos, almacenamiento, etc.)
            // Por simplicidad, asumamos que tenemos un diccionario fijo con algunos perros.
            var dogs = new Dictionary<int, string>
            {
                { 1, "Fido" },
                { 2, "Rex" },
                // ... otros perros
            };

            if (dogs.TryGetValue(id, out string name))
            {
                return new OkObjectResult($"The dog with ID {id} is named {name}.");
            }
            else
            {
                return new NotFoundResult();
            }
        }
    }
}
