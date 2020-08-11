using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Task.DTOs;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntegratorController : ControllerBase
    {
        //GET api/integrator
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserById(int id)
        {
            //!AhmedShaban: Handling the Not found error code 404
            try
            {
                //read from API
                var webClient = new WebClient();
                var jsonData = string.Empty;
                jsonData = webClient.DownloadString($"https://reqres.in/api/users/{id}");

                JObject json = JObject.Parse(jsonData);
                //deserialze
                var user = JsonConvert.DeserializeObject<UserDto>(jsonData);
                return Ok(user);
            }
            catch (Exception e)
            {
                //  Block of code to handle errors
                return NotFound();
            }
            
        }
    }
}
