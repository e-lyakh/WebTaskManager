﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WtmDb : DbContext
    {
        public WtmDb()
            : base("name=WtmDb")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Doer> Doers { get; set; }
        public virtual DbSet<ListFilter> ListFilters { get; set; }
        public virtual DbSet<RepeatTerm> RepeatTerms { get; set; }
        public virtual DbSet<Subtask> Subtasks { get; set; }
        public virtual DbSet<TaskFile> TaskFiles { get; set; }
        public virtual DbSet<TaskItem> TaskItems { get; set; }
        public virtual DbSet<TaskList> TaskLists { get; set; }
        public virtual DbSet<TaskPriority> TaskPriorities { get; set; }
        public virtual DbSet<TaskSchedule> TaskSchedules { get; set; }
        public virtual DbSet<TaskStatus> TaskStatus1 { get; set; }
        public virtual DbSet<TaskTag> TaskTags { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
