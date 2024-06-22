using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EczamenV3.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
