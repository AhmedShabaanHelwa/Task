using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    //!AhmedShaban: The main model of a User
    public class User
    {
        public UserData Data { get; }
        public UserAd Ad { get; }
    }

    public class UserData
    {
        [Key]
        public int Id { get; set; }
        //!comment: Validate the property inputs
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Avatar { get; set; }
    }
    public class UserAd 
    {
        //!AhmedShaban: It's always set to the given string
        public UserAd()
        {
            this.Company = "StatusCode Weekly";
            this.Url = "http://statuscode.org/";
            this.Text = "A weekly newsletter focusing on software development, infrastructure, the server, performance, and the stack end of things.";
        }
        [Required]
        public string Company { get; }
        [Required]
        public string Url { get; }
        [Required]
        public string Text { get; }
    }
}
