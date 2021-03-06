﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("Residences", Schema = "JAM")]
    public partial class Residence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResidenceID { get; set; }
        [MaxLength(10)]
        public string PostalCode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int NationalityID { get; set; }


        //navprops
        public ICollection<Guest> Guest { get; set; }
        public Nationality Nationality { get; set; }
    }
}
