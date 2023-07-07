using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI.Models
{
    public class Task : BaseEntity
    {
        public int IDparent { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public bool IsUnscheduled { get;set; }
        public virtual ICollection<StaffInTask> Staffs { get; set; }
    }
}