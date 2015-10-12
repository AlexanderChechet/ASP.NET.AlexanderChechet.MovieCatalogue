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
    public class UserRepository : IUserRepository
    {
        private DbContext context;

        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public DalUser GetById(int id)
        {
            var user = context.Set<Users>().FirstOrDefault(x => x.Id == id);
            return new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,
                RoleId = user.Role
            };
        }

        public DalUser GetByName(string name)
        {
            var user = context.Set<Users>().Where(x => x.Login.Equals(name)).FirstOrDefault();
            return new DalUser()
                {
                    Id = user.Id,
                    Login = user.Login,
                    Name = user.Name,
                    Password = user.Password,
                    RoleId = user.Role
                };
        }

        public IEnumerable<DalUser> GetAll()
        {
            var result = context.Set<Users>().Select(y => new DalUser()
                {
                    Id = y.Id,
                    Login = y.Login,
                    Name = y.Name,
                    Password = y.Password,
                    RoleId = y.Role
                }).AsEnumerable();
            return result;
        }

        public DalUser GetByPredicate(System.Linq.Expressions.Expression<Func<DalUser, bool>> expr)
        {
            throw new NotImplementedException();
        }

        public void Create(DalUser entity)
        {
            var user = new Users()
            {
                Name = entity.Name,
                Login = entity.Login,
                Password = entity.Password,
                Role = entity.RoleId
            };
            context.Set<Users>().Add(user);
            context.SaveChanges();
        }

        public void Delete(DalUser entity)
        {
            var user = new Users()
            {
                Id = entity.Id,
                Name = entity.Name,
                Login = entity.Login,
                Password = entity.Password,
                Role = entity.RoleId
            };
            user = context.Set<Users>().Single(u => u.Id == user.Id);
            context.Set<Users>().Remove(user);
            context.SaveChanges();
        }

        public void Update(DalUser entity)
        {
            var user = new Users()
            {
                Id = entity.Id,
                Name = entity.Name,
                Login = entity.Login,
                Password = entity.Password,
                Role = entity.RoleId
            };
            context.Set<Users>().Attach(user);
            var entry = context.Entry(user);
            entry.Property(x => x.Login).IsModified = true;
            entry.Property(x => x.Password).IsModified = true;
            entry.Property(x => x.Name).IsModified = true;
            entry.Property(x => x.Role).IsModified = true;
            context.SaveChanges();
        }
    }
}
