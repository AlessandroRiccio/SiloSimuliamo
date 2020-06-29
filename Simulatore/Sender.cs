using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Simulatore.Models;

namespace Simulatore
{
    public class Sender
    {
        public async System.Threading.Tasks.Task Send(List<GeneratorResult> silos)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(silos), Encoding.UTF8, "application/json");

                var result = await client.PostAsync("http://localhost:5000/newdata", content);
                string resultContent = await result.Content.ReadAsStringAsync();
            }
        }
    }
}
