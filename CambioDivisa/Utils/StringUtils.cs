using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CambioDivisa.Utils
{
    public static class StringUtils
    {
        public static int? ConvertToInteger(string str)
        {
            if (!int.TryParse(str, out int val))
            {
                return null;
            }
            return val;
        }

        public static decimal? ConvertToDecimal(string str)
        {
            if (!decimal.TryParse(str, out decimal val))
            {
                return null;
            }
            return val;
        }
    }
}
