using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.Repository;
using DAL.Interface.DTO;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        private IUserRepository userRepository;

        public UserService(IUnitOfWork uow, IUserRepository ur)
        {
            unitOfWork = uow;
            userRepository = ur;
        }

        public UserEntity GetUser(int id)
        {
            return userRepository.GetById(id).ToBllUser();
        }

        public UserEntity GetUserByName(string name)
        {
            return userRepository.GetByName(name).ToBllUser();
        }

        public IEnumerable<UserEntity> GetAllUsers()
        {
            return userRepository.GetAll().Select(x => x.ToBllUser());
        }

        public void AddUser(UserEntity user)
        {
            userRepository.Create(user.ToDalUser());
            unitOfWork.Commit();
        }

        public void UpdateUser(UserEntity user)
        {
            userRepository.Update(user.ToDalUser());
            unitOfWork.Commit();
        }

        public void DeleteUser(UserEntity user)
        {
            userRepository.Delete(user.ToDalUser());
            unitOfWork.Commit();
        }
    }
}
