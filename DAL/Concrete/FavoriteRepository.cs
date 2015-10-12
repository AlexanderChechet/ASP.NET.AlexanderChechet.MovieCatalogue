using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.DTO;
using DAL.Interface.Repository;
using ORM;

namespace DAL.Concrete
{
    public class FavoriteRepository : IFavoriteRepository 
    {
        private DbContext context;

        public FavoriteRepository(DbContext context)
        {
            this.context = context;
        }

        public DalFavorite GetFavorites(int id)
        {
            var result = new DalFavorite()
            {
                Target = id,
                Movies = context.Set<Favorites>().Where(x => x.UserId == id).Select(x => x.MovieId).ToArray()
            };
            return result;
        }

        public IEnumerable<DalFavorite> GetAll()
        {
            return context.Set<Favorites>().Select(x => new DalFavorite()
                {
                    Id = x.Id,
                    UserId = x.UserId,
                    MovieId = x.MovieId
                });
        }

        public DalFavorite GetById(int id)
        {
            var result = context.Set<Favorites>().Where(x => x.Id == id).Single();
            return new DalFavorite()
            {
                Id = result.Id,
                UserId = result.UserId,
                MovieId = result.MovieId
            };
        }

        public DalFavorite GetByPredicate(System.Linq.Expressions.Expression<Func<DalFavorite, bool>> expr)
        {
            throw new NotImplementedException();
        }

        public void Create(DalFavorite entity)
        {
            var favorite = new Favorites()
            {
                UserId = entity.UserId,
                MovieId = entity.MovieId
            };
            context.Set<Favorites>().Add(favorite);
            context.SaveChanges();
        }

        public void Delete(DalFavorite entity)
        {
            var result = context.Set<Favorites>().Where(x => x.UserId == entity.UserId && x.MovieId == entity.MovieId).Single();
            context.Set<Favorites>().Remove(result);
            context.SaveChanges();
        }

        public void Update(DalFavorite entity)
        {
            throw new NotImplementedException();    
        }
    }
}
