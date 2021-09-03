using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_56.Models
{
    public class ToDoContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> options): base(options)
        {

        }
    }
}
