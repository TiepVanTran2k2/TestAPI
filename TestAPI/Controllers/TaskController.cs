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
using TestAPI.Dto.Task;
using TestAPI.EntityFramework;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class TaskController : ApiController
    {
        public TaskController() { }
        public async Task<List<TaskDto>> GetAsync()
        {
            using(var db = new AppDbContext())
            {
                var listTask = await db.Task.ToListAsync();
                if (!listTask.Any())
                {
                    return new List<TaskDto>();
                }
                var result = Mapper.Map<List<TaskDto>>(listTask);
                return result;
            }
        }
        public async Task<TaskCreateDto> CreateAsync(TaskCreateDto input)
        {
            using (var db = new AppDbContext()) 
            {
                var data = Mapper.Map<TestAPI.Models.Task>(input);
                db.Task.Add(data);
                await db.SaveChangesAsync();
                return input;
            }
        }
        public async Task<TaskDto> GetAsync(int id)
        {
            using (var db = new AppDbContext())
            {
                var task = await db.Task.FindAsync(id);
                if(task == null)
                {
                    return null;
                }
                return Mapper.Map<TaskDto>(task);
            }
        }
        public async Task<bool> PutAsync(TaskDto input)
        {
            using(var db = new AppDbContext())
            {
                var task = await db.Task.FindAsync(input.Id);
                if(task == null)
                {
                    return false;
                }
                var data = Mapper.Map(input, task);
                db.Task.AddOrUpdate(data);
                await db.SaveChangesAsync();
                return true;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            using(var db = new AppDbContext())
            {
                var task = await db.Task.FindAsync(id);
                if(task == null)
                {
                    return false;
                }
                db.Task.Remove(task); 
                await db.SaveChangesAsync();
                return true
            }
        }
    }
}
