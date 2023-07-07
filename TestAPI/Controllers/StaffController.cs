using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using TestAPI.Dto.Staff;
using TestAPI.EntityFramework;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class StaffController : ApiController
    {
        public StaffController() { }
        public async Task<IEnumerable<StaffUpdateDto>> GetAsync()
        {
            var result = new List<StaffUpdateDto>();
            using (var db = new AppDbContext())
            {
                var listStaff = await db.Staff.ToListAsync();
                result = Mapper.Map<List<StaffUpdateDto>>(listStaff);
            }
            return result;
        }
        public async Task<StaffDto> PostAsync([FromBody] StaffDto input)
        {
            using(var db = new AppDbContext())
            {
                var staff = Mapper.Map<Staff>(input);
                db.Staff.Add(staff);
                await db.SaveChangesAsync();
            }
            return input;
        }
        public async Task<StaffDto> GetAsync(int id)
        {
            var result = new StaffDto();
            using(var db = new AppDbContext())
            {
                var staff = await db.Staff.FindAsync(id);
                result = Mapper.Map<StaffDto>(staff);
            }
            return result;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            using(var db = new AppDbContext())
            {
                var staff = await db.Staff.FindAsync(id);
                if(staff != null)
                {
                    db.Staff.Remove(staff);
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
        public async Task<bool> PutAsync(StaffUpdateDto input)
        {
            using(var db = new AppDbContext())
            {
                var staff = await db.Staff.FindAsync(input.Id);
                if(staff != null)
                {
                    var data = Mapper.Map(input, staff);
                    db.Staff.AddOrUpdate(data);
                    await db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
        }
    }
}
