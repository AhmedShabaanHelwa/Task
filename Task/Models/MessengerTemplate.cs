using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public class TemplateBase
    {
        public string type { get; set; }
        public string url { get; set; }
    }

    public class MessengerTemplate
    {
        public string template_type { get; set; }
        public Elements elements { get; set; }
        public List<Buttons> buttons { get; set; }
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


    public class Elements
    {
        public string title { get; set; }
        public string image_url { get; set; }
        public string subtitle { get; set; }
        public DefaultAction default_action { get; set; }

    }

    public class DefaultAction : TemplateBase
    {
        public string webview_height_ratio { get; set; }

    }

    //Recipient Object
    public class Recipient
    {
        public Recipient()
        {
            this.id = "{psid}";
        }
        public string id {set; get;}
    }
}
