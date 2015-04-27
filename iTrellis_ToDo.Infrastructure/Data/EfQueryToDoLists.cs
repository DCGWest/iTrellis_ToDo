using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using iTrellis_ToDo.Core.Interfaces;
using iTrellis_ToDo.Core.Model;
using System.Data.Entity;


namespace iTrellis_ToDo.Infrastructure.Data
{
    public class EfQueryToDoLists : IQueryToDoLists
    {
        public ToDoListResponse All()
        {
            ToDoListResponse todoListResponse = new ToDoListResponse();
            using (var context = new iTrellis_ToDoEntities())
            {
                foreach(ToDoList todoList in context.ToDoLists.Include(x => x.ToDoTaskItems).ToList())
                {
                    Core.Model.ToDoList coreToDoList = new Core.Model.ToDoList();
                    coreToDoList.ID = todoList.ID;
                    coreToDoList.CreatedByUserID = todoList.CreatedByUserID;
                    coreToDoList.CreatedByUserName = todoList.UserProfile.UserName;
                    coreToDoList.DateCreated = todoList.DateCreated;
                    coreToDoList.ListName = todoList.ListName;
                    foreach(var dataItem in todoList.ToDoTaskItems)
                    {
                        Core.Model.ToDoTaskItem coreItem = new Core.Model.ToDoTaskItem();
                        coreItem.ID = dataItem.ID;
                        coreItem.ItemCompletedDate = dataItem.ItemCompletedDate;
                        coreItem.ItemCreatedDate = dataItem.ItemCreatedDate;
                        coreItem.ItemDetails = dataItem.ItemDetails;
                        coreItem.ItemIsDeleted = dataItem.ItemIsDeleted;
                        coreItem.ItemName = dataItem.ItemName;
                        coreItem.ItemUpdatedDate = dataItem.ItemUpdatedDate;
                        coreItem.ItemDueDate = dataItem.ItemDueDate;
                        coreToDoList.TaskItems.Add(coreItem);
                    }
                    todoListResponse.ToDoLists.Add(coreToDoList);
                }
            }      
            return todoListResponse;
        }

        public ToDoListResponse CreateToDoList(Core.Model.ToDoList coreToDoList)
        {
            ToDoListResponse todoListResponse = new ToDoListResponse();
            using (var context = new iTrellis_ToDoEntities())
            {
                ToDoList dataToDoList = new ToDoList();
                dataToDoList.CreatedByUserID = coreToDoList.CreatedByUserID;
                dataToDoList.DateCreated = coreToDoList.DateCreated;
                dataToDoList.ID = coreToDoList.ID;
                dataToDoList.ListName = coreToDoList.ListName;
                context.ToDoLists.Add(dataToDoList);
                context.SaveChanges();
                coreToDoList.ID = dataToDoList.ID;
            }
            todoListResponse.ToDoLists = new List<Core.Model.ToDoList>();
            todoListResponse.ToDoLists.Add(coreToDoList);
            return todoListResponse;
        }



    }

    
}
