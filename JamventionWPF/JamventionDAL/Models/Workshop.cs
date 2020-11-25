﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    [Table("Workshops", Schema = "JAM")]
    public class Workshop
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkshopID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int TimeslotID { get; set; }
        [Required]
        public int LocatieID { get; set; }
        public int Slots { get; set; }

        public ICollection<WorkshopModel> WorkshopModels { get; set; }
        public ICollection<WorkshopParticipant> WorkshopParticipants { get; set; }
        public ICollection<WorkshopTeacher> WorkshopTeachers { get; set; }
        public Location Location { get; set; }
    }
}
