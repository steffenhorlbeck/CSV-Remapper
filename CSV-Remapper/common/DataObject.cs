using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Remapper.common
{
    using System.Windows.Forms.VisualStyles;

    public class DataObject
    {

        public DataObject(string separator = ",", string limiter = "\"", string enc = "UTF-8")
        {
            Separator = separator;
            FieldLimiter = limiter;
            CsvEncoding = enc;
            HeaderList = new List<HeaderValuePair>();
        }


        public String Separator { get; set; }

        public String FieldLimiter { get; set; }

        public string CsvEncoding { get; set; }

        public List<HeaderValuePair> HeaderList { get; set; }
    }


    public class HeaderValuePair
    {
        public string HeaderName { get; set; }

        public string FirstFieldValue { get; set; }
    }

    public 
}
