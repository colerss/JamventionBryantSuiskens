using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public partial class Room
    {
       
    }
    public partial class LocalRoom
    {
        [NotMapped]
        public string RoomNameLong
        {
            get
            {
                return RoomCode + " " + RoomType.TypeName;
            }
        }
        public override string ToString()
        {
            return RoomNameLong;
        }
    }
    public partial class OtherRoom
    {
        public override string ToString()
        {
            return RoomDescription;
        }
    }
}
