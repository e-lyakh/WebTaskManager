using System.Collections.Generic;
using WTM.BLL.DTO;


namespace WTM.BLL.Interfaces
{
    public interface IUserManager
    {
        void CreateUser(UserDTO userDTO);       
        UserDTO GetUser(int? id);
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(UserDTO userDTO);
        IEnumerable<UserDTO> GetUsers();
        void Dispose();
    }
}
