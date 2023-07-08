using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestAPI.Dto.Task
{
    public class TaskDto
    {
        public int Id { get; set; }
        public int? IDparent { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public bool IsUnscheduled { get; set; }
    }
    public class TaskCreateDto
    {
        public int? IDparent { get; set; }
        public string Label { get; set; }
        public TypeTaskEnum Type { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public bool IsUnscheduled { get; set; }
    }
}