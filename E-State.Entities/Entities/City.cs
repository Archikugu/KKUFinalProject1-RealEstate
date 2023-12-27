using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_State.Entities.Entities
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CityKey { get; set; }

        public bool Status { get; set; }
        public virtual List<District> Districts { get; set; }
    }
}
