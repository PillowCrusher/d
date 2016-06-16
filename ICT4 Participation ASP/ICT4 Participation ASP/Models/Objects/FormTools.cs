using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ICT4_Participation_ASP.Models.Objects
{
    public static class FormTools
    {
        public static string ConvertBoolToString(bool toConvert)
        {
            var converted = toConvert ? "Ja" : "Nee";

            return converted;
        }
    }
}
