using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class SearchParams
    {
        public SearchParams(bool year, bool producer, bool description)
        {
            ByYear = year;
            ByProducer = producer;
            ByDescription = description;
        }

        public bool ByYear { get; set; }
        public bool ByDescription { get; set; }
        public bool ByProducer { get; set; }
    }
}
