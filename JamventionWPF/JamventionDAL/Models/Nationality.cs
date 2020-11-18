using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("Nationalities", Schema = "JAM")]
    public class Nationality
    {
        [Key]
        public int NationalityID { get; set; }
        [Required]
        public string CountryName { get; set; }

        public ICollection<Residence> ResidencesInCountry { get; set; }
    }
}
