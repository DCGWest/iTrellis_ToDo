using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using iTrellis_ToDo.Models;
using iTrellis_ToDo.Core.Interfaces;
using iTrellis_ToDo.Core.Model;
using iTrellis_ToDo.Core.Services;
using iTrellis_ToDo.Infrastructure.Data;

namespace iTrellis_ToDo.Controllers
{
    public class ToDoListsController : Controller
    {
        private ToDoListsModel todoListsModel;
        private readonly IQueryToDoLists _iqueryToDoLists;
        private ToDoListService _todoListService;

        public ToDoListsController(IQueryToDoLists queryToDoLists)
        {
            _iqueryToDoLists = queryToDoLists;
            _todoListService = new ToDoListService(_iqueryToDoLists);
            todoListsModel = new ToDoListsModel(_todoListService.All());
        }

        public ToDoListsController()
            : this(new EfQueryToDoLists())
        {
        }

        public ActionResult Index()
        {       
            return View(todoListsModel);
        }



    }
}
