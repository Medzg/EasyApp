using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyApp.Model
{
    public class ToDo
    {
        public ToDo()
        {
            ListToDos = new Collection<ListToDo>();
        }
        public int Id { get; set; }


        public ICollection<ListToDo> ListToDos { get; set; }


    }
}
