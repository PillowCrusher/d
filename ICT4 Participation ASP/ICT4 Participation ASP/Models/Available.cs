using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4_Participation_ASP.Models
{
    public class Available
    {
        public string DayName { get; protected set; }
        public int DayPart { get; protected set; }

        public Available(string dayName, int dayPart)
        {
            this.DayName = dayName;
            this.DayPart = dayPart;
        }
    }
}