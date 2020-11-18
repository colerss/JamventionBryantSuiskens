using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("GuestRoles", Schema = "JAM")]
    public class GuestRole
    {
        [Key]
        public int RoleID { get; set; }
        [Required]
        public string RoleName { get; set; }

        public ICollection<Guest> Guests { get; set; }
    }
}
