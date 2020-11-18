using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public class Guest
    {
        [Key]
        public int GuestID { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]  
        public int ResidenceID { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmailAddress { get; set; }
        [MaxLength(15)]
        public string TelephoneNr { get; set; }
        [Required]
        public bool IsVegetarian { get; set; }
      
        [Required]
        public int RoleID { get; set; }
        [Required]
        public int InvoiceId { get; set; }

        //navprops

        public Residence Residence { get; set; }
        public GuestRole GuestRole { get; set; }
        public Invoice Invoice { get; set; }
        public ICollection<WorkshopModel> WorkshopModels { get; set; }
        public ICollection<WorkshopParticipant> WorkshopParticipants { get; set; }
        public Workshop WorkshopTeacher { get; set; }


    }
}
