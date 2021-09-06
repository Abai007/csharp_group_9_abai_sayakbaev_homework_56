using homework_56.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace homework_56.ViewModel
{
    public class TasksListViewModel

    {
        public IEnumerable<TaskToDo> Tasks { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
    }
}
