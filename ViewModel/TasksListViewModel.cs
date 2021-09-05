using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_56.ViewModel
{
    public class TasksListViewModel

    {
        public IEnumerable<Task> Tasks { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public SelectList Priority { get; set; }
        public SelectList Status { get; set; }
    }
}
