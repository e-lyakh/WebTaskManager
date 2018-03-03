using System;

namespace WebTaskManager.Models
{
    public class TaskItemVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int List_Id { get; set; }
        public int Order_In_List { get; set; }
        public bool Is_Favorite { get; set; }
        public string Description { get; set; }
        public DateTime Creation_Date { get; set; }
        public DateTime Delete_Date { get; set; }
        public int Schedule_Id { get; set; }
        public int Priority_Id { get; set; }
        public int Tag_Id { get; set; }
        public int Status_Id { get; set; }
        public int User_Id { get; set; }
        public int Doer_Id { get; set; }
    }
}
