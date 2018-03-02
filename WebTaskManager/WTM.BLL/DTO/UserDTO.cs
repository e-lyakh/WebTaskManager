using System;


namespace WTM.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Language { get; set; }
        public bool? Is_Email_Notified { get; set; }
        public DateTime Registration_Date { get; set; }
        public DateTime Last_Visit_Date { get; set; }
    }
}
