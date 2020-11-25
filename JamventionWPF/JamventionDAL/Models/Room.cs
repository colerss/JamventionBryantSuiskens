using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("Rooms", Schema = "JAM")]
    public partial class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }
        public int Beds { get; set; }
        public ICollection<Guest> RoomOccupancy { get; set; }

    }
    [Table("LocalRooms", Schema = "JAM")]
    public partial class LocalRoom : Room
    {
        public int RoomTypeID { get; set; }
        [Required]
        [MaxLength(5)]
        public string RoomCode { get; set; }
        [Required]
        [MaxLength(20)]
        public string RoomColor { get; set; }



        public RoomType RoomType { get; set; }
    }

    [Table("OtherRooms", Schema = "JAM")]
    public partial class OtherRoom : Room
    {
        public string RoomDescription { get; set; }
    }
}
