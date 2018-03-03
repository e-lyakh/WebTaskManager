using System;

namespace WTM.BLL.DTO
{
    public class ListFilterDTO
    {
        public int Id { get; set; }
        public bool Is_Show_Completed { get; set; }
        public bool Is_Ordered_Term { get; set; }
        public bool Is_Ordered_Prior { get; set; }
        public bool Is_Ordered_Tag { get; set; }
        public DateTime? Selected_From_Date { get; set; }
        public DateTime? Selected_To_Date { get; set; }
        public int? Selected_Prior_Id { get; set; }
        public int Selected_Tag_Id { get; set; }
        public bool Is_Only_Favorites { get; set; }
    }
}
