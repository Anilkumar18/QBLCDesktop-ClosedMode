using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace LabelConnector
{
    public partial class frmgetsize : Form
    {
        string w = "";
        string F = "";
        public string valH = "";
        public string valW = "";
        public frmgetsize(string wraptext, string fontsize)
        {
            InitializeComponent();
            w = wraptext;
            F = fontsize;
        }

        private void frmgetsize_Load(object sender, EventArgs e)
        {
            this.Size = new Size(0,0);
            RadLabel lbl = new RadLabel();
            radPanel1.Controls.Add(lbl);
            lbl.Text = w;
            lbl.LabelElement.AngleTransform = 90;
            lbl.Font = new System.Drawing.Font("Arial", Convert.ToInt32(F) + (float)(Convert.ToInt32(F) / 2.5), FontStyle.Regular);
            lbl.TextWrap = true;
            valH = lbl.Height.ToString();
            valW = lbl.Width.ToString();
        }    
    }
}
