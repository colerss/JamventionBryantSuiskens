using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public partial class Guest
    {
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}
