using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("Locations", Schema = "JAM")]
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public string LocationName { get; set; }

        public ICollection<Workshop> Workshops { get; set; }
    }
}
