using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instakill.Model
{
    public class Posts
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public string Photo { get; set; }
        public DateTime Date { get; set; }
        public List<Users> WhoLikes { get; set; }
        public List<Comments> AllComments { get; set; }
        public Posts()
        {
            WhoLikes = new List<Users>();
        }
    }
}
