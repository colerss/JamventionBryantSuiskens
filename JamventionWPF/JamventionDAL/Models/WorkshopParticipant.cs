using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("WorkshopParticipants", Schema = "JAM")]
    public class WorkshopParticipant
    {

        [Key]
        public int WorkshopParticipantID { get; set; }
        public int GuestID { get; set; }
        public int WorkshopID { get; set; }

        //navprops

        public Guest Guest { get; set; }
        public Workshop Workshop { get; set; }
    }
}
