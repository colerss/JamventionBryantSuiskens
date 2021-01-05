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
                if (columnName == "EmailAddress" && EmailAddress != null)
                {
                    Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                    if (!regex.IsMatch(EmailAddress))
                    {
                        error += "Email addresss is een foutief formaat!\n";
                    }
                    if (string.IsNullOrWhiteSpace(EmailAddress))
                    {
                        error += "Emailaddress mag niet leeg zijn";
                    }
                   
                };
                if (columnName == "FirstName" && FirstName != null)
                {
                    if (string.IsNullOrWhiteSpace(FirstName))
                    {
                        error += "Voornaam mag niet leeg zijn";
                    }
                }
                if (columnName == "LastName" && LastName != null)
                {
                    if (string.IsNullOrWhiteSpace(LastName))
                    {
                        error += "achternaam mag niet leeg zijn";
                    }
                }
                if (columnName == "TelephoneNr" && TelephoneNr != null)
                {
                    if (string.IsNullOrWhiteSpace(TelephoneNr))
                    {
                        error += "telefoonnummer mag niet leeg zijn";
                    }
                }
                return error;
            }
        }
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
    }
}
