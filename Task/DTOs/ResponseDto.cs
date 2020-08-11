using System;
using System.Collections.Generic;
using System.Linq;
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
                            { default_action = new DefaultAction 
                                                     { type = "web_url",
                                                        url = "mailto:PersonMail? Subject = Hello",
                                                        webview_height_ratio = "tall" }
                             };
            //this.default_action.type = "web_url";
            //this.default_action.url = "mailto:PersonMail? Subject = Hello";
            //this.default_action.webview_height_ratio = "tall";
            this.buttons = new Buttons { type = "web_url", url = "mailto:PersonMail?Subject=Hello", title = "Send Email" };
            //this.buttons.type = "web_url";
            //this.buttons.url = "mailto:PersonMail?Subject=Hello";
            //this.buttons.title = "Send Email";
        }
    }

    public class Payload
    {
        public ResponseDto payload { get; set; }
    }

}
