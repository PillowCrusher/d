using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICT4Participation.Classes.ClassObjects
{
    public static class FormTools
    {
        public static string ConvertBoolToString(bool toConvert)
        {
            string converted;

            converted = toConvert ? "Ja" : "Nee";

            return converted;
        }
    }
}
