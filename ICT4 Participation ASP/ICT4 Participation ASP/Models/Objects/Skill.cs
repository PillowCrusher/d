﻿using System;
using System.Collections.Generic;
using System.Data;
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

        public Skill(DataRow dr) : this(dr["NAME"].ToString()) { }

        public override bool Equals(object obj)
        {
            if (obj is Skill)
            {
                Skill other = ((Skill)obj);
                return this.Naam == other.Naam;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return Naam;
        }
    }
}