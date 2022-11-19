using System;
using System.Collections.Generic;
using System.Text;

namespace MyXamarinApp.Models
{
    public class User
    {
        public String UserName { get; set; }
        public string Email { get; set; }
        // public String PhoneNumber { get; set; }
        public String Password { get; set; }
        public List<string> Answers { get; set; }
        // public String Gender { get; set; }
    }
}
