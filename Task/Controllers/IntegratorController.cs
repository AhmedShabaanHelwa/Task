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
        [HttpGet()]
        public ActionResult<WideMultipeResponse> GatAll()
        {
            //Get the data
            var users = ReadData();
            //Map the respond to Facebook
            var response = PrepareResponse(users);
            //To list
            return Ok(response);
        }

        //GET api/integrator
        [HttpGet("{id}")]
        public ActionResult<WideBotSingleResponse> GetUserById(int id)
        {
            //!AhmedShaban: Handling the Not found error code 404
            try
            {
                //AhmedShaban: 1 - Retrieving the user data, in internal-domain map
                var user = ReadData(id);
                var response = PrepareResponse(user);
                //!AhmedShaban: 3 - Reurn the reslut
                //response.FacebookResponse.recipient.id = "{psid}";
                return Ok(response);
            }
            catch (Exception e)
            {
                //!AhmedShanan: Retrun 404 error code in case of NotFound response from the remote API
                return NotFound();
            }
            
        }




        
        [HttpGet("widebot")]
        public ActionResult<WideBotBareResponse> BareWide()
        {
            var bareResponse =
                new WideBotBareResponse();
            return Ok(bareResponse);
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

        private UsersDto ReadData()
        {
            //Open HttpClient
            var webClient = new WebClient();
            var jsonData = string.Empty;
            //Read from API as HttpClient, retrieve the JSON raw
            jsonData = webClient.DownloadString($"https://reqres.in/api/users/");

            JObject json = JObject.Parse(jsonData);

            //Parse the JSON raw to seriallize the string into JSON objec
            var test = json.ToObject<UsersDto>();
            //var user = JsonConvert.DeserializeObject<UsersDto>(json);
            return test;
        }

        private WideBotSingleResponse PrepareResponse(UserDto user)
        {
            //AhmedShaban: 2 - Map the user data to the Messenger Response format
            var mappedUser = _mapper.Map<ResponseDto>(user);
            //var payload = new Payload() { payload = mappedUser };
            var attach = new Attach() { payload = mappedUser };

            var message = new Message() { attachment = attach};

            var response = new Response() { message = message };
            var wideBot = new WideBotSingleResponse() { FacebookResponse = response };

            return wideBot;
        }

        
        private WideMultipeResponse PrepareResponse(UsersDto user)
        {
            //AhmedShaban: 2 - Map the user data to the Messenger Response format
            var mappedUsers = new MultiUsersRespond();
            for (int item = 0; item < user.data.Count;item++)
            {
                mappedUsers.message.attachment.payload.elements.Add
                (
                new MultiUsersRespond.Element()
                );

                mappedUsers.message.attachment.payload.elements[item].title = 
                    user.data[item].first_name;
                mappedUsers.message.attachment.payload.elements[item].image_url =
                    user.data[item].avatar;
                mappedUsers.message.attachment.payload.elements[item].subtitle =
                    user.data[item].last_name;
            }
            var mappedWideResonse = new WideMultipeResponse() {FacebookResponse = mappedUsers };
            return mappedWideResonse;
        }

    }
}
