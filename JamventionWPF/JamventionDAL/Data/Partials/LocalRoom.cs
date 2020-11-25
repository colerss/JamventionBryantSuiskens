using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public partial class LocalRoom
    {
        public string RoomName { get
            {
                return RoomCode + " "+RoomType.TypeName;
            } }
    }
}
