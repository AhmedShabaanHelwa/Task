using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Task.Models;

namespace Task.DTOs
{
    public class ResponseDto : MessengerTemplate
    {
        public ResponseDto()
        {
            this.template_type = "generic";

            this.elements = new Elements()
            {
                default_action = new DefaultAction
                {
                    type = "web_url",
                    url = "mailto:PersonMail? Subject = Hello",
                    webview_height_ratio = "tall"
                }
            };
            this.buttons = new List<Buttons>();
            this.buttons.Add(new Buttons()
            {
                type = "web_url",
                url = "mailto:PersonMail?Subject=Hello",
                title = "Send Email"
            }); 
        }
    }

    public class Message
    {
        public Attach attachment { get; set; }
    }

    public class Attach
    {
        public Attach()
        {
            this.type = "template";
        }
        public string type { set; get; }
        public ResponseDto payload { get; set; }
    }

    public class Response
    {
        public Response()
        {
            this.messaging_type = "RESPONSE";
            this.recipient = new Recipient();
        }
        public string messaging_type { get; set; }
        public Recipient recipient { get; set; }
        public Message message { get; set; }
    }
}
