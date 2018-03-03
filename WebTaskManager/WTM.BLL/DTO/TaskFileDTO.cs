using System;

namespace WTM.BLL.DTO
{
    public class TaskFileDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Guid { get; set; }
        public DateTime Attach_Date { get; set; }
        public int Task_Id { get; set; }
    }
}
