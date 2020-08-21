using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models;

namespace Task.DTOs
{
    public class MultiUsersRespond
    {
        public MultiUsersRespond()
        {
            this.messaging_type = "RESPONSE";
            this.recipient = new Recipient();
            this.message = new Message();
        }
        public string messaging_type { get; set; }
        public Recipient recipient { get; set; }
        public Message message { get; set; }

        //Create Nested version of Message
        public class Message
        {
            public Message()
            {
                this.attachment = new Attach();
            }
            public Attach attachment { get; set; }
        }

        //Create Nested version of Message Attachment
        public class Attach
        {
            public Attach()
            {
                this.type = "template";
                this.payload = new Payload();
            }
            public string type { set; get; }
            public Payload payload { get; set; }
        }

        //Create Nested version of Message Payload
        public class Payload
        {
            public Payload()
            {
                this.template_type = "generic";
                this.elements = new List<Element>();
            }
            public string template_type { set; get; }
            public List<Element> elements { set; get; }
        }
        public class Element
        {
            public Element()
            {
                this.default_action = new DefaultAction
                {
                    type = "web_url",
                    url = "mailto:PersonMail? Subject = Hello",
                    webview_height_ratio = "tall"
                };

                this.buttons = new List<Buttons>();
                this.buttons.Add(
                    new Buttons
                    {
                        type = "web_url",
                        url = "mailto:PersonMail?Subject=Hello",
                        title = "Send Email"
                    });
                
            }
            public string title { get; set; }
            public string image_url { get; set; }
            public string subtitle { get; set; }
            public DefaultAction default_action { get; set; }
            public List<Buttons> buttons { get; set; }
        }

        public class DefaultAction : TemplateBase
        {
            public string webview_height_ratio { get; set; }
        }
        public class Buttons : TemplateBase
        {
            public Buttons()
            {
                this.type = "web_url";
                this.url = "mailto:PersonMail?Subject=Hello";
                this.title = "Send Email";
            }
            public string title { get; set; }
        }

    }
}
