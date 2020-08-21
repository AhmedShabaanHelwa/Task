using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.DTOs
{
    public class WideBotBareResponse
    {
        public WideBotBareResponse()
        {
            this.FacebookResponse = new BareResponse();
        }
        public BareResponse FacebookResponse { get; set; }
    }

    public class BareResponse
    {
        public BareResponse()
        {
            this.messaging_type = "RESPONSE";
            this.recipient = new Recipient();
            this.message = new Message();
        }
        public string messaging_type { get; set; }
        public Recipient recipient { get; set; }
        public Message message { get; set; }



        public class Recipient
        {
            public Recipient()
            {
                this.id = "{psid}"; // or <PSID>
            }
            public string id { set; get; }
        }

        public class Message
        {
            public Message()
            {
                this.text = "Hello world!";
            }
            public string text { set; get; }
        }
    }
}
