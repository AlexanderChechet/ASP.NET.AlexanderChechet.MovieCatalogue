using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using BLL.Mappers;
using DAL.Interface.Repository;

namespace BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMovieRepository movieRepository;

        public MovieService(IUnitOfWork uow, IMovieRepository mr)
        {
            unitOfWork = uow;
            movieRepository = mr;
        }

        public MovieEntity GetMovie(int id)
        {
            return movieRepository.GetById(id).ToBllMovie();
        }

        public IEnumerable<MovieEntity> GetAllMovies()
        {
            return movieRepository.GetAll().Select(movie => movie.ToBllMovie());
        }

        public IEnumerable<MovieEntity> SearchMovies(string value, SearchParams search)
        {
            var result = movieRepository.GetByTitle(value);
            if (search.ByYear)
            {
                int year;
                if (int.TryParse(value, out year))
                    result = result.Union(movieRepository.GetByYear(year));
            }
            if (search.ByDescription)
            {
                result = result.Union(movieRepository.GetByDescription(value));
            }
            if (search.ByProducer)
            {
                result = result.Union(movieRepository.GetByProducer(value));
            }
            return result.Select(x => x.ToBllMovie());
        }

        public void AddMovie(MovieEntity movie)
        {
            movieRepository.Create(movie.ToDalMovie());
        }

        public void UpdateMovie(MovieEntity movie)
        {
            movieRepository.Update(movie.ToDalMovie());
        }

        public void DeleteMovie(MovieEntity movie)
        {
            movieRepository.Delete(movie.ToDalMovie());
        }
    }
}
