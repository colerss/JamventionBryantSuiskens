using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("TicketTypes", Schema = "JAM")]
    public class TicketType
    {
        [Key]
        public int TicketTypeID { get; set; }
        [Required]
        public string TicketNaam { get; set; }
        [Column(TypeName = "money")]
        public decimal TicketPrice { get; set; }
        public bool OnFriday { get; set; }
        public bool OnSaturday { get; set; }
        public bool OnSunday { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
