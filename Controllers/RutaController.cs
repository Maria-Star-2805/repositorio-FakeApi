using FakeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Microsoft.DotNet.MSIdentity.Shared;


namespace FakeAPI.Controllers
{

    [ApiController]
    [Route("controller")]

    public class RutaController : ControllerBase
    {

        

   



        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<ApiResponse>> GetAllProducts()
        {
            string url = " https://api.escuelajs.co/api/v1/products";
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(url);
               
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                  var  resultado = JsonConvert.DeserializeObject<List<ApiResponse>>(responseContent);
                   
                    return Ok(resultado);
                   
                }
                else
                {
                    return BadRequest();
                }



            }



        }


    }


}