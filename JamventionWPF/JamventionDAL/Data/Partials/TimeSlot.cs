﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    public partial class TimeSlot
    {
        public string FullTime => StartTime + " - " + EndTime;

        public string DayFullTime => Day.DayOfWeek + " " + FullTime;
    }
}
