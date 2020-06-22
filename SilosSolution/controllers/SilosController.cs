using SilosSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;

namespace SilosSolution.controllers
{
    //Test commit commento

    //Modifica da committare
    public class SilosController : ApiController
    {
        static HttpClient client = new HttpClient();

        SiloModel[] silos = new SiloModel[]
        {
            new SiloModel { SilosId = 1, Capacity = 10, Filling = 7},
            new SiloModel { SilosId = 2, Capacity = 10, Filling = 0},
            new SiloModel { SilosId = 3, Capacity = 10, Filling = 10},
            new SiloModel { SilosId = 4, Capacity = 40, Filling = 32},
            new SiloModel { SilosId = 5, Capacity = 40, Filling = 31},
            new SiloModel { SilosId = 6, Capacity = 60, Filling = 55},
        };

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:64195/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public IEnumerable<SiloModel> GetAllResources()
        {
            return silos;
        }

        public IHttpActionResult GetResources(int id)
        {
            var silo = silos.FirstOrDefault((p) => p.SilosId == id);
            if (silo == null)
            {
                return NotFound();
            }
            return Ok(silo);
        }

        static async Task<Uri> PostResource(int id)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/silos", id);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}