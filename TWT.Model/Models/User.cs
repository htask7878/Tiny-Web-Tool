using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Model.Models
{
    public class User : BaseModel
    {
        public int Id { get; set; }
        public string Googletakon { get; set; } 
        public string Name { get; set; }
        public string Emailid { get; set; }
        public string Password { get; set; }
        
    }
}
