using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProjectNetCore.Models
{
    public class Login
    {
        public string User { get; set; }
        public string Pass { get; set; }

        public override string ToString() 
        {
            return User + "," + Pass;
        }
    }
}
