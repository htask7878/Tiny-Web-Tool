using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Model.Models
{
    public class Pages : BaseModel 
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageUrl { get; set; }
        public int Controller { get; set; }
        public int ActionName { get; set; }
        public string IconClass { get; set; }
        public string MenuLevel { get; set; }
        public string MenuOrder { get; set; }
    }
}
