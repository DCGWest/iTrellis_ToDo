using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTrellis_ToDo.Core.Model
{
    public class ToDoList
    {
        private int id;
        private string listname;
        private DateTime datecreated;
        private int createdbyuserid;
        private string createdbyusername;
        private List<ToDoTaskItem> taskitems;

        public ToDoList()
        {
            taskitems = new List<ToDoTaskItem>();
        }
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string ListName
        {
            get
            {
                return listname;
            }
            set
            {
                listname = value;
            }
        }

        public DateTime DateCreated
        {
            get
            {
                return datecreated;
            }
            set
            {
                datecreated = value;
            }
        }

        public int CreatedByUserID
        {
            get
            {
                return createdbyuserid;
            }
            set
            {
                value = createdbyuserid;
            }
        }

        public string CreatedByUserName
        {
            get
            {
                return createdbyusername;
            }
            set
            {
                value = createdbyusername;
            }
        }

        public List<ToDoTaskItem> TaskItems
        {
            get
            {
                return taskitems;
            }
            set
            {
                taskitems = value;
            }
        }

    }

    public class ToDoTaskItem
    {
        private int id;
        private string itemname;
        private string itemdetails;
        private bool itemisdeleted;
        private DateTime itemcreateddate;
        private DateTime? itemcompleteddate;
        private DateTime? itemupdateddate;
        private DateTime? itemduedate;

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string ItemName
        {
            get
            {
                return itemname;
            }
            set
            {
                itemname = value;
            }
        }

        public string ItemDetails
        {
            get
            {
                return itemdetails;
            }
            set
            {
                itemdetails = value;
            }
        }

        public bool ItemIsDeleted
        {
            get
            {
                return itemisdeleted;
            }
            set
            {
                itemisdeleted = value;
            }
        }

        public DateTime ItemCreatedDate
        {
            get
            {
                return itemcreateddate;
            }
            set
            {
                itemcreateddate = value;
            }
        }

        public DateTime? ItemCompletedDate
        {
            get
            {
                return itemcompleteddate;
            }
            set
            {
                itemcompleteddate = value;
            }
        }

        public DateTime? ItemUpdatedDate
        {
            get
            {
                return itemupdateddate;
            }
            set
            {
                itemupdateddate = value;
            }
        }

        public DateTime? ItemDueDate
        {
            get
            {
                return itemduedate;
            }
            set
            {
                itemduedate = value;
            }
        }
    }

    public class ToDoListResponse
    {
        public ToDoListResponse()
        {
            this.ToDoLists = new List<ToDoList>();
        }
        public List<ToDoList> ToDoLists { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
