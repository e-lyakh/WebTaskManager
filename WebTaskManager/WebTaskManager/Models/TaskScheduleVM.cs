using System;

namespace WebTaskManager.Models
{
    public class TaskScheduleVM
    {
        public int Id { get; set; }
        public DateTime? Start_Term { get; set; }
        public DateTime? End_Term { get; set; }
        public bool? Is_Reminder_On { get; set; }
        public DateTime? Reminder_Time { get; set; }
        public int RepeatTerm_Id { get; set; }
    }
}