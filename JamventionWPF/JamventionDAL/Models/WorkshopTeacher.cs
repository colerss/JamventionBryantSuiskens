using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("WorkshopTeacher", Schema = "JAM")]
    public class WorkshopTeacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkshopParticipantID { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }
        public int WorkshopID { get; set; }

        //navprops

        public Guest Teacher { get; set; }
        public Workshop Workshop { get; set; }
    }
}
