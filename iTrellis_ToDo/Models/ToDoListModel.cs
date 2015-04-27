using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using iTrellis_ToDo.Core.Model;

namespace iTrellis_ToDo.Models
{
    public class ToDoListsModel
    {
        private List<ToDoListModel> todolistmodels;
        public string ErrorMessage { get; set; }
        private bool success;

        public List<ToDoListModel> ToDoListModels
        {
            get
            {
                return todolistmodels;
            }
            set
            {
                value = todolistmodels;
            }
        }

        public bool Success
        {
            get
            {
                return success;
            }
        }

        public ToDoListsModel(ToDoListResponse todoListResponse)
        {
            success = todoListResponse.Success;
            if (success)
            {
                todolistmodels = new List<ToDoListModel>();
                foreach (var todoList in todoListResponse.ToDoLists)
                {
                    ToDoListModel todolistmodel = new ToDoListModel(todoList);
                    todolistmodel.DateCreated = todoList.DateCreated;
                    todolistmodel.ListName = todoList.ListName;
                    todolistmodel.UserName = todoList.CreatedByUserName;
                    todolistmodel.ID = todoList.ID;
                    todolistmodels.Add(todolistmodel);
                }
            }
            else
            {
                this.ErrorMessage = todoListResponse.ErrorMessage;
            }
        }
    }

    public class ToDoListModel
    {
        public int ID { get; set; }
        public List<ToDoListItemModel> ListItems { get; set; }

        public string ErrorMessage { get; set; }
        [Display(Name = "List Name")]
        [Required]
        public string ListName { get; set; }

        [Display(Name = "Date Created")]
        [Required]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Created By")]
        [Required]
        public string UserName { get; set; }

        [Required]
        private int UserID { get; set; }

        public ToDoListModel(Core.Model.ToDoList coreToDoList)
        {
            if (coreToDoList != null)
            {
                this.ID = coreToDoList.ID;
                this.DateCreated = coreToDoList.DateCreated;
                this.ListName = coreToDoList.ListName;
                this.UserName = coreToDoList.CreatedByUserName;
                this.ListItems = new List<ToDoListItemModel>();
                foreach (var coreitem in coreToDoList.TaskItems)
                {
                    ToDoListItemModel itemModel = new ToDoListItemModel();
                    itemModel.ID = coreitem.ID;
                    itemModel.ItemCompletedDate = coreitem.ItemCompletedDate;
                    itemModel.ItemCreatedDate = coreitem.ItemCreatedDate;
                    itemModel.ItemDetails = coreitem.ItemDetails;
                    itemModel.ItemIsDeleted = coreitem.ItemIsDeleted;
                    itemModel.ItemName = coreitem.ItemName;
                    itemModel.ItemUpdatedDate = coreitem.ItemUpdatedDate;
                    itemModel.ItemDueDate = coreitem.ItemDueDate;
                    this.ListItems.Add(itemModel);
                }
            }
            else
            {
                this.ErrorMessage = "List not found";
            }
        }
    }

    public class ToDoListItemModel
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string ItemDetails { get; set; }
        public bool ItemIsDeleted { get; set; }
        public DateTime ItemCreatedDate { get; set; }
        public DateTime? ItemCompletedDate { get; set; }
        public DateTime? ItemUpdatedDate { get; set; }
        public DateTime? ItemDueDate { get; set; }
    }
}