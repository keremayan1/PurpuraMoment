using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CDate { get; set; }
        public DateTime? MDate { get; set; }
    }
}
