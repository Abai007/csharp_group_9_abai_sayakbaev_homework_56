using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_56.Models
{
    public class TaskToDo
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string CreatorName { get; set; }
        public int PriorityKey { get; set; }
        public string Priority { get; set; }
        public int StatusKey { get; set; }
        public string Status { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ComplateDate { get; set; }
        public DateTime? OpenDate { get; set; }
        public string Description { get; set; }
    }
}
