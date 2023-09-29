using CodeGenerator.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator.BusinessLayer
{
    class clsDataBase
    {
        public static void GetDatabasesList(ref ComboBox combobox1)
        {
            DatabaseDataLayer.GetDatabasesList(ref combobox1);
        }
        public static DataTable GetDatabasesList()
        {
            return DatabaseDataLayer.GetDatabasesList();
        }

        public static DataTable GetTablesList(string DataBaseName)
        {
            return DatabaseDataLayer.GetTablesList(DataBaseName);
        }

        public static DataTable GetViewsList(string DataBaseName)
        {
            return DatabaseDataLayer.GetViewsList(DataBaseName);
        }

            public static DataTable RetrieveTableSchema(string DataBaseName, string TableName)
        {
            return DatabaseDataLayer.RetrieveTableSchema(DataBaseName, TableName);
        }

    }
}
