using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Interface.Repository;
using DAL.Interface.DTO;
using ORM;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace DAL.Concrete
{
    public class MovieRepository : IMovieRepository
    {
        private DbContext context;

        public MovieRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DalMovie> GetAll()
        {
            return context.Set<Movies>().Select(movie => new DalMovie()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Year = movie.Year,
                    Length = movie.Length,
                    Mark = (float)movie.Mark,
                    Producer = movie.Producer,
                    Budget = movie.Budget,
                    Picture = movie.Picture
                });
        }

        public DalMovie GetById(int id)
        {
            var result = context.Set<Movies>().First(movie => movie.Id == id);
            return new DalMovie()
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                Year = result.Year,
                Length = result.Length,
                Mark = (float)result.Mark,
                Producer = result.Producer,
                Budget = result.Budget,
                Picture = result.Picture
            };
        }

        public DalMovie GetByPredicate(Expression<Func<DalMovie, bool>> expr)
        {
            throw new NotImplementedException();
        }

        public void Create(DalMovie entity)
        {
            var movie = new Movies()
            {
                Title = entity.Title,
                Description = entity.Description,
                Year = entity.Year,
                Length = entity.Length,
                Mark = entity.Mark,
                Producer = entity.Producer,
                Budget = entity.Budget,
                Picture = entity.Picture,
                Data = entity.Data
            };
            context.Set<Movies>().Add(movie);
            context.SaveChanges();
        }

        public void Delete(DalMovie entity)
        {
            var movie = context.Set<Movies>().Single(mov => mov.Id == entity.Id);
            context.Set<Movies>().Remove(movie);
            context.SaveChanges();
        }

        public void Update(DalMovie entity)
        {
            var result = context.Set<Movies>().First(x => x.Id == entity.Id);
            result.Title = entity.Title;
            result.Description = entity.Description;
            result.Year = entity.Year;
            result.Length = entity.Length;
            result.Mark = entity.Mark;
            result.Producer = entity.Producer;
            result.Budget = entity.Budget;
            result.Picture = entity.Picture;
            result.Data = entity.Data;
            context.Set<Movies>().Attach(result);
            var entry = context.Entry(result);
            entry.Property(x => x.Title).IsModified = true;
            entry.Property(x => x.Description).IsModified = true;
            entry.Property(x => x.Year).IsModified = true;
            entry.Property(x => x.Length).IsModified = true;
            entry.Property(x => x.Mark).IsModified = true;
            entry.Property(x => x.Producer).IsModified = true;
            entry.Property(x => x.Budget).IsModified = true;
            //entry.Property(x => x.Data).IsModified = true;
            entry.Property(x => x.Picture).IsModified = true;
            context.SaveChanges();
        }

        public IEnumerable<DalMovie> GetByYear(int year)
        {
            return context.Set<Movies>().Where(movie => movie.Year == year).Select(movie => new DalMovie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Length = movie.Length,
                Mark = (float)movie.Mark,
                Producer = movie.Producer,
                Budget = movie.Budget,
                Picture = movie.Picture
            });
        }

        public IEnumerable<DalMovie> GetByTitle(string title)
        {
            return context.Set<Movies>().Where(movie => movie.Title.Contains(title)).Select(movie => new DalMovie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Length = movie.Length,
                Mark = (float)movie.Mark,
                Producer = movie.Producer,
                Budget = movie.Budget,
                Picture = movie.Picture
            });
        }

        public IEnumerable<DalMovie> GetByDescription(string description)
        {
            return context.Set<Movies>().Where(movie => movie.Description.Contains(description)).Select(movie => new DalMovie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Length = movie.Length,
                Mark = (float)movie.Mark,
                Producer = movie.Producer,
                Budget = movie.Budget,
                Picture = movie.Picture
            });
        }

        public IEnumerable<DalMovie> GetByProducer(string producer)
        {
            return context.Set<Movies>().Where(movie => movie.Producer.Contains(producer)).Select(movie => new DalMovie()
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Year = movie.Year,
                Length = movie.Length,
                Mark = (float)movie.Mark,
                Producer = movie.Producer,
                Budget = movie.Budget,
                Picture = movie.Picture
            });
        }

    }
}
