using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;

namespace CSV_Remapper
{
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;


    using CSV_Remapper.common;
    using CSV_Remapper.helper;

    public partial class MainForm : Form
    {

        public string CurrentConfigurationFile;
        public ConfigurationObject Conf = null;

        //private List<List<string>> importedRecords;

        public DataObject importObj = null;
        public DataObject exportObj = null;

        // Class variable to keep track of which row is currently selected:
        private int hoveredIndexSourceCsv = -1;
        private int hoveredIndexTargetCsv = -1;
        private int hoveredIndexMapingList = -1;

        private List<List<string>> sourceList;
        private List<List<string>> targetList;

        public MainForm()
        {
            InitializeComponent();

            this.CurrentConfigurationFile = ConfigurationObject.DefaultConfigFile;
            Directory.CreateDirectory(Path.GetDirectoryName(this.CurrentConfigurationFile));
            this.Conf = new ConfigurationObject(this.CurrentConfigurationFile);

            this.edtSourceCSV.Text = this.Conf.SourceCSV;
            if (!string.IsNullOrWhiteSpace(this.edtSourceCSV.Text) && File.Exists(this.edtSourceCSV.Text))
            {
                this.LoadSourceFile();
            }

            this.edtTargetCSV.Text = this.Conf.TargetCSV;
            if (!string.IsNullOrWhiteSpace(this.edtTargetCSV.Text) && File.Exists(this.edtTargetCSV.Text))
            {
                this.LoadTargetFile();
            }

            RefreshMappingList();
        }


