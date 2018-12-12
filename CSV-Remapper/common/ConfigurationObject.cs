using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_Remapper.common
{
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    public class ConfigurationObject
    {
        private static string CompanyDir = "megraso";
        private static string AppName = "CsvMapper";
        private static string ConfigFileName = "CsvMapper.cfg";

        private static string DefaultConfigFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), CompanyDir, AppName, ConfigFileName);

        public ConfigurationObject(string configFile = null)
        {
            
            this.SetDefaultSettings();

            if (!string.IsNullOrWhiteSpace(configFile))
            {
                this.LoadConfiguration(!string.IsNullOrWhiteSpace(configFile) ? configFile : DefaultConfigFile);
            }
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


        public void SaveConfigurationToFile(string fileName = "")
        {
            try
            {
                if (fileName.IsNullOrWhiteSpace())
                {
                    fileName = this.CurrentConfigurationFile;
                }

                // encrypt password before storing the config to file
                this.SftpPassword = StringCipher.Encrypt(this.SftpPassword, this.core.GetCipherPw());
                this.ZipPassword = StringCipher.Encrypt(this.ZipPassword, this.core.GetCipherPw());
                this.SqlPassword = StringCipher.Encrypt(this.SqlPassword, this.core.GetCipherPw());
                this.SftprsaKeyPassphrase = StringCipher.Encrypt(this.SftprsaKeyPassphrase, this.core.GetCipherPw());
                XmlSerializer mySerializer = new XmlSerializer(typeof(ConfigurationObj));
                StreamWriter myWriter = new StreamWriter(fileName);
                mySerializer.Serialize(myWriter, this);
                myWriter.Flush();
                myWriter.Close();
            }
            catch (Exception ex)
            {
                this.core.Log.Error($"Error on saving configuration file: {ex.Message}");
            }
        }


        public string SourceCSV { get; set; }

        public string TargetCSV { get; set; }

        public string DefaultCsvFileExtension { get; set; }

        public string DefaultCsvEncoding { get; set; }
    }
}
