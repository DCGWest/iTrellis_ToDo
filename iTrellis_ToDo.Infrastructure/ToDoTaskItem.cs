//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iTrellis_ToDo.Infrastructure
{
    using System;
    using System.Collections.Generic;
    
    public partial class ToDoTaskItem
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string ItemDetails { get; set; }
        public bool ItemIsDeleted { get; set; }
        public System.DateTime ItemCreatedDate { get; set; }
        public Nullable<System.DateTime> ItemCompletedDate { get; set; }
        public Nullable<System.DateTime> ItemUpdatedDate { get; set; }
        public int ToDoListID { get; set; }
        public Nullable<System.DateTime> ItemDueDate { get; set; }
    
        public virtual ToDoList ToDoList { get; set; }
    }
}
