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
    public partial class frmPrintedViewList : Form
    {
        public frmPrintedViewList()
        {
            InitializeComponent();
        }

        private void frmPrintedViewList_FormClosed(object sender, FormClosedEventArgs e)
        {
            listprintingItem.Items.Clear();
        }
    }
}
