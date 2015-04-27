using iTrellis_ToDo.Core.Interfaces;
using iTrellis_ToDo.Core.Model;
using iTrellis_ToDo.Core.Services;
using iTrellis_ToDo.Infrastructure.Data;
using iTrellis_ToDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iTrellis_ToDo.Controllers
{
    public class ToDoListController : Controller
    {
        private ToDoListModel todoListModel;
        private readonly IQueryToDoLists _iqueryToDoLists;
        private ToDoListService _todoListService;
        private ToDoListResponse _todoListResponse;

        public ToDoListController(IQueryToDoLists queryToDoLists)
        {
            _iqueryToDoLists = queryToDoLists;
            _todoListService = new ToDoListService(_iqueryToDoLists);          
        }

        public ToDoListController()
            : this(new EfQueryToDoLists())
        {
        }

        public ActionResult Index(int id)
        {        
            _todoListResponse = _todoListService.All();
            if (_todoListResponse.Success)
            {
                todoListModel = new ToDoListModel(_todoListResponse.ToDoLists.Where(x => x.ID == id).SingleOrDefault());
            }
            return View(todoListModel);
        }

    }
}
