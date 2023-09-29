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

namespace CodeGenerator
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Load += _Load;
            btnGenerate.Click += _Generate;
        }


        DataTable dt;
        private void _Load(object sender, EventArgs e)
        {
            clsDataBase.GetDatabasesList(ref cmbDatabases);
        }

        private void cmbDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CanFocus)
            {
                cmbTables.Items.Clear();
                DataTable dt = clsDataBase.GetTablesList(cmbDatabases.Text);

                foreach (DataRow row in dt.Rows)
                {
                    cmbTables.Items.Add(row["table_name"]);
                }

            }
        }

        private void cmbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = clsDataBase.RetrieveTableSchema(cmbDatabases.Text, cmbTables.Text);
            dataGridView1.DataSource = dt;
        }

        private void _Generate(object sender, EventArgs e)
        {
            tbBusinessLayer.Clear();
            tbDataAccessLayer.Clear();

            tbBusinessLayer.Text += clsGenerateCode.IntitializeClass(cmbTables.Text,
                 dataGridView1.DataSource as DataTable);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            tbBusinessLayer.Copy();
        }
    }
}
