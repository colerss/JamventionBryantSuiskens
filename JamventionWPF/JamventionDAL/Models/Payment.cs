using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("Payments", Schema = "JAM")]
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public int InvoiceID { get; set; }

        public Invoice Invoice { get; set; }
    }
}
