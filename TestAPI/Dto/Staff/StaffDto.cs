using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI.Dto.Staff
{
    public class StaffDto
    {
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
    public class StaffUpdateDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
}