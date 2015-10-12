using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Services;
using BLL.Interface.Entities;
using DAL.Interface.Repository;
using BLL.Mappers;


namespace BLL.Services
{
    public class MarkService : IMarkService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMarkRepository markRepository;

        public MarkService(IUnitOfWork uof, IMarkRepository mr)
        {
            unitOfWork = uof;
            markRepository = mr;
        }

        public MarkEntity GetUserMarks(int id)
        {
            return markRepository.GetUserMarks(id).ToBllMark();
        }

        public MarkEntity GetMovieMarks(int id)
        {
            return markRepository.GetMovieMarks(id).ToBllMark();
        }

        public MarkEntity GetUserMovieMark(int userId, int movieId)
        {
            return markRepository.GetUserMovieMark(userId, movieId).ToBllMark(); 
        }

        public void AddUserMovieMark(MarkEntity mark)
        {
            markRepository.Create(mark.ToDalMark());
        }

        public void UpdateUserMovieMark(MarkEntity mark)
        {
            markRepository.Update(mark.ToDalMark());
        }

        public void DeleteUserMovieMark(MarkEntity mark)
        {
            markRepository.Delete(mark.ToDalMark());
        }
    }
}
