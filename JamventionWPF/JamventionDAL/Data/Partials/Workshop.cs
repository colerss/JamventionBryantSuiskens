﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public partial class Workshop : BasisModel
    {

        public override string this[string columnName]
        {
            get
            {
                string error = "";
                if (columnName == "Slots")
                {
                    if (Slots < 1)
                    {
                        error += "Slots mag niet 0 zijn";
                    }
                   
                }
                if (columnName == "Name")
                {
                    if (string.IsNullOrWhiteSpace(Name))
                    {
                        error += "Naam mag niet leeg zijn";
                    }

                }
                return error;
            }

        }
        public WorkshopTeacher MainTeacher => WorkshopTeachers.ToList().FirstOrDefault();
    }
}
