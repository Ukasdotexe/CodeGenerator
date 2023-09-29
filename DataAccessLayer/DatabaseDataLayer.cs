using clsdbClassLibrary;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace CodeGenerator.DataAccessLayer
{
    class DatabaseDataLayer
    {

        public static void GetDatabasesList(ref ComboBox combobox1)
        {
            clsdb.PopulateList(combobox1, "sys.databases", "name", "database_id");
        }



        public static DataTable GetDatabasesList()
        {
            string query = "SELECT * FROM sys.databases WHERE database_id>4";
            return _GetList(query);
        }
        private static DataTable _GetList(string query)
        {
            DataTable dt = new DataTable();

            clsdb.command = new SqlCommand(query, clsdb.connection);

            try
            {
                clsdb.OpenConnection();
                clsdb.reader = clsdb.command.ExecuteReader();

                if (clsdb.reader.HasRows)
                    dt.Load(clsdb.reader);

                clsdb.ResetDataReader();

            }
            catch { }
            finally { clsdb.CloseConnection(); clsdb.ResetSqlCommand(); }


            return dt;

        }
        public static DataTable GetTablesList(string DataBaseName)
        {
            string query = @"
                            USE " + DataBaseName + ";" +
                            " SELECT table_name " +
                            " FROM INFORMATION_SCHEMA.TABLES" +
                            " WHERE [table_type] = 'BASE TABLE' " +
                            " ORDER BY table_name;";

            return _GetList(query);

        }

        public static DataTable GetViewsList(string DataBaseName)
        {
            string query = @"
                            USE " + DataBaseName + ";" +
                           " SELECT table_name " +
                           " FROM INFORMATION_SCHEMA.TABLES" +
                           " WHERE [table_type] = 'VIEW' " +
                           " ORDER BY table_name;";
            return _GetList(query);
        }

        public static DataTable RetrieveTableSchema(string DataBaseName,string TableName)
        {

            DataTable dt = new DataTable();

            string query = @"
                            USE " + DataBaseName + ";" +
                            " SELECT COLUMN_NAME,DATA_TYPE,IS_NULLABLE " +
                            " FROM INFORMATION_SCHEMA.COLUMNS" +
                            " WHERE [TABLE_NAME] = @TableName ;";

            clsdb.command = new SqlCommand(query, clsdb.connection);

            clsdb.AddWithValue("@DataBaseName", DataBaseName);
            clsdb.AddWithValue("@TableName", TableName);

            try
            {
                clsdb.OpenConnection();
                clsdb.reader = clsdb.command.ExecuteReader();

                dt.Load(clsdb.reader.HasRows ? clsdb.reader : null);

            }
            catch { }
            finally { clsdb.CloseConnection();clsdb.ResetSqlCommand(); }



            return dt;
        }
    }
}
