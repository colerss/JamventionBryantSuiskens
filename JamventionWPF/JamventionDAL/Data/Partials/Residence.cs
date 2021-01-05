using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public partial class Residence : BasisModel
    {
        public override string this[string columnName]
        {
            get
            {
                string error = "";
                if (columnName == "Address")
                {
                    if (string.IsNullOrWhiteSpace(Address))
                    {
                        error += "address mag niet leeg zijn";
                    }
                }
                if (columnName == "City")
                {
                    if (string.IsNullOrWhiteSpace(City))
                    {
                        error += "Stad mag niet leeg zijn";
                    }
                }

                return error;
            }

        }
    }
}
