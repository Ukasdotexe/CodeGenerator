using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator.BusinessLayer
{
    class clsGenerateCode
    {
        private static string _Mode = @"private enum enMode { AddNew,Update}
                                        private enMode _Mode = enMode.Update;" + "\n";
        private static string _GetFieldDataType(string DataType)
        {
            switch (DataType)
            {
                case "bigint":
                    return "long";
                case "int":
                    return "int";
                case "smallint":
                    return "short" ;
                case "tinyint":
                    return "byte";
                case "bit":
                    return "bool";
                case "decimal":
                case "money":
                case "smallmoney":
                case "numeric":
                    return "decimal";
                case "float":
                    return "double";
                case "real":
                    return "float";
                case "datetime":
                case "smalldatetime":
                case "date":
                case "time":
                case "datetimeoffset":
                case "datetime2":
                    return "DateTime";
                default:
                    return "string";
            }
        }

        private static string _GetFieldsList(DataTable dtColumns)
        {
            string AddFields = "";

            string DataType = "";
            foreach(DataRow Row in dtColumns.Rows)
            {
                DataType = _GetFieldDataType(Row["DATA_TYPE"].ToString());

                if (Row["IS_NULLABLE"].ToString() == "YES" && DataType!="string")
                {
                    DataType += "?";
                }
                AddFields += $"public {DataType} " +
                    $"{Row["COLUMN_NAME"]} " + "{ get; set; }" + "\n";
            }

            return AddFields;
        }

        private static string _GetFindHeader(string tableName, DataTable dtColumns
            ,string FieldName)
        {
            string Parameter = "";


            foreach (DataRow Row in dtColumns.Rows)
            {
                if (Row["COLUMN_NAME"].ToString()==FieldName)
                {
                    Parameter += $"{_GetFieldDataType(Row["DATA_TYPE"].ToString())} " +
                    $"{Row["COLUMN_NAME"]}";
                    break;
                }
            }

            string Header = $"public static cls{tableName} Find({Parameter})";

            return Header;
        }
        public static string Add(string TableName, DataTable dtColumns)
        {
            string Insert = "";

            Insert += $"public bool _AddNew{TableName}()" + "\n{\n" +
                $"this.{dtColumns.Rows[0][0]}={TableName}DataLayer.AddNew{TableName}(";

            foreach(DataRow Row in dtColumns.Rows)
            {
                if (Row["COLUMN_NAME"] != dtColumns.Rows[0][0])
                {
                    Insert += $"{Row["COLUMN_NAME"]},";
                }
            }

            Insert = Insert.Substring(0, (Insert.Length - 1));

            Insert += ");\n\n" +
                $"return this.{dtColumns.Rows[0][0]} != -1;" +
                "\n}\n";

            return Insert;
        }
        public static string Update(string TableName, DataTable dtColumns)
        {
            string Update = "";

            Update += $"public bool _Update{TableName}()" + "\n{\n" +
                $"return {TableName}DataLayer.Update{TableName}(";

            foreach (DataRow Row in dtColumns.Rows)
            {
                Update += $"{Row["COLUMN_NAME"]},";
            }

            Update = Update.Substring(0, (Update.Length - 1));

            Update += ");\n}\n";


            return Update;
        }


        public static string Delete(string TableName, DataTable dtColumns,string fieldName)
        {
            string Delete = "";

            Delete += $"public static bool Delete(";

            foreach(DataRow dataRow in dtColumns.Rows)
            {
                if (dataRow["COLUMN_NAME"].ToString() == fieldName)
                {
                    Delete += $"{_GetFieldDataType(dataRow["DATA_TYPE"].ToString())} {fieldName})";
                    break;
                }

            }
            Delete += "\n{\n";
            return Delete += $"return {TableName}DataLayer.Delete({fieldName});\n" +
                "}\n";
        }
        public static string IsExist(string TableName, DataTable dtColumns
            ,string FieldName)
        {
            string Delete = "";

            foreach(DataRow Row in dtColumns.Rows)
            {
                if (Row["COLUMN_NAME"].ToString()==FieldName)
                {
                   return Delete += $"public  bool IsExist(" +
                        $"{_GetFieldDataType(Row["DATA_TYPE"].ToString())} " +
                        $"{Row["COLUMN_NAME"]})\n" +
                        "{\n" +
                        $"return {TableName}DataLayer.IsExist({Row["COLUMN_NAME"]});\n" +
                        "}\n";
                }
            }
            return "";
        }
        public static string save(string TableName, DataTable dtColumns)
        {
            string Save = "";

            return Save += "public bool save()\n{\n" +
                  "switch (_Mode)\n{\n" +
                  "case enMode.AddNew:\n{\n" +
                  $"if (_AddNew{TableName}())\n" +
                  "{\n" +
                  "_Mode = enMode.Update;\n" +
                  "return true;\n}\n" +
                  "return false;\n}\n" +
                  "case enMode.Update:\n" +
                  $"return _Update{TableName}();" +
                  "\n}\n" +
                  " return false;\n}\n";
        }
        public static string GetRecordsList(string TableName, DataTable dtColumns)
        {
            string List = "";

            return List += $"public static DataTable Get{TableName}sList()\n" +
                 "{\n" +
                 $"return {TableName}DataLayer.Get{TableName}sList();\n" +
                 "}\n";

        }
        private static string _GetFindBody(string tableName, DataTable dtColumns
            ,string FieldName)
        {
            string Body = "\n{\n";


            //Initialize Variables

            foreach(DataRow Row in dtColumns.Rows)
            {
                string DataType = "";
                string InitialValue = "";

                if (Row["COLUMN_Name"].ToString() !=  FieldName)
                {
                    DataType = _GetFieldDataType(Row["DATA_TYPE"].ToString());
                    InitialValue = _GetInitialValue(Row["DATA_TYPE"].ToString());

                    if (Row["IS_NULLABLE"].ToString() == "YES")
                    {
                        if (DataType != "string")
                        {
                            DataType += "?";
                        }
                            InitialValue = "null";
                    }
                    Body += $"{DataType} " +
                        $"{Row["COLUMN_NAME"]} = {InitialValue};\n";
                }

            }

            //If Statement of Find function

            Body += $"if({tableName}DataLayer.Get{tableName}InfoBy{FieldName}(";

            foreach (DataRow Row in dtColumns.Rows)
            {
                if (Row["COLUMN_Name"].ToString() != FieldName)
                {
                    Body += "ref ";
                }

                Body += $"{Row["COLUMN_NAME"]},";
            }

            Body = Body.Substring(0, (Body.Length - 1));
            Body += "))\n{\n";

            //if statement Body

            Body += $"return new cls{tableName}(";

            foreach (DataRow Row in dtColumns.Rows)
            {
                Body += $"{Row["COLUMN_NAME"]},";
            }

            Body = Body.Substring(0, (Body.Length - 1));

            Body += ");\n\n";
            Body += "}\nreturn null;";
            Body += "\n}\n";

            return Body;
        }
        public static string Find(string TableName, DataTable dtColumns,string FieldName)
        {
            string Find = "";

            Find += _GetFindHeader(TableName, dtColumns,FieldName);
            return Find += _GetFindBody(TableName, dtColumns, FieldName);
        }
        private static string _GetInitialValue(string DataType)
        {
            switch (DataType)
            {
                case "datetime":
                case "smalldatetime":
                case "date":
                case "time":
                case "datetimeoffset":
                case "datetime2":
                    return "DateTime.Now";
                case "varchar":
                case "char":
                case "text":
                case "nchar":
                case "nvarchar":
                case "ntext":
                    return "string.Empty";
                case "tinyint":
                    return "0";
                case "bit":
                    return "false";
                default:
                    return "-1";
            }
        }
        private static string _GetParameterizedConstructor(string tableName, DataTable dtColumns)
        {
            string Constructor = $"public cls{tableName}(" +
                $"{_GetConstructorParameters(dtColumns)}) " + "\n" + "{"+
                "\n" + "_Mode = enMode.AddNew;";

            foreach (DataRow Row in dtColumns.Rows)
            {
                Constructor += "\n" + $"this.{Row["COLUMN_NAME"]}={Row["COLUMN_NAME"]};";
            }
            return Constructor += "\n" + "}";
        }
        private static string _GetConstructorParameters(DataTable dtColumns)
        {
            string Parameters = "";

            string DataType = "";

            foreach(DataRow Row in dtColumns.Rows)
            {
                DataType = _GetFieldDataType(Row["DATA_TYPE"].ToString());

                if (Row["IS_NULLABLE"].ToString() == "YES" && DataType != "string")
                {
                    DataType += "?";
                }

                Parameters += $"{DataType} " +
                    $"{Row["COLUMN_NAME"]},";
            }
            return  Parameters.Substring(0, (Parameters.Length - 1));
        }
        private static string _GetDefaultConstructor(string tableName, DataTable dtColumns)
        {
            string Constructor = $"public cls{tableName}() " + "\n" + "{" +
                "\n" + "_Mode = enMode.AddNew;";

            foreach (DataRow Row in dtColumns.Rows)
            {
                Constructor += "\n" + $"{Row["COLUMN_NAME"]}=";

                if (Row["IS_NULLABLE"].ToString() == "YES" )
                {
                    Constructor += "null;";
                }
                else
                {
                    Constructor += $"{_GetInitialValue(Row["DATA_TYPE"].ToString())};";
                }
               
            }
            return Constructor += "\n" + "}";
        }
        public static string  IntitializeClass(string TableName, DataTable dtColumns)
        {
            string IntializeCode = "";

            IntializeCode += _Mode + Environment.NewLine;
            IntializeCode += _GetFieldsList(dtColumns) + Environment.NewLine;
            IntializeCode += _GetDefaultConstructor(TableName,dtColumns) + Environment.NewLine;
            return IntializeCode += _GetParameterizedConstructor(TableName,dtColumns);
        }

       
    }
}
