using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Services
{
    public interface IMarkService
    {
        MarkEntity GetUserMarks(int id);
        MarkEntity GetMovieMarks(int id);
        MarkEntity GetUserMovieMark(int userId, int movieId);
        void AddUserMovieMark(MarkEntity mark);
        void UpdateUserMovieMark(MarkEntity mark);
        void DeleteUserMovieMark(MarkEntity mark);
    }
}
