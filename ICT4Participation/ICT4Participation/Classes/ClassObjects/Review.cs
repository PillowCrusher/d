using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT4Participation.Classes.ClassObjects
{
    public class Review
    {
        public string Rating { get; set; }
        public string Comment { get; set; }

        public Review(string rating, string comment, HelpRequest helprequest)
        {
            if (rating == null)
            {
                throw new ArgumentNullException("rating", "rating is empty");
            }
            if (comment == null)
            {
                throw new ArgumentNullException("comment", "comment is empty");
            }
            this.Rating = rating;
            this.Comment = comment;
        }
    }
}
