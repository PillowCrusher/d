using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4_Participation_ASP.Models.Objects
{
    public class Skill
    {
        public string Naam { get; protected set; }

        public Skill(string naam)
        {
            this.Naam = naam;
        }
    }
}