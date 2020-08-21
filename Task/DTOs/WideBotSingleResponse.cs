using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.DTOs
{
    public class WideBotSingleResponse
    {
        public Response FacebookResponse { get; set; }
    }
    
    
    public class WideMultipeResponse
    {
        public MultiUsersRespond FacebookResponse { get; set; }
    }
}
