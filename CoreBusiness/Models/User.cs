using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Models
{
    public class User
    {
        public User()
        {
            UserId = Guid.NewGuid();
        }


        public Guid UserId { get; set; }
        
        public string Name { get; set; }
        
        public string Username { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}
