using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instakill.Model
{
    public class Likes
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
