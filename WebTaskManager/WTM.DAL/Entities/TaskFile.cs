//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WTM.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaskFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Guid { get; set; }
        public System.DateTime Attach_Date { get; set; }
        public int Task_Id { get; set; }
    
        public virtual TaskItem TaskItem { get; set; }
    }
}