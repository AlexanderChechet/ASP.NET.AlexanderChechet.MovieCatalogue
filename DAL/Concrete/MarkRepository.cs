using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using ORM;

namespace DAL.Concrete
{
    public class MarkRepository : IMarkRepository
    {
        private DbContext context;

        public MarkRepository(DbContext context)
        {
            this.context = context;
        }

        public DalMark GetUserMarks(int id)
        {
            var movieList = context.Set<UserMovieMarks>().Where(x => x.IdUser == id);
            DalMark result = new DalMark()
            {
                Marks = new Dictionary<int, int>(),
                Target = id
            };
            foreach (var item in movieList)
            {
                result.Marks[item.IdMovie] = item.Mark;
            } 
            return result;
        }

        public DalMark GetMovieMarks(int id)
        {
            var userList = context.Set<UserMovieMarks>().Where(x => x.IdMovie == id);
            DalMark result = new DalMark()
                {
                    Marks = new Dictionary<int, int>(),
                    Target = id
                };
            foreach (var item in userList)
            {
                result.Marks[item.IdUser] = item.Mark;
            } 
            return result;
        }

        public DalMark GetUserMovieMark(int userId, int movieId)
        {
            var mark = context.Set<UserMovieMarks>().Where(x => x.IdUser == userId && x.IdMovie == movieId).FirstOrDefault();
            return new DalMark()
                {
                    Mark = mark == null ? 0 : mark.Mark,
                    UserId = userId,
                    MovieId = movieId,
                    Id = mark == null ? 0 : mark.Id
                };
        }

        public IEnumerable<DalMark> GetAll()
        {
            return context.Set<UserMovieMarks>().Select(x => new DalMark()
                {
                    Id = x.Id,
                    UserId = x.IdUser,
                    MovieId = x.IdMovie,
                    Mark = x.Mark
                });
        }

        public DalMark GetById(int id)
        {
            var result = context.Set<UserMovieMarks>().Where(x => x.Id == id).Single();
            return new DalMark()
            {
                Id = result.Id,
                MovieId = result.IdMovie,
                UserId = result.IdUser,
                Mark = result.Mark
            };
        }

        public DalMark GetByPredicate(System.Linq.Expressions.Expression<Func<DalMark, bool>> expr)
        {
            throw new NotImplementedException();
        }

        public void Create(DalMark entity)
        {
            var mark = new UserMovieMarks()
            {
                IdMovie = entity.MovieId,
                IdUser = entity.UserId,
                Mark = entity.Mark
            };
            context.Set<UserMovieMarks>().Add(mark);
            context.SaveChanges();
        }

        public void Delete(DalMark entity)
        {
            var result = context.Set<UserMovieMarks>().Where(x => x.Id == entity.Id).Single();
            context.Set<UserMovieMarks>().Remove(result);
            context.SaveChanges();
        }

        public void Update(DalMark entity)
        {
            var mark = context.Set<UserMovieMarks>().Where(x => x.Id == entity.Id).FirstOrDefault();
            mark.Mark = entity.Mark;
            mark.IdMovie = entity.MovieId;
            mark.IdUser = entity.UserId;
            context.Set<UserMovieMarks>().Attach(mark);
            var entry = context.Entry(mark);
            //entry.Property(x => x.Movies).IsModified = false;
            //entry.Property(x => x.Users).IsModified = false;
            entry.Property(x => x.Mark).IsModified = true;
            context.SaveChanges();
        }
    }
}
