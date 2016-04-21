using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Review
    {
        public Volunteer Volunteer { get; }
        public string Rating { get; }
        public string Comment { get; }

        public Review(string rating, string comment, Volunteer volunteer)
        {
            Volunteer = volunteer;
            Rating = rating;
            Comment = comment;
        }
    }
}
