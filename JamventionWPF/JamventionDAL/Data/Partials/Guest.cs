using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public partial class Guest : BasisModel
    {

        public override string this[string columnName] {
            get
            {

                string error = "";
                if (columnName == "EmailAddress")
                {
                    Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                    if (!regex.IsMatch(EmailAddress))
                    {
                        error += "Email addresss is een foutief formaat!\n";
                    }
                   
                };
                return error;
            }
        }
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}
