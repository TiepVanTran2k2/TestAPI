using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestAPI.EntityFramework;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    public class StaffController : ApiController
    {
        public StaffController() { }
        public async Task<IEnumerable<Staff>> Get()
        {
            var result = new List<Staff>();
            using (var db = new AppDbContext())
            {
                result = await db.Staff.ToListAsync();
            }
            return result;
        }
        public async Task<Staff> Post([FromBody] Staff staff)
        {
            var result = new Staff();
            using(var db = new AppDbContext())
            {
                db.Staff.Add(staff);
                db.SaveChanges();
            }
            return result;
        }
    }
}
