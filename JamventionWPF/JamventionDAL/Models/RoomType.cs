using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("RoomTypes", Schema = "JAM")]
    public class RoomType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomTypeID { get; set; }
        [Required]
        [MaxLength(30)]
        public string TypeName { get; set; }

        public ICollection<LocalRoom> LocalRooms { get; set; }
    }
}
