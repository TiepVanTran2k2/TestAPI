using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TestAPI.Dto.Staff;
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
        public async Task<StaffDto> Post([FromBody] StaffDto input)
        {
            using(var db = new AppDbContext())
            {
                var staff = Mapper.Map<Staff>(input);
                db.Staff.Add(staff);
                await db.SaveChangesAsync();
            }
            return input;
        }
    }
}
