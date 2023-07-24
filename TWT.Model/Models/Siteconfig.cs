using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Model.Models
{
    public class Siteconfig : BaseModel
    {
        public int Id { get; set; }
        public string KeyName { get; set; }    
        public string Description { get; set; } 
    }
}
