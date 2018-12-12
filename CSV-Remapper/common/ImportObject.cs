using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Remapper.common
{
    using System.Windows.Forms.VisualStyles;

    public class ImportObject
    {

        public ImportObject(string separator = ",", string limiter = "\"")
        {
            Separator = separator;
            FieldLimiter = limiter;
            HeaderList = new List<HeaderValuePair>();
        }


        public String Separator { get; set; }

        public String FieldLimiter { get; set; }

        public List<HeaderValuePair> HeaderList { get; set; }
    }


    public class HeaderValuePair
    {
        public string HeaderName { get; set; }

        public string FirstFieldValue { get; set; }
    }
}
