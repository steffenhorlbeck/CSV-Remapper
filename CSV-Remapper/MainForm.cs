using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSV_Remapper
{
    using System.IO;
    using System.Reflection;

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
                }
                else
                {
                    string message = "The selected source file does not exist";
                    string caption = "Configuration Error";
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
