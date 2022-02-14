using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LabelConnector
{
    public delegate void showDcNumber();
    public partial class FrmDivQuantitySetting : Form
    {
        QBConfiguration lobjQBConfiguration;
        public showDcNumber objDCLabel;

        private static FrmDivQuantitySetting objfrmLabelConfig;
        public static FrmDivQuantitySetting GetInstance()
        {

            if (objfrmLabelConfig == null)
            {
                objfrmLabelConfig = new FrmDivQuantitySetting();
            }
            return objfrmLabelConfig;
        }

        public FrmDivQuantitySetting()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fillColumnnameComboBox()
        {
            List<string> ItemList = new List<string>();
            String[] x = { "", "Other2", "Other1","Mfr Part Number","Cost","Amount","Class","Other1 and Other2" };

            ItemList.AddRange(x);
           cmbcolumnlist.DataSource = ItemList;
         
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            //save column names
            lobjQBConfiguration.SaveCustomFields(cmbcolumnlist.Text.ToString(),"qbcolumns");

            if(cmbcolumnlist.SelectedIndex == 7)
            {
                if (!string.IsNullOrWhiteSpace(txtcolumnfield.Text))
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings(txtcolumnfield.Text.ToString(), "qbcolumnsvalue");
                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("", "qbcolumnsvalue");
                    MessageBox.Show("Please enter the column fields name", "Label Connector", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    return;
                   
                }
                if (!string.IsNullOrWhiteSpace(txtsecondcolumnName.Text))
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings(txtsecondcolumnName.Text.ToString(), "qbSecondcolumnsvalue");
                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("", "qbSecondcolumnsvalue");
                    MessageBox.Show("Please enter the column fields name", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (cmbcolumnlist.SelectedIndex == 0)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("", "qbcolumnsvalue");
                lobjQBConfiguration.SaveLabelFilePathSettings("", "qbSecondcolumnsvalue");
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(txtcolumnfield.Text))
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings(txtcolumnfield.Text.ToString(), "qbcolumnsvalue");
                }
                else
                {
                    lobjQBConfiguration.SaveLabelFilePathSettings("", "qbcolumnsvalue");
                    MessageBox.Show("Please enter the column fields name", "Label Connector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
              
                    lobjQBConfiguration.SaveLabelFilePathSettings("", "qbSecondcolumnsvalue");
               
            }

              
            lobjQBConfiguration.SaveQuantyPerContainerSettings(this.rdbwithqtypercontainer.Checked, this.rdbEntry1yes.Checked, this.rdbEntry2yes.Checked,this.txtentryonefield.Text.ToString(),this.txtentrytwofield.Text.ToString(),this.txtqtycontainercustomfield.Text.ToString(),this.txtMarkupPrice.Text.ToString());
            if (rdoPrintLblQtyDef.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("SO", "SoPrintQty");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("PICk", "SoPrintQty");
            }

            if (rdoprintsoqty.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("M", "MultiSoMode");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("S", "MultiSoMode");
            }

            if (chkcustomfields.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "SOEnablecustomfields");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "SOEnablecustomfields");
            }

            if (chkEnableothercharges.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "SOEnableotherchargesfields");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "SOEnableotherchargesfields");
            }
            if (chkParentwithItemName.Checked == true)
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("1", "EnableParentwithItemName");
            }
            else
            {
                lobjQBConfiguration.SaveLabelFilePathSettings("0", "EnableParentwithItemName");
            }


            objDCLabel();
            DialogResult dlResult = MessageBox.Show("Settings saved successfully!!", "Settings Saved", MessageBoxButtons.OKCancel);
            if (dlResult == DialogResult.OK)
            {
                this.Close();
            }

            lobjQBConfiguration.SaveLabelFilePathSettings(txtendofProduction.Text, "endofProduction");

        }

        private void FrmDivQuantitySetting_Load(object sender, EventArgs e)
        {

            try
            {
                lobjQBConfiguration = new QBConfiguration();

                
                var itemlist = lobjQBConfiguration.GetQuantityPerContainterConfigSettings();


                if (itemlist.ContainsKey("QtyPerContainer"))
                {
                    if (itemlist["QtyPerContainer"].ToString() == "1")
                    {
                        this.rdbwithqtypercontainer.Checked = true;
                        this.rdbwithoutqtypercontainer.Checked = false;
                    }
                    else
                    {
                        this.rdbwithqtypercontainer.Checked = false;
                        this.rdbwithoutqtypercontainer.Checked = true;
                    }

                }

                if (itemlist.ContainsKey("DCNumber"))
                {

                    if (itemlist["DCNumber"].ToString() == "1")
                    {

                        this.rdbEntry1yes.Checked = true;
                        this.rdbEntry1no.Checked = false;
                        
                    }
                    else
                    {
                        this.rdbEntry1no.Checked = true;
                        this.rdbEntry1yes.Checked = false;
                    }


                }

                if (itemlist.ContainsKey("Carrier"))
                {

                    if (itemlist["Carrier"].ToString() == "1")
                    {

                        this.rdbEntry2yes.Checked = true;
                        this.rdbEntry2no.Checked = false;
                    }
                    else
                    {
                        this.rdbEntry2no.Checked = true;
                        this.rdbEntry2yes.Checked = false;
                    }


                }


                if(itemlist.ContainsKey("Entryonetext"))
                {
                    if (itemlist["Entryonetext"].ToString() != "")
                    {
                        this.txtentryonefield.Text = itemlist["Entryonetext"].ToString();
                    }
                    else
                    {
                        this.txtentryonefield.Text = string.Empty;
                    }
                
                }

                if (itemlist.ContainsKey("Entrytwotext"))
                {
                    if (itemlist["Entrytwotext"].ToString() != "")
                    {
                        this.txtentrytwofield.Text = itemlist["Entrytwotext"].ToString();
                    }
                    else
                    {
                        this.txtentrytwofield.Text = string.Empty;
                    }

                }


                if (itemlist.ContainsKey("QtyPerContainerField"))
                {
                    if (itemlist["QtyPerContainerField"].ToString() != "")
                    {
                        this.txtqtycontainercustomfield.Text = itemlist["QtyPerContainerField"].ToString();
                    }
                    else
                    {
                        this.txtqtycontainercustomfield.Text = string.Empty;
                    }

                }

                if (itemlist.ContainsKey("MarkUpPriceField"))
                {
                    if (itemlist["MarkUpPriceField"].ToString() != "")
                    {
                        this.txtMarkupPrice.Text = itemlist["MarkUpPriceField"].ToString();
                    }
                    else
                    {
                        this.txtMarkupPrice.Text = string.Empty;
                    }

                }
               

                if ((lobjQBConfiguration.GetLabelConfigSettings("SOEnablecustomfields").ToString() == "1"))
                {
                    chkcustomfields.Checked = true;
                }
                else
                {
                    chkcustomfields.Checked = false;
                }

                if ((lobjQBConfiguration.GetLabelConfigSettings("EnableParentwithItemName").ToString() == "1"))
                {
                    chkParentwithItemName.Checked = true;
                }
                else
                {
                    chkParentwithItemName.Checked = false;
                }


                if ((lobjQBConfiguration.GetLabelConfigSettings("SOEnableotherchargesfields").ToString() == "1") )
                {
                    chkEnableothercharges.Checked = true;
                }
                else
                {
                    chkEnableothercharges.Checked = false;
                }

               

                if ((lobjQBConfiguration.GetLabelConfigSettings("SoPrintQty").ToString() == "0"))
                {
                    rdoPrintLblQtyDef.Checked = true;


                }
                else
                {

                    rdoToPickQtyDef.Checked = true;
                }

                //Get multiplesoqty or default qty for print :Date 09-jan2017
                if ((lobjQBConfiguration.GetLabelConfigSettings("MultiSoMode").ToString() == "M"))
                {
                    rdoprintsoqty.Checked = true;
                    

                }
                else
                {

                    rdoprintlblqty.Checked = true;
                }

        

                //Get columns name and it value :Date 16-Mar-2020
                fillColumnnameComboBox();
                cmbcolumnlist.Text = lobjQBConfiguration.GetLabelConfigSettings("qbcolumns").ToString();
                txtcolumnfield.Text= lobjQBConfiguration.GetLabelConfigSettings("qbcolumnsvalue").ToString();
                txtsecondcolumnName.Text = lobjQBConfiguration.GetLabelConfigSettings("qbSecondcolumnsvalue").ToString();
                txtendofProduction.Text = lobjQBConfiguration.GetLabelConfigSettings("endofProduction").ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }

        }

        private void rdbwithqtypercontainer_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbwithqtypercontainer.Checked == true)
            //{

            //    pnlDCNumbervisible.Visible = true;
            //}
           
        }

        private void rdbwithoutqtypercontainer_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbwithoutqtypercontainer.Checked == true)
            //{
            //    pnlDCNumbervisible.Visible = false;
            //}
        }

        private void rdoPrintLblQtyDef_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;

            if(btn.Checked==true)
            {
                rdoprintsoqty.Text = "Print So Qty by default";
                rdoprintsoqty.Checked = true;
                rdoprintlblqty.Checked = false;
                rdoToPickQtyDef.Checked = false;
            }
            else
            {
                rdoprintsoqty.Text = "Print To Pick Qty by default";
                rdoprintsoqty.Checked = true;
                rdoprintlblqty.Checked = false;
            }

        }

        private void rdoToPickQtyDef_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn = sender as RadioButton;

            if (btn.Checked == true)
            {
                rdoprintsoqty.Text = "Print To Pick Qty by default";
                rdoprintsoqty.Checked = true;
                rdoprintlblqty.Checked = false;
                rdoPrintLblQtyDef.Checked = false;


            }
            else
            {
                rdoprintsoqty.Text = "Print So Qty by default";
                rdoprintsoqty.Checked = true;
                rdoprintlblqty.Checked = false;
            }

        }

        private void btnCustomize_Click(object sender, EventArgs e)
        {
            frmSoColumnOrederPopup frmsoclm = new frmSoColumnOrederPopup();
            frmsoclm.ShowDialog();
        }

        private void cmbcolumnlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbcolumnlist.SelectedIndex == 7)
            {
                txtsecondcolumnName.Visible = true;
            }
            else if(cmbcolumnlist.SelectedIndex == 0)
            {
                txtsecondcolumnName.Visible = false;
                txtsecondcolumnName.Text = "";
                txtcolumnfield.Text = "";
            }
            else
            {
                txtsecondcolumnName.Visible = false;
                txtsecondcolumnName.Text = "";
            }
        }
    }
}
