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
    //Added by TamilRk - 10/14/2020
    public partial class frmMultiselect : Form
    {
        public List<QuickBooksField> selectedDataSourceLsit = new List<QuickBooksField>();
        public List<clsTemplateLabelXmlwork> objfieldlist = new List<clsTemplateLabelXmlwork>();
        string strTransTypeFilePath = string.Empty;
        string strTempname = string.Empty;

        string changes = "";
        string formName = "";
        public frmMultiselect()
        {
            InitializeComponent();
        }        
        clsTemplateLabelXmlwork lobjTemplate = new clsTemplateLabelXmlwork();
           
        public frmMultiselect(string dataSourcepath, List<QuickBooksField> datasource, string templateName, List<clsTemplateLabelXmlwork> staticField )
        {
            this.strTransTypeFilePath = dataSourcepath;
            this.selectedDataSourceLsit = datasource;
            this.strTempname = templateName;
            this.objfieldlist = staticField;
            InitializeComponent();
        }
        
        #region Events
        private void frmMultiselect_Load(object sender, EventArgs e)
        {
            try
            {
                formName = this.Text;
                if (selectedDataSourceLsit.Count <=0)
                {
                    List<QuickBooksField> Itemfieldlist = lobjTemplate.GetMultiItemFieldListfromxml(strTransTypeFilePath);
                    for (int i = 0; i <= Itemfieldlist.Count - 1; i++)
                    {
                        //    if(Itemfieldlist[i].ItemFieldValue.ToLower() !="static")
                        //    {
                            lstDataSource.Items.Add(Itemfieldlist[i].ItemFieldValue);
                        //}
                        //else
                        //{
                        //    lstDataSource.Items.Add(strStaticFieldname);
                        //}
                    }
                    foreach(var Staticfield in objfieldlist)
                    {
                        if(Staticfield.datasource=="Static")
                        {
                            lstDataSource.Items.Add(Staticfield.fieldname);
                        }
                    }
                    lstDataSource.SelectedIndex = 0;
                }else
                {
                    bool selectitem=true;
                    List<QuickBooksField> Itemfieldlist = lobjTemplate.GetMultiItemFieldListfromxml(strTransTypeFilePath);
                    foreach (var item in Itemfieldlist)
                    {
                        foreach (QuickBooksField item1 in  selectedDataSourceLsit)
                        {
                            if (item.ItemFieldValue == item1.ItemFieldValue.ToString())
                            {
                                selectitem = false;
                                break;
                            }
                            else
                            {
                                selectitem = true;
                            }
                        }
                        if(selectitem)
                        {
                            //if (item.ItemFieldValue.ToLower() != "static")
                            //{
                                lstDataSource.Items.Add(item.ItemFieldValue);
                                lstDataSource.SelectedIndex = 0;
                            //}
                            //else
                            //{
                            //    lstDataSource.Items.Add(strStaticFieldname);
                            //}
                        }
                    }
                    selectitem = true;
                    foreach (var Staticfield in objfieldlist)
                    {
                        if (Staticfield.datasource == "Static")
                        {
                           foreach(var item1 in selectedDataSourceLsit)
                            {
                                if(item1.ItemFieldValue.Split('∬')[0].ToString() == Staticfield.fieldname)
                                {
                                    selectitem = false;
                                    break;
                                }
                                else
                                {
                                    selectitem = true;
                                }
                            }
                            if (selectitem)
                            {
                                lstDataSource.Items.Add(Staticfield.fieldname);
                                lstDataSource.SelectedIndex = 0;                                
                            }

                        }
                    }
                    foreach (var item in selectedDataSourceLsit)
                    {
                        if (item.ItemFieldName.ToLower() != "static1")
                        {
                            lstSelectData.Items.Add(item.ItemFieldValue);
                            lstSelectData.SelectedIndex = 0;
                        }
                        else
                        {
                            lstSelectData.Items.Add(item.ItemFieldValue.Split('∬')[0].ToString());
                            lstSelectData.SelectedIndex = 0;
                        }
                    }                                    
                }                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstDataSource.Items.Count > 0)
            {
                moveItems(lstDataSource, lstSelectData);
                changeUpodate();
            }
        }
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelectData.Items.Count > 0)
            {
                moveItems(lstSelectData, lstDataSource);
                changeUpodate();
            }
        }
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            if (lstSelectData.Items.Count > 0)
            {
                moveAllItems(lstSelectData, lstDataSource);
                changeUpodate();
            }
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (lstDataSource.Items.Count > 0)
            {
                moveAllItems(lstDataSource, lstSelectData);
                changeUpodate();
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
                changeUpodate();
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            // only if the last item isn't the current one
            if ((lstSelectData.SelectedIndex != -1) && (lstSelectData.SelectedIndex < lstSelectData.Items.Count - 1))
            {
                // add a duplicate item down in the listbox
                lstSelectData.Items.Insert(lstSelectData.SelectedIndex + 2, lstSelectData.SelectedItem);
                // make it the current item
                lstSelectData.SelectedIndex = lstSelectData.SelectedIndex + 2;
                // delete the old occurrence of this item
                lstSelectData.Items.RemoveAt(lstSelectData.SelectedIndex - 2);
                changeUpodate();
            }
        }
        #endregion

        #region functions 
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
        private void changeUpodate()
        {
            changes = "Unrecord";
            if(this.Text == "Multi Select - New" || this.Text== "Multi Select - Edit")
            {
                this.Text = "*" + this.Text;
            }

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
        #endregion
        private void frmMultiselect_FormClosing(object sender, FormClosingEventArgs e)
        {          
            if (changes !="")
            {
                var dilogdialogue = MessageBox.Show("You have 'Unrecorded' Changes. Do you want to save them?", "Multi Select", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                switch (dilogdialogue)
                {
                    case (DialogResult.Yes):
                        {
                            saveslection();
                            break;
                        }
               }

            }
        }  

        private void btnSave_Click(object sender, EventArgs e)
        {
           if(saveslection() ==1)
            {
                this.Close();
            }
        }
        private int saveslection()
        {
            try
            {
                selectedDataSourceLsit = new List<QuickBooksField>();
                if (lstSelectData.Items.Count > 0)
                {
                    List<QuickBooksField> Itemfieldlist = lobjTemplate.GetMultiItemFieldListfromxml(strTransTypeFilePath);

                    foreach (var item in lstSelectData.Items)
                    {
                        foreach (QuickBooksField item1 in Itemfieldlist)
                        {
                            if (item.ToString() == item1.ItemFieldValue.ToString())
                            {
                                selectedDataSourceLsit.Add(item1);
                            }
                            //else if(strStaticFieldname.ToString()== item.ToString())
                            //{
                            //    if ( "Static".ToLower() == item1.ItemFieldValue.ToString().ToLower())
                            //    {
                            //        selectedDataSourceLsit.Add(item1);
                            //    }
                               
                                
                            //}
                        }
                        foreach(var staticField in objfieldlist)
                        {
                            if (item.ToString() == staticField.fieldname && staticField.datasource == "Static")
                            {
                                QuickBooksField objitem = new QuickBooksField("Static1", staticField.fieldname+ "∬" + staticField.testdata);                                
                                selectedDataSourceLsit.Add(objitem);
                            }
                        }

                    }
                }
                changes = "";
                this.Text = formName;
                return 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Label Connector");
                return 0;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
