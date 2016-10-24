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
        public string Status { get; set; }
        //представляет собой фразу/предложение, а не социальный статус 

    }
}

