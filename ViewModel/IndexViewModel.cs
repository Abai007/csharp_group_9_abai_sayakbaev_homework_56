
using homework_56.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_56.ViewModel
{
    public class IndexViewModel

    {
        public IEnumerable<TaskToDo> TList { get; set; }

        public PageViewModel PageViewModel { get; set; }

    }
}
