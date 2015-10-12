using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IMovieService
    {
        MovieEntity GetMovie(int id);
        IEnumerable<MovieEntity> GetAllMovies();
        IEnumerable<MovieEntity> SearchMovies(string value, SearchParams search);
        void AddMovie(MovieEntity movie);
        void UpdateMovie(MovieEntity movie);
        void DeleteMovie(MovieEntity movie);
    }
}
