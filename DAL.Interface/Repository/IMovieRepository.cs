using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Repository
{
    public interface IMovieRepository : IRepository<DalMovie>
    {
        IEnumerable<DalMovie> GetByYear(int year);
        IEnumerable<DalMovie> GetByTitle(string title);
        IEnumerable<DalMovie> GetByDescription(string description);
        IEnumerable<DalMovie> GetByProducer(string producer);
    }
}
