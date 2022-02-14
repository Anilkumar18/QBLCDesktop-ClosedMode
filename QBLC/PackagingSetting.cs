using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text;
namespace LabelConnector
{
    public partial class PackagingSetting : Form
    {
        public PackagingSetting()
        {
            InitializeComponent();
            int quantityToPrint = PackagingSettings.QuantityToPrint();
            ddlPackagingNumber.Value = quantityToPrint;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string applicationDomainPath = AppDomain.CurrentDomain.BaseDirectory;
            string packagingfile = "PackagingSettings.xml";
            XmlTextWriter xTw = new XmlTextWriter(applicationDomainPath + packagingfile, Encoding.UTF8);
            xTw.WriteStartElement("PackagingSetting");
            xTw.WriteElementString("Number", ddlPackagingNumber.Value.ToString());
            xTw.WriteEndElement();
            xTw.Flush();
            xTw.Close();

            DialogResult dlResult = MessageBox.Show("Packaging setting completed successfully!!", "Settings Saved", MessageBoxButtons.OKCancel);
            if (dlResult == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
