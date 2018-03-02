

namespace WTM.BLL.DTO
{
    public class SubtaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order_In_List { get; set; }
        public bool Is_Completed { get; set; }
        public int Task_Id { get; set; }
    }
}
