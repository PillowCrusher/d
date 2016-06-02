using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4_Participation_MVC.Models
{
    public class Available
    {
        public DateTime TimeAvailable { get; protected set; }

        public Available(DateTime available)
        {
            this.TimeAvailable = available;
        }
    }
}