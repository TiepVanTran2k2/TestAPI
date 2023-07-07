using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI.Models
{
    public class Staff : BaseEntity
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public virtual ICollection<StaffInTask> Tasks { get; set; }
    }
}