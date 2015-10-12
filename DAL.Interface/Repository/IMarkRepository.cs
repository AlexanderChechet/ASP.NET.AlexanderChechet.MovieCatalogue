using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IMarkRepository : IRepository<DalMark>
    {
        DalMark GetUserMarks(int id);
        DalMark GetMovieMarks(int id);
        DalMark GetUserMovieMark(int userId, int movieId);
    }
}
