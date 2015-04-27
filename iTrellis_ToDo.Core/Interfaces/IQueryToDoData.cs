using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iTrellis_ToDo.Core.Model;

namespace iTrellis_ToDo.Core.Interfaces
{
    public interface IQueryToDoLists
    {
        ToDoListResponse All();
        ToDoListResponse CreateToDoList(ToDoList todoList);
    }

    public interface IQueryToDoListItems
    {

    }
}
