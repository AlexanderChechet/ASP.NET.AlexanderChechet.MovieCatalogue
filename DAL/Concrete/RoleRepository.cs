using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Concrete
{
    public class RoleRepository : IRoleRepository
    {
        private DbContext context;

        public RoleRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            return context.Set<Roles>().Select(role => new DalRole()
            {
                Id = role.Id,
                RoleName = role.UserRole
            });
        }

        public DalRole GetById(int id)
        {
            var role = context.Set<Roles>().Where(x => x.Id == id).FirstOrDefault();
            return new DalRole()
            {
                Id = role.Id,
                RoleName = role.UserRole
            };
        }

        public DalRole GetByPredicate(System.Linq.Expressions.Expression<Func<DalRole, bool>> expr)
        {
            throw new NotImplementedException();
        }

        public void Create(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
