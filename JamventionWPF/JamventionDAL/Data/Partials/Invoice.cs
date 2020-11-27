using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public partial class Invoice
    {

        [NotMapped]
        public string RemainingCosts
        {
            get
            {
                if (Payments.Count == 0)
                {
                    return TicketType.TicketPrice.ToString("C");
                }
                else
                {
                    decimal subtotal = 0;
                    foreach (Payment payment in Payments)
                    {
                        subtotal += payment.Amount;
                    }
                    return (TicketType.TicketPrice - subtotal).ToString("C");
                }
            }
        }
        [NotMapped]
        public bool IsPayedOff
        {
            get
            {
                return int.Parse(RemainingCosts) < 1;
            }
        }
    }
}
