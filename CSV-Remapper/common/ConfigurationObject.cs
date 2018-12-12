using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Remapper.common
{
    using System.IO;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    using System.Xml.Serialization;

    public class ConfigurationObject
    {
        private static string CompanyDir = "megraso";
        private static string AppName = "CsvMapper";
        private static string ConfigFileName = "CsvMapper.cfg";
        public static List<string> DelimiterList { get; set; } = new List<string>() { ",", ";", "|" };

        public static readonly string DefaultConfigFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CompanyDir, AppName, ConfigFileName);

        public ConfigurationObject(string configFile = null)
        {
            
            this.SetDefaultSettings();

            if (!string.IsNullOrWhiteSpace(configFile) && File.Exists(configFile))
            {
                this.LoadConfiguration(!string.IsNullOrWhiteSpace(configFile) ? configFile : DefaultConfigFile);
            }
        }


        public ConfigurationObject()
        {
            this.SetDefaultSettings();
        }

        /// <summary>
        /// Initialize the values with default settings
        /// </summary>
        private void SetDefaultSettings()
        {
            this.SourceCSV = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CompanyDir, AppName);
            this.TargetCSV = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CompanyDir, AppName);
            this.DefaultCsvFileExtension = "csv";
            this.DefaultCsvEncoding = "UTF-8";
            this.remappingObj = new List<RemappingObj>();
        }


        public void LoadConfiguration(string configFile)
        {
            try
            {
                if (File.Exists(configFile))
                {
                    FileStream myFileStream = new FileStream(
                        configFile,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.ReadWrite);

                    XmlSerializer mySerializer = new XmlSerializer(typeof(ConfigurationObject));

                    ConfigurationObject conf = (ConfigurationObject)mySerializer.Deserialize(myFileStream);

                    myFileStream.Close();

                    this.SourceCSV = conf.SourceCSV;
                    this.TargetCSV = conf.TargetCSV;
                    this.DefaultCsvFileExtension = conf.DefaultCsvFileExtension;
                    this.DefaultCsvEncoding = conf.DefaultCsvEncoding;

                    this.remappingObj = conf.remappingObj;
                }
                else
                {
                    MessageBox.Show($"File not found: '{configFile}'", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void SaveConfigurationToFile(String fileName = "")
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(fileName))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                    // encrypt password before storing the config to file
                    XmlSerializer mySerializer = new XmlSerializer(typeof(ConfigurationObject));
                    StreamWriter myWriter = new StreamWriter(fileName);
                    mySerializer.Serialize(myWriter, this);
                    myWriter.Flush();
                    myWriter.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on saving configuration file: {ex.Message}", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public string SourceCSV { get; set; }

        public string TargetCSV { get; set; }

        public string DefaultCsvFileExtension { get; set; }

        public string DefaultCsvEncoding { get; set; }

        public List<RemappingObj> remappingObj { get; set; }
    }

    public class RemappingObj
    {
        
        public string SourceField { get; set; }

        public string TargetField { get; set; }

        public string MappingString { get; set; }
    }
}
