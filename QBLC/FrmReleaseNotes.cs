using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelConnector
{
    public partial class FrmReleaseNotes : Form
    {
        QBConfiguration lobjQBConfiguration;
        public FrmReleaseNotes()
        {
            InitializeComponent();
        }

        private void btn_Download_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Globalvariables.DownloadLink);
            Environment.Exit(0);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            //if (this.chk_ShowMessage.Checked == true)
            //{
            //    lobjQBConfiguration.SaveCustomFields("true", "isShowReleaseNotePopup");
            //}
            this.Close();
        }

        private void FrmReleaseNotes_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Globalvariables.ReleaseNotes;
        }
    }
}