        private void btnSelectSourceCSV_Click(object sender, EventArgs e)
        {
            if (File.Exists(this.edtSourceCSV.Text))
            {
                this.fileSelectDlg.InitialDirectory = this.edtSourceCSV.Text;
            }
            else
            {
                this.fileSelectDlg.InitialDirectory = Assembly.GetExecutingAssembly().Location;
            }

            if (this.fileSelectDlg.ShowDialog() == DialogResult.OK)
            {
                if (this.fileSelectDlg.CheckFileExists)
                {
                    this.edtSourceCSV.Text = this.fileSelectDlg.FileName;

                    this.LoadSourceFile();
                }
                else
                {
                    string message = "The selected source file does not exist";
                    string caption = "Configuration Error";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnSelectTargetCSV_Click(object sender, EventArgs e)
        {
            List<List<string>> list;

            if (File.Exists(this.edtTargetCSV.Text))
            {
                this.fileSelectDlg.InitialDirectory = this.edtTargetCSV.Text;
            }
            else
            {
                this.fileSelectDlg.InitialDirectory = Assembly.GetExecutingAssembly().Location;
            }

            if (this.fileSelectDlg.ShowDialog() == DialogResult.OK)
            {
                if (this.fileSelectDlg.CheckFileExists)
                {
                    this.edtTargetCSV.Text = this.fileSelectDlg.FileName;

                    this.LoadTargetFile();
                }
                else
                {
                    string message = "The selected target file does not exist";
                    string caption = "Configuration Error";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void LoadSourceFile()
        {
            
            sourceList = ReadCsv(this.edtSourceCSV.Text, ref this.importObj);

            this.lstSourceCSV.Items.Clear();
            this.ListFields(sourceList);
        }

        private void LoadTargetFile()
        {
            
            targetList = ReadCsv(this.edtTargetCSV.Text, ref this.exportObj);

            this.lstTargetCSV.Items.Clear();
            this.ListFields(targetList, true);
        }

        private void ListFields(List<List<string>> list, bool target = false)
        {
            
            List<string> header = null;
            List<string> record = null;

            if (list.Count > 0)
            {
                header = list[0];
            }

            if (list.Count > 1)
            {
                record = list[1];
            }

            if (header != null)
            {
                foreach (string fieldName in header)
                {
                    HeaderValuePair pair = new HeaderValuePair();

                    pair.HeaderName = fieldName.Trim();                   
                    if (record != null && record.Count >= header.IndexOf(fieldName.Trim())+1)
                    {
                        pair.FirstFieldValue = record[header.IndexOf(fieldName.Trim())];
                    }

                    if (target)
                    {
                        this.exportObj.HeaderList.Add(pair);
                    }
                    else
                    {
                        this.importObj.HeaderList.Add(pair);
                    }



                    if (target)
                    {
                        int idx = this.lstTargetCSV.Items.Add(fieldName.Trim());
                    }
                    else
                    {
                        int idx = this.lstSourceCSV.Items.Add(fieldName.Trim());
                    }
                }
            }
        }

        public List<List<string>> ReadCsv(string fileName, ref DataObject obj)
        {
            string delimiter = CommonHelper.GetFieldDelimiter(fileName);

            Encoding enc = EncodingHelper.DetectEncoding(fileName, this.Conf.DefaultCsvEncoding);
            obj = null;

            List<List<string>> result = new List<List<string>>();
            
            string value;


            using (var csv = new CsvReader(new StreamReader(fileName, enc))) 
            {
                csv.Configuration.Delimiter = delimiter;
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Encoding = enc;
                csv.Configuration.BadDataFound = null;

                obj = new DataObject(
                    delimiter,
                    csv.Configuration.Quote.ToString(),
                    csv.Configuration.Encoding.BodyName);


                List<string> heads = new List<string>();

                if (csv.Read())
                {
                    if (csv.ReadHeader())
                    {
                        for (int i = 0; i < csv.Context.HeaderRecord.Length; i++)
                        {
                            heads.Add(csv.Context.HeaderRecord[i].Trim());
                        }
                        result.Add(heads);
                    }
                }


                while (csv.Read())
                {
                    List<string> lines = new List<string>();
                    for (int i = 0; csv.TryGetField<string>(i, out value); i++)
                    {
                        lines.Add(value.Trim());
                    }

                    result.Add(lines);
                }
            }
            return result;
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfiguration();
        }

        private void SaveConfiguration()
        {
            this.Conf.SourceCSV = this.edtSourceCSV.Text;
            this.Conf.TargetCSV = this.edtTargetCSV.Text;

            this.Conf.SaveConfigurationToFile(this.CurrentConfigurationFile);
        }

        private void lstSourceCSV_MouseMove(object sender, MouseEventArgs e)
        {
            // See which row is currently under the mouse:
            int newHoveredIndex = this.lstSourceCSV.IndexFromPoint(e.Location);

            // If the row has changed since last moving the mouse:
            if (hoveredIndexSourceCsv != newHoveredIndex)
            {
                // Change the variable for the next time we move the mouse:
                hoveredIndexSourceCsv = newHoveredIndex;

                // If over a row showing data (rather than blank space):
                if (hoveredIndexSourceCsv > -1)
                {
                    //Set tooltip text for the row now under the mouse:
                    this.toolTipSource.Active = false;

                    string header = this.lstSourceCSV.Items[this.hoveredIndexSourceCsv].ToString();
                    HeaderValuePair pair = this.importObj.HeaderList.Find(l => l.HeaderName.Equals(header));
                    this.toolTipSource.SetToolTip(this.lstSourceCSV, pair!=null?pair.FirstFieldValue:string.Empty);
                    this.toolTipSource.Active = true;
                }
            }
        }

        private bool HandleMapping()
        {
            if (this.lstSourceCSV.SelectedIndex > -1 && this.lstTargetCSV.SelectedIndex > -1)
            {
                RemappingObj obj = this.Conf.remappingObj.Find(t => t.TargetField.Equals(this.lstTargetCSV.SelectedItem.ToString()));

                // check if there is an object with a link to the selected target
                if (obj == null)
                {
                    obj = new RemappingObj();
                    obj.SourceField = this.lstSourceCSV.SelectedItem.ToString();
                    obj.TargetField = this.lstTargetCSV.SelectedItem.ToString();
                    obj.MappingString = obj.SourceField + " -> " + obj.TargetField;
                    this.Conf.remappingObj.Add(obj);
                    this.RefreshMappingList();
                    return true;
                }

                string message = "The selected target is just mapped";
                string caption = "Mapping Error";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }




        private void btnMap_Click(object sender, EventArgs e)
        {
            HandleMapping();
        }


        private void RefreshMappingList()
        {
            this.lstMaps.Items.Clear();

            foreach (RemappingObj obj in this.Conf.remappingObj)
            {
                this.lstMaps.Items.Add(obj.MappingString);
            }
        }



        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lstMaps.SelectedIndex > -1)
            {
                string entry = this.lstMaps.SelectedItem.ToString();
                RemappingObj obj = this.Conf.remappingObj.Find(o => o.MappingString.Equals(entry));

                if (obj != null)
                {
                    this.Conf.remappingObj.Remove(obj);
                    this.RefreshMappingList();
                }
            }
            
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (RemappingObj obj in this.Conf.remappingObj)
            {

            }
        }
    }
}
