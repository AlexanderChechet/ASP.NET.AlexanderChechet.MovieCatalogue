using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalMark : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MovieId { get; set; }

        public int Mark { get; set; }

        public int Target { get; set; }

        public Dictionary<int, int> Marks { get; set; }
    }
}
