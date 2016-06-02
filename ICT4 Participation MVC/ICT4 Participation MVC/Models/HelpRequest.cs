using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4_Participation_MVC.Models
{
    public class HelpRequest
    {
        private DateTime dateTime1;
        private DateTime dateTime2;
        private TransportationType transportationType;
        private int v1;
        private string v2;
        private string v3;
        private string v4;
        private string v5;
        private bool v6;
        private bool v7;

        public HelpRequest(int v1, string v2, string v3, string v4, string v5, bool v6, TransportationType transportationType, DateTime dateTime1, DateTime dateTime2, bool v7)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.transportationType = transportationType;
            this.dateTime1 = dateTime1;
            this.dateTime2 = dateTime2;
            this.v7 = v7;
        }
    }
}