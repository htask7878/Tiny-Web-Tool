using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Model.Models
{
    public class Category : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PageUrl { get; set; }
        public int Controller { get; set; }
        public int ActionName { get; set; }
        public string Logo { get; set; }
        public int Tagline { get; set; }
    }
}
