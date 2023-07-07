using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI.Models
{
    public class StaffInTask : BaseEntity
    {
        public int StaffId { get; set; }
        public int TaskId { get; set; }
        public Task Tasks { get; set; }
        public Staff Staffs { get;set; }
    }
}