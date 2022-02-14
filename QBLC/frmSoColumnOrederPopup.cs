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
    public partial class frmSoColumnOrederPopup : Form
    {
        QBConfiguration lobjQBConfiguration = new QBConfiguration();
        public frmSoColumnOrederPopup()
        {
            InitializeComponent();
        }

        private void frmSoColumnOrederPopup_Load(object sender, EventArgs e)
        {
            lobjQBConfiguration = new QBConfiguration();
            string getName = lobjQBConfiguration.GetLabelConfigSettings("SoColumnVisible").ToString();
            if (!string.IsNullOrWhiteSpace(getName))
            {
                List<string> columnNameVisible = new List<string>();
                columnNameVisible = getName.Split(',').ToList();

                if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("qbcolumnsvalue").ToString()))
                    columnNameVisible.Add("SoLineColumnName");
                if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("qbSecondcolumnsvalue").ToString()))
                    columnNameVisible.Add("SoLineSecondColumnName");

                columnNameVisible = columnNameVisible.Distinct().ToList();
                foreach (string clmName in columnNameVisible)
                {
                    lstSelectData.Items.Add(ColumnFieldNameLoad(clmName));
                    lstSelectData.SelectedIndex = 0;
                }
            }
            string getHideName = lobjQBConfiguration.GetLabelConfigSettings("SoColumnHide").ToString();
            if(!string.IsNullOrWhiteSpace(getHideName))
            {
                List<string> columnNameHide = new List<string>();
                columnNameHide = getHideName.Split(',').ToList();
                foreach (string clmName in columnNameHide)
                {
                    lstDataSource.Items.Add(ColumnFieldNameLoad(clmName));
                    lstDataSource.SelectedIndex = 0;
                }
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstDataSource.Items.Count > 0)
            {
                moveItems(lstDataSource, lstSelectData);
              
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (lstDataSource.Items.Count > 0)
            {
                moveAllItems(lstDataSource, lstSelectData);
             
            }
        }
        

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelectData.Items.Count > 0)
            {
                moveItems(lstSelectData, lstDataSource);
           
            }

        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (lstSelectData.Items.Count > 0)
            {
                moveAllItems(lstSelectData, lstDataSource);          
            }
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstSelectData.SelectedIndex > 0)
            {
                // add a duplicate item up in the listbox
                lstSelectData.Items.Insert(lstSelectData.SelectedIndex - 1, lstSelectData.SelectedItem);
                // make it the current item
                lstSelectData.SelectedIndex = (lstSelectData.SelectedIndex - 2);
                // delete the old occurrence of this item
                lstSelectData.Items.RemoveAt(lstSelectData.SelectedIndex + 2);              
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            if ((lstSelectData.SelectedIndex != -1) && (lstSelectData.SelectedIndex < lstSelectData.Items.Count - 1))
            {
                // add a duplicate item down in the listbox
                lstSelectData.Items.Insert(lstSelectData.SelectedIndex + 2, lstSelectData.SelectedItem);
                // make it the current item
                lstSelectData.SelectedIndex = lstSelectData.SelectedIndex + 2;
                // delete the old occurrence of this item
                lstSelectData.Items.RemoveAt(lstSelectData.SelectedIndex - 2);          
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string columnName = "";
            foreach (string Itemname in lstDataSource.Items)
            {
                columnName = columnName + "," + ColumnFieldNameSave(Itemname);

            }
            if(columnName.Length>1)
            columnName= columnName.Remove(0, 1);

            lobjQBConfiguration.SaveLabelFilePathSettings(columnName, "SoColumnHide");
            columnName = "";
            foreach (string Itemname in lstSelectData.Items)
            {
                columnName = columnName + "," + ColumnFieldNameSave(Itemname);
            }
            if (columnName.Length > 1)
                columnName = columnName.Remove(0, 1);

            lobjQBConfiguration.SaveLabelFilePathSettings(columnName, "SoColumnVisible");
            this.Close();
        }
        private string ColumnFieldNameLoad(string clmName)
        {
            if (clmName == "SalesOrderLineUnitOfMeasure")
            {
                return "SO UoM";
            }
            else if(clmName == "SalesOrderLineItemRefFullName")
            {
                return "SO Item";
            }
            else if(clmName == "SalesOrderLineDesc")
            {
                return "So Item Desc";
            }
            else if(clmName == "SalesPrice")
            {
                return "Sales Price";
            }
            else if (clmName == "MarkUpPrice")
            {
                return "Adjusted Label Price";
            }
            else if (clmName == "SubItemof")
            {
                return "Sub Item of";
            }
            else if (clmName == "SoLineColumnName")
            {
                return lobjQBConfiguration.GetLabelConfigSettings("qbcolumnsvalue").ToString();
            }
            else if (clmName == "SoLineSecondColumnName")
            {
                return lobjQBConfiguration.GetLabelConfigSettings("qbSecondcolumnsvalue").ToString();
            }
            return "";

        }
        private string ColumnFieldNameSave(string clmName)
        {
            if (clmName == "SO UoM")
            {
                return "SalesOrderLineUnitOfMeasure";
            }
            else if (clmName == "SO Item")
            {               
                return "SalesOrderLineItemRefFullName";
            }
            else if (clmName == "So Item Desc")
            {
                return "SalesOrderLineDesc";
            }
            else if (clmName == "Sales Price")
            {
                return "SalesPrice";
            }
            else if (clmName == "Adjusted Label Price")
            {
                return "MarkUpPrice";
            }
            else if (clmName == "Sub Item of")
            {
                return "SubItemof";
            }
            else if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("qbcolumnsvalue").ToString()) && clmName == lobjQBConfiguration.GetLabelConfigSettings("qbcolumnsvalue").ToString())
            {
                return "SoLineColumnName";
            }
            else if (!string.IsNullOrWhiteSpace(lobjQBConfiguration.GetLabelConfigSettings("qbSecondcolumnsvalue").ToString()) && clmName == lobjQBConfiguration.GetLabelConfigSettings("qbSecondcolumnsvalue").ToString())
            {
                return "SoLineSecondColumnName";
            }
            return "";

        }
        private void moveAllItems(ListBox from, ListBox to)
        {
            int count = from.Items.Count - 1;
            for (int i = 0; i <= count; i++)
            {
                to.Items.Add(from.Items[from.Items.Count - 1]);
                from.Items.Remove(from.Items[from.Items.Count - 1]);
            }
            if (to.Items.Count > 0)
            {
                to.SelectedIndex = 0;
            }
        }
        private void moveItems(ListBox from, ListBox to)
        {
            int selectIndex;
            selectIndex = from.SelectedIndex;
            to.Items.Add(from.SelectedItem);
            from.Items.Remove(from.SelectedItem);
            if (from.Items.Count > 0)
            {
                if (selectIndex == 0)
                {
                    from.SelectedIndex = 0;
                }
                else
                {
                    from.SelectedIndex = selectIndex - 1;
                }
            }
            if (to.Items.Count > 0)
            {
                to.SelectedIndex = to.Items.Count - 1;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
