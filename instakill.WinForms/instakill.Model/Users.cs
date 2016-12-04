using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instakill.Model
{
    public class Users
    {
        public Guid UserId { get; set; }
        public string Nickname { get; set; }
        public string Username { get; set; }
        public string Info { get; set; }
        //представляет собой фразу/предложение, а не социальный статус 
        public List<Users> Followers { get; set;}
        public List<Users> Subscriptions { get; set; }
        public Users()
        {
            Followers = new List<Users>();
            Subscriptions = new List<Users>();
        }
    } 
}

