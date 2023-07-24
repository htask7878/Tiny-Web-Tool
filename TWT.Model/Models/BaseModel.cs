using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWT.Model.Models
{
    public class BaseModel
    {
        public int IsActive { get; set; }
        public int IsDeleted { get; set; }
        public int UpdatedByUserId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }     
        public DateTime UpdatedDate { get; set; }     
    }
}
