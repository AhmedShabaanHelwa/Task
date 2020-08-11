using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task.DTOs
{
    public class UserDto
    {
        //Property 1: user data
        public userData data { get; set; }
        //Property 2: user data
        public userAd ad { get; set; }


        public class userData
        {
            [Key]
            public int id { get; set; }
            //!comment: Validate the property inputs
            [Required]
            [MaxLength(250)]
            public string email { get; set; }
            [Required]
            public string first_name { get; set; }
            [Required]
            public string last_name { get; set; }
            [Required]
            public string avatar { get; set; }
        }
        public class userAd
        {
            [Required]
            public string company { get; set; }
            [Required]
            public string url { get; set; }
            [Required]
            public string text { get; set; }
        }

    }
}
