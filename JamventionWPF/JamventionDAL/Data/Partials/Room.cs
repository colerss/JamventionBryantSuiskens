using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public partial class Room : BasisModel
    {
        public override string this[string columnName]
        {
            get
            {
                string error = "";

              
                if (columnName == "Beds")
                {
                    if (Beds <= 0)
                    {
                        error += "bedden moet meer dan 0 zijn!";
                    }
                }
                return error;
            }
        }
        [NotMapped]
        public int BedsFilled
        {
            get
            {
                return RoomOccupancy.Count();
            }
        }
        [NotMapped]
        public bool BedsFull
        {
            get
            {
                return BedsFilled == Beds;
            }
        }
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
        public override string this[string columnName]
        {
            get
            {
                string error = "";
                if (columnName == "Beds")
                {
                    if (Beds <= 0)
                    {
                        error += "bedden moet meer dan 0 zijn!";
                    }
                }
                if (columnName == "RoomDescription")
                {
                    if (string.IsNullOrWhiteSpace(RoomDescription))
                    {
                        error += "Kamernaam mag niet leeg zijn";
                    }
                }
                return error;
            }
        }
        public override string ToString()
        {
            return RoomDescription;
        }
    }
}
