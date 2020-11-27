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
    public partial class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceID { get; set; }
        [Required]
        public int DebitorNr { get; set; }
        public char InvoiceVariant { get; set; }
        [Required]
        public int TicketTypeID { get; set; }

        public ICollection<Payment> Payments { get; set; }
        //Toevoeging op vraag van klant; één invoice kan onder zeldzame omstandigheden door meerdere Deelnemers gedeeld worden
        public ICollection<Guest> Guests { get; set; }
        public TicketType TicketType { get; set; }


    }
}
