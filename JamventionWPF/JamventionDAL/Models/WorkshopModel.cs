using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("WorkshopModels", Schema = "JAM")]
    public class WorkshopModel
    {
        [Key]
        public int WorkshopModelID { get; set; }
        [ForeignKey("Model")]
        public int ModelID { get; set; }
        public int WorkshopID { get; set; }

        public Guest Model { get; set; }
        public Workshop Workshop { get; set; }
    }
}
