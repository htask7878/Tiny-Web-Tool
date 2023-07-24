using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Model.Models
{
    public class Loginattemp : BaseModel
    {
        public int Id { get; set; }
        public string Username { get; set; }    
        public DateTime time { get; set; }    
    }
}
