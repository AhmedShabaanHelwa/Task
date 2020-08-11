using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public IntegratorController(IMapper mapper)
        {
            _mapper = mapper;
        }
        //GET api/integrator
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUserById(int id)
        {
            //!AhmedShaban: Handling the Not found error code 404
            try
            {
                //AhmedShaban: 1 - Retrieving the user data, in internal-domain map
                var user = ReadData(id);
                //AhmedShaban: 2 - Map the user data to the Messenger Response format
                var mappedUser = _mapper.Map<ResponseDto>(user);
                var payload = new Payload() { payload = mappedUser };
                //!AhmedShaban: 3 - Reurn the reslut
                return Ok(payload);
            }
            catch (Exception e)
            {
                //!AhmedShanan: Retrun 404 error code in case of NotFound response from the remote API
                return NotFound();
            }
            
        }

        private UserDto ReadData(int id)
        {
            
            var webClient = new WebClient();
            var jsonData = string.Empty;

            //Read from API as HttpClient, retrieve the JSON raw
            jsonData = webClient.DownloadString($"https://reqres.in/api/users/{id}");

            //Parse the JSON raw to seriallize the string into JSON object
            JObject json = JObject.Parse(jsonData);
            //Deserialize the json to a Response DTO object
            var user = JsonConvert.DeserializeObject<UserDto>(jsonData);

            return user;
        }
    }
}
