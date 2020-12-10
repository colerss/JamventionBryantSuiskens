using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("AdminKeys", Schema = "JAM")]
    public class AdminKeys
    {
        [Key]
        public int KeyID { get; set; }
        [Required]
        public string HashedPassword { get; set; }
    }
}
