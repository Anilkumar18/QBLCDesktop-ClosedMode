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
    public partial class FrmUpgradePopup : Form
    {
        
        public FrmUpgradePopup()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Globalvariables.DownloadLink);
            this.Close();
        }

        private void FrmUpgradePopup_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = Globalvariables.ReleaseNotes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
