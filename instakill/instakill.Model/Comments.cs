using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instakill.Model
{
    public class Comments
    {
        public Guid IdCom { get; set; }
        public int IdPost { get; set; }
        public int IdFrom { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
