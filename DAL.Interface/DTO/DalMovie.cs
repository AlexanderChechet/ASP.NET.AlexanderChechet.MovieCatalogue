using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class DalMovie : IEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public int Year { get; set; }
        
        public int Length { get; set; }

        public float Mark { get; set; }

        public int Budget { get; set; }

        public string Producer { get; set; }

        public byte[] Picture { get; set; }

        public byte[] Data { get; set; }
    }
}
