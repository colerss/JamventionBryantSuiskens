using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("Invoices", Schema = "JAM")]
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceID { get; set; }
        [Required]
        public int DebitorNr { get; set; }
        public char InvoiceVariant { get; set; }
        [Required]
        public int TicketTypeID { get; set; }

        public ICollection<Payment> Payments { get; set; }
        public TicketType TicketType { get; set; }


    }
}
