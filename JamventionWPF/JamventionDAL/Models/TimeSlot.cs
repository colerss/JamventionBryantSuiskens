using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("TimeSlots", Schema = "JAM")]
    public partial class TimeSlot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeSlotID { get; set; }
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }


//navprops
        public ICollection<Workshop> Workshops { get; set; }
    }
}
