using clsdbClassLibrary;
using CodeGenerator.BusinessLayer;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodeGenerator.DataAccessLayer;

namespace CodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += _Load;
            btnGenerate.Click += _Generate;
        }
        
        List<string> FindList = new List<string>();
        List<string> IsExistList = new List<string>();
        List<string> DeleteList = new List<string>();

        enum enOperations {enFields=1,enFind=2,enAddUpdate=4,enDelete=8,enIsExist=16,
            enGetRecordsList=32 }
        private byte _Operation;
        DataTable dtColumns;

        private void _PopulateComboBox(ComboBox combobox,string displayMember,DataTable dt)
        {
            combobox.DataSource = dt;
            combobox.DisplayMember = displayMember;
        }
        private void _Load(object sender,EventArgs e)
        {
            _PopulateComboBox(cmbDatabases, "name", clsDataBase.GetDatabasesList());
        }

        private void cmbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CanFocus)
            {
                _PopulateComboBox(cmbTables, "TABLE_NAME", clsDataBase.GetTablesList(cmbDatabases.Text));
                
                panel1.Enabled = true;

            }
            
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            clbFind.Items.Clear();
            clbIsExist.Items.Clear();
            clbDelete.Items.Clear();

            dtColumns = clsDataBase.RetrieveTableSchema(cmbDatabases.Text, cmbTables.Text);
            dgvColumns.DataSource = dtColumns;
            
            
            foreach(DataRow Row in dtColumns.Rows)
            {
                
                clbFind.Items.Add(Row.ItemArray[0]);
                clbIsExist.Items.Add(Row.ItemArray[0]);
                clbDelete.Items.Add(Row.ItemArray[0]);
            }

            tbSingleName.Text = cmbTables.Text.Substring(0, (cmbTables.Text.Length - 1));

        }


        private void _GenerateCode()
        {
            string TableName = tbSingleName.Text;
            
            if ((_Operation &(int) enOperations.enFields) != 0)
            {
                tbBusinessLayer.Text += clsGenerateCode.IntitializeClass(TableName, dtColumns);
            }

            if ((_Operation & (int)enOperations.enFind) != 0)
            {
                foreach (string FieldName in FindList)
                {
                    tbBusinessLayer.Text += clsGenerateCode.Find(TableName, dtColumns, FieldName);
                    tbDataAccessLayer.Text += GenerateCodeDataLayer.Find(TableName, dtColumns, FieldName);
                }
            }

            if((_Operation & (int)enOperations.enAddUpdate) != 0)
            {
                tbBusinessLayer.Text   += clsGenerateCode.Add(TableName, dtColumns);
                tbBusinessLayer.Text   += clsGenerateCode.Update(TableName, dtColumns);
                tbBusinessLayer.Text   += clsGenerateCode.save(TableName, dtColumns);
                tbDataAccessLayer.Text += GenerateCodeDataLayer.AddNew(TableName, dtColumns);
                tbDataAccessLayer.Text += GenerateCodeDataLayer.Update(TableName, dtColumns);

            }

            if ((_Operation & (int)enOperations.enDelete) != 0)
            {
                foreach (string FieldName in DeleteList)
                {
                    tbBusinessLayer.Text += clsGenerateCode.Delete(TableName, dtColumns, FieldName);
                    tbDataAccessLayer.Text += GenerateCodeDataLayer.Delete(TableName, dtColumns, FieldName);
                }
            }

            if ((_Operation & (int)enOperations.enIsExist) != 0)
            {
                foreach (string FieldName in IsExistList)
                {
                    tbBusinessLayer.Text += clsGenerateCode.IsExist(TableName, dtColumns, FieldName);
                    tbDataAccessLayer.Text += GenerateCodeDataLayer.IsExist(TableName, dtColumns, FieldName);
                }
            }

            if ((_Operation & (int)enOperations.enGetRecordsList) != 0)
            {
                if (!string.IsNullOrEmpty(cmbRecordsList.Text))
                {
                    tbDataAccessLayer.Text += GenerateCodeDataLayer.GetRecordsList(cmbRecordsList.Text, TableName);
                    tbBusinessLayer.Text += clsGenerateCode.GetRecordsList(TableName, dtColumns);

                }
            }

        }
        private void _Generate(object sender,EventArgs e)
        {
            _Operation = 0;
            tbBusinessLayer.Clear();
            tbDataAccessLayer.Clear();

            string TableName = tbSingleName.Text;

            if (cbFields.Checked)
            {
                _Operation += (byte)enOperations.enFields;
            }
            if (cbFind.Checked)
            {
                _Operation += (byte)enOperations.enFind;
            }
            if (cbAddUpdate.Checked)
            {
                _Operation += (byte)enOperations.enAddUpdate;
            }
            if (cbDelete.Checked)
            {
                _Operation += (byte)enOperations.enDelete;
            }
            if (cbIsExist.Checked)
            {
                _Operation += (byte)enOperations.enIsExist;
            }
            if (cbGetRecordsList.Checked)
            {
                _Operation += (byte)enOperations.enGetRecordsList;
            }

            _GenerateCode();

        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            _Copy(tbDataAccessLayer);
        }

        private void cbFind_CheckedChanged(object sender, EventArgs e)
        {
            clbFind.Visible = (cbFind.Checked) ? true : false;
        }

        private void cbGetRecordsList_CheckedChanged(object sender, EventArgs e)
        {
            bool Status= (cbGetRecordsList.Checked) ? true : false;

            cmbRecordsList.Visible = Status;
            groupBox1.Visible = Status;
        }

        private void cbIsExist_CheckedChanged(object sender, EventArgs e)
        {
            clbIsExist.Visible = (cbIsExist.Checked) ? true : false;
        }

        private void _PopulateListWithCheckedItems(List<string> List,CheckedListBox clb)
        {
            List.Clear();

            for (int counter = 0; counter < clb.Items.Count; counter++)
            {
                if (clb.GetItemChecked(counter))
                    List.Add(clb.Items[counter].ToString());
            }
        }

        private void clbFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            _PopulateListWithCheckedItems(FindList, clbFind);
        }

        private void clbIsExist_SelectedIndexChanged(object sender, EventArgs e)
        {
            _PopulateListWithCheckedItems(IsExistList, clbIsExist);
        }

        private void CheckStatus(bool Status)
        {
            cbAddUpdate.Checked = Status;
            cbDelete.Checked    = Status;
            cbFields.Checked    = Status;
            cbFind.Checked      = Status;
            cbGetRecordsList.Checked = Status;
            cbIsExist.Checked = Status;
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAll.Checked)
                CheckStatus(true);
            else
                CheckStatus(false);
        }

        private void cldDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            _PopulateListWithCheckedItems(DeleteList, clbDelete);
        }

        private void cbDelete_CheckedChanged(object sender, EventArgs e)
        {
            clbDelete.Visible = (cbDelete.Checked) ? true : false;
        }

        private void rbTable_CheckedChanged(object sender, EventArgs e)
        {
            _PopulateComboBox(cmbRecordsList, "TABLE_NAME", clsDataBase.GetTablesList(cmbDatabases.Text));
        }

        private void rbView_CheckedChanged(object sender, EventArgs e)
        {
            _PopulateComboBox(cmbRecordsList, "TABLE_NAME", clsDataBase.GetViewsList(cmbDatabases.Text));
        }

        private void _Copy(TextBox textbox)
        {
            textbox.SelectAll();
            textbox.Copy();
        }
        private void btnCopyBusinessLayer_Click(object sender, EventArgs e)
        {
            _Copy(tbBusinessLayer);
        }
    }
}
