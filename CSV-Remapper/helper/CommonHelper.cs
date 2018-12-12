namespace CSV_Remapper.helper
{
    using System;
    using System.IO;
    using System.Linq;

    using CSV_Remapper.common;

    public static class CommonHelper
    {
        /// <summary>
        /// check if the current line starts with header strings
        /// </summary>
        /// <param name="toCheck">line or string to check for header line words</param>
        /// <returns>true if line starts with header key words, otherwise false</returns>
        public static bool IsHeaderStringInLine(string toCheck)
        {
            if (!toCheck.ToUpper().StartsWith("ACC") && !toCheck.ToUpper().StartsWith("UNIQUE")
                && !toCheck.ToUpper().StartsWith("RECKEY") && !toCheck.ToUpper().StartsWith("RECORD"))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get the number of records in a direct file based access (readln)
        /// </summary>
        /// <param name="dataFileName">file name to check</param>
        /// <returns>the count of data lines without header</returns>
        public static int GetRecordCount(string dataFileName)
        {
            int count = 0;
            int header = 0;

            // we need to check if the first line is a header or not 
            var lines = File.ReadLines(dataFileName);

            foreach (string line in lines)
            {
                if (IsHeaderStringInLine(line))
                {
                    header++;
                }
                else
                {
                    break; // can break here because we only need the first line
                }
            }

            count = lines.Count() - header;

            return count;
        }

        /// <summary>
        /// Check if a file can be opened for reading basically
        /// </summary>
        /// <param name="fileName">file name to check</param>
        /// <returns>returns true if file can be read, otherwise false</returns>
        public static bool IsFileAccessableForRead(string fileName)
        {
            try
            {
                using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    stream.Dispose();

                    // Do nothing with the opened file
                    return true; // <- File has been opened
                }
            }
            catch (IOException)
            {
                return false; // <- File failed to open
            }            
        }

        /// <summary>
        /// Get the sub-folder from path to calculate the folder part of unique identifier
        /// backslash is replaced by "-" in returned string
        /// </summary>
        /// <param name="period">reporting period</param>
        /// <param name="path">complete path</param>
        /// <param name="replaceSeparator">flag to replace separator char by "-" for UniqueRecKey creation. Default:true</param>
        /// <returns>sub-directory with replaced separators by "-"</returns>
        public static string GetSubfolderFromPath(string period, string path, bool replaceSeparator = true)
        {
            if (path == string.Empty) { return string.Empty; }


            string sReturn = string.Empty;

            // last sub dir only
            // int posFoldername = path.LastIndexOf(Path.DirectorySeparatorChar);

            // sub dir from period to the end - replace "\" by "-"
            int posFoldername = path.LastIndexOf(period, StringComparison.OrdinalIgnoreCase) + period.Length;

            if (posFoldername > 0)
            { sReturn = path.Substring(posFoldername + 1); }

            if (replaceSeparator)
            {
                sReturn = sReturn.Replace(Path.DirectorySeparatorChar, '-');
                sReturn = sReturn.Replace(' ', '-');
            }

            sReturn.Trim();
            return sReturn;
        }


        public static string GetFieldDelimiter(string fileName)
        {

            // Get the first line
            StreamReader file = new StreamReader(fileName);
            string line = file.ReadLine();
            file.Close();

            // split by comma, get the first entry, remove possible quotes and trim it
            string toCheck = line.Split(',')[0].Trim('"').Trim();

            foreach (string delimiter in ConfigurationObject.DelimiterList)
            {
                if (toCheck.Contains(delimiter))
                {
                    return delimiter;
                }
            }
            return ConfigurationObject.DelimiterList[0];
        }
    }
}
