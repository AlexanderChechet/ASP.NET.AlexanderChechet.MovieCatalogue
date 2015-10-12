using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class MarkEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int MovieId { get; set; }

        public int Mark { get; set; }

        public int Target { get; set; }   //User or film ID

        public Dictionary<int, int> Marks { get; set; }   //Dictionary by ids
    }
}
