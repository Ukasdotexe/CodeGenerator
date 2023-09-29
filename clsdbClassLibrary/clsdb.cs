
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Guna.UI2.WinForms;


namespace clsdbClassLibrary
{
    public static class clsdb
    {

        static string ConnectionString = ConfigurationManager.ConnectionStrings[1].ConnectionString;

        private static SqlConnection _connection = new SqlConnection(ConnectionString);

        private static SqlDataReader _reader;

        private static SqlCommand _command;

        private static SqlCommand _command_2;

        private static SqlDataAdapter _adapter;

        public static SqlConnection connection { get => _connection; set => _connection = value; }
        public static SqlDataReader reader { get => _reader; set => _reader = value; }
        public static SqlCommand command { get => _command; set => _command = value; }
        public static SqlCommand command_2 { get => _command_2; set => _command_2 = value; }
        public static SqlDataAdapter adapter { get => _adapter; set => _adapter = value; }

        static public void OpenConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        static public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();

            }
        }

        static public void ResetDataAdapter()
        {
            adapter = null;
        }
        static public void ResetDataReader()
        {
            if (!reader.IsClosed)
            {
                reader.Close();
                reader = null;
            }
        }
        static public void ResetSqlCommand()
        {
            command = null;
        }
       
        public static T DataBindings<T>(string FieldName)
        {
            return (T)reader[FieldName];
        }
        public static void DataBindings<T>(object obj, ref T FieldName)
        {
            if (obj != DBNull.Value)
                FieldName = (T)obj;
        }

        static private void _DataBindings(ListControl control, DataTable DT, string DisplayMember, string ValueMember)
        {
            control.DataSource = DT;
            control.DisplayMember = DisplayMember;
            control.ValueMember = ValueMember;
        }
        static public void PopulateList(ListControl combobox, string TableName, string DisplayMember, string ValueMember)
        {
            DataTable DT = new DataTable();

            string Query = "SELECT * FROM " + TableName + " ";

            command = new SqlCommand(Query, connection);

            try
            {
                OpenConnection();

                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    DT.Load(reader);
                    _DataBindings(combobox, DT, DisplayMember, ValueMember);
                }
               
                ResetDataReader();
            }
            catch { }
            finally
            {
                CloseConnection();
                ResetSqlCommand();
            }

        }

        public static bool IsExist<T>(string TableName, string FieldName, T Value)
        {
            bool isFound = false;

            string query = "SELECT x=1 FROM [" + TableName + "] WHERE " +
                                            FieldName + "=@" + FieldName + "";

            command = new SqlCommand(query, connection);

            clsdb.AddWithValue("@" + FieldName + "", Value);

            try
            {
                OpenConnection();
                reader = command.ExecuteReader();
                isFound = reader.HasRows;

            }
            catch { }
            finally
            {
                CloseConnection();
                ResetSqlCommand();
            }

            return isFound;
        }

        public static DataTable GetRecordsList(string TableName)
        {
            DataTable dataTable = new DataTable();

            command = new SqlCommand("SELECT * FROM [" + TableName + "]", connection);

            try
            {
                OpenConnection();
                reader = command.ExecuteReader();

                if (reader.HasRows)
                    dataTable.Load(reader);

                ResetDataReader();

            }
            catch { }
            finally{ CloseConnection(); ResetSqlCommand(); }
            return dataTable;
        }

        static public void ShowForm(Form form)
        {
            if (Application.OpenForms[form.Name] == null)
            {
                form.Show();
            }
            else
                Application.OpenForms[form.Name].Focus();
        }
        static public void ShowForm(Form formToShow, Form frmToHide, bool IsMdiChild)
        {
            formToShow.Show();
            frmToHide.Hide();
        }

        static public void ShowForm(Form FormToOpen,Form FrmContainer)
        {
            if (Application.OpenForms[FormToOpen.Name] == null)
            {
                FormToOpen.MdiParent = FrmContainer;
                FormToOpen.Show();
            }
            else
                Application.OpenForms[FormToOpen.Name].Focus();
        }
        static public void AddWithValue(string Parameter, object Value)
        {
            command.Parameters.AddWithValue(Parameter, Value);
        }


        static public void AddWithValue(string Parameter, object Value,bool IsAllowNull)
        {
           
            if (Value.ToString() != "")
                AddWithValue(Parameter, Value);
            else
                AddWithValue(Parameter, DBNull.Value);
        }
        static public int AutoID(string Table)
        {
            int ID = -1;
            string Query = "SELECT COUNT(1) FROM [" + Table + "]";

            command_2 = new SqlCommand(Query, connection);

            OpenConnection();

            try
            {
                ID = (int)command_2.ExecuteScalar();
            }
            catch { }
            finally
            {
                CloseConnection();
                command_2 = null;
            }
            

            return ++ID;
        }
        static int GetRowIndex(DataGridView dgv)
        {
            return dgv.SelectedRows[0].Index;
        }
        static public string GetCellValue(DataGridView dgv, string CellName)
        {
            return dgv.Rows[GetRowIndex(dgv)].Cells[CellName].Value.ToString();
        }
        static public string GetCellValue(DataGridView dgv, int CellIndex)
        {
            return dgv.Rows[GetRowIndex(dgv)].Cells[CellIndex].Value.ToString();
        }

        static public T GetCellValue<T>(DataGridView dgv, int CellIndex)
        {
            return (T)dgv.SelectedCells[CellIndex].Value;
        }
        public static string Filter(string FieldName, TextBox Value)
        {
            return $"[{FieldName}] like '{Value.Text}%'";
        }
        public static string Filter(string FieldName, int Value)
        {
            return $"[{FieldName}] ={Value}";
        }









    }
}
