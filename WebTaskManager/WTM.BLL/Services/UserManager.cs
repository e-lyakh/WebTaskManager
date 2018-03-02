using System;
using System.Collections.Generic;
using AutoMapper;
using WTM.DAL.Entities;
using WTM.DAL.Interfaces;
using WTM.BLL.DTO;
using WTM.BLL.Infrastructure;
using WTM.BLL.Interfaces;


namespace WTM.BLL.Services
{
    public class UserManager : IUserManager
    {
        IUnitOfWork db { get; set; }

        public UserManager(IUnitOfWork uow)
        {
            db = uow;
        }

        public void CreateUser(UserDTO userDTO)
        {
            User user = new User
            {
                Name = userDTO.Name,
                Last_Name = userDTO.Last_Name,
                Login = userDTO.Login,
                Password = userDTO.Password, // How to transfer encrypted ?
                Email = userDTO.Email,
                Language = userDTO.Language,
                Is_Email_Notified = userDTO.Is_Email_Notified,
                Registration_Date = userDTO.Registration_Date,
                Last_Visit_Date = userDTO.Last_Visit_Date
            };
            db.Users.Create(user);
            db.Save();
        }

        public UserDTO GetUser(int? id)
        {
            if (id == null)
                throw new ValidationException("Id of User is not set", "");
            var user = db.Users.Get(id.Value);
            if (user == null)
                throw new ValidationException("User is not found (to get)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            return Mapper.Map<User, UserDTO>(user);
        }

        public void UpdateUser(UserDTO userDTO)
        {
            var user = db.Users.Get(userDTO.Id);
            if (user == null)
                throw new ValidationException("User is not found (to update)", "");
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            db.Users.Update(user);
            db.Save();
        }

        public void DeleteUser(UserDTO userDTO)
        {
            User user = db.Users.Get(userDTO.Id);
            if (user == null)
                throw new ValidationException("User is not found (to delete)", "");
            db.Users.Delete(user.Id);
            db.Save();
        }                

        public IEnumerable<UserDTO> GetUsers()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
            return Mapper.Map<IEnumerable<User>, List<UserDTO>>(db.Users.GetAll());
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
