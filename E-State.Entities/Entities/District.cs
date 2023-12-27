using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_State.Entities.Entities
{
    public class District
    {
        [Key]
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
        public int DistrictKey { get; set; }
        public bool Status { get; set; }

        public int CityKey { get; set; }
        public virtual City City { get; set; }
        public virtual List<Neighbourhood> Neighbourhoods { get; set; }
    }
}
