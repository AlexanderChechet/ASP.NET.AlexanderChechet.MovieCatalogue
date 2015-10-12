using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IUserService
    {
        UserEntity GetUser(int id);
        UserEntity GetUserByName(string name);
        IEnumerable<UserEntity> GetAllUsers();
        void AddUser(UserEntity user);
        void UpdateUser(UserEntity user);
        void DeleteUser(UserEntity user);
    }
}
