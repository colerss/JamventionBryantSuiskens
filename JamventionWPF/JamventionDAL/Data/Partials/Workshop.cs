using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public partial class Workshop
    {
        public WorkshopTeacher MainTeacher => WorkshopTeachers.SingleOrDefault();
    }
}
