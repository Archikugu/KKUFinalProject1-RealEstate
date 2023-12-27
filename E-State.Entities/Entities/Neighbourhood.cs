using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_State.Entities.Entities
{
    public class Neighbourhood
    {
        [Key]
        public int NeighbourhoodId { get; set; }
        public string NeighbourhoodName { get; set; }
        public int NeighbourhoodKey { get; set; }
        public bool Status { get; set; }

        public int DistrictKey { get; set; }
        public virtual District District { get; set; }
    }
}
