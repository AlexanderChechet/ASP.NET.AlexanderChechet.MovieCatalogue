using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRoleRepository roleRepository;

        public RoleService(IUnitOfWork uof, IRoleRepository rr)
        {
            unitOfWork = uof;
            roleRepository = rr;
        }


        public RoleEntity GetUserRole(UserEntity user)
        {
            return roleRepository.GetById(user.RoleId).ToBllRole();
        }

        public IEnumerable<RoleEntity> GetAllRoles()
        {
            return roleRepository.GetAll().Select(x => x.ToBllRole());
        }
    }
}
