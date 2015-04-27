using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iTrellis_ToDo.Core.Interfaces;
using iTrellis_ToDo.Core.Model;

namespace iTrellis_ToDo.Core.Services
{
    public class ToDoListService : IQueryToDoLists
    {
        private readonly IQueryToDoLists _iqueryToDoLists;
        
        public ToDoListService(IQueryToDoLists iqueryToDoLists)
        {
            _iqueryToDoLists = iqueryToDoLists;
        }

        public ToDoListResponse All()
        {
            ToDoListResponse todolistresponse = new ToDoListResponse();
            try
            {
                todolistresponse = _iqueryToDoLists.All();
                todolistresponse.Success = true;
            }
            catch (Exception ex)
            {
                todolistresponse.Success = false;
                todolistresponse.ErrorMessage = ex.ToString();
            }
            return todolistresponse;
        }

        public ToDoListResponse CreateToDoList(Core.Model.ToDoList coreToDoList)
        {
            ToDoListResponse todolistresponse = new ToDoListResponse();
            try
            {
                todolistresponse = _iqueryToDoLists.CreateToDoList(coreToDoList);
            }
            catch(Exception ex)
            {
                todolistresponse.Success = false;
                todolistresponse.ErrorMessage = ex.ToString();
            }
            return todolistresponse;
        }
    }

}
