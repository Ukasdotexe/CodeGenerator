using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DataAccessLayer
{
    class GenerateCodeDataLayer
    {
        enum enMode { AddNew,Update}
        enMode _Mode = enMode.Update;

        private static Dictionary<string, string> _NullFieldsDict = new Dictionary<string, string>();
        private static string _GetFieldDataType(string DataType)
        {
            switch (DataType)
            {
                case "bigint":
                    return "long";
                case "int":
                    return "int";
                case "smallint":
                    return "short";
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

        private static string _GetFindBody(string tableName, DataTable dtColumns, string fieldName)
        {
            _NullFieldsDict.Clear();
            
            string Body = "";

            Body += "\n{";

            string query = $"\"SELECT * FROM [{tableName}s] WHERE {fieldName}=@{fieldName}\";";

            Body += "bool isFound = false;\n\n" +
                $"string query = {query}\n\n" +
                "clsdb.command = new SqlCommand(query, clsdb.connection);\n\n" +
                $"clsdb.AddWithValue(\"@{fieldName}\", {fieldName});\n\n" +
                $"try\n" +
                "{\n" +
                "clsdb.OpenConnection();\n" +
                "clsdb.reader = clsdb.command.ExecuteReader();\n\n" +
                "if (clsdb.reader.Read())\n{\n" +
                "isFound = true;\n";


            string DataType = "";
            string Field = "";

            foreach (DataRow Row in dtColumns.Rows)
            {
                DataType = _GetFieldDataType(Row["DATA_TYPE"].ToString());
                Field    = Row["COLUMN_NAME"].ToString();

                if (Field != fieldName)
                {
                    if (Row["IS_NULLABLE"].ToString() == "YES")
                        _NullFieldsDict.Add(Field, DataType);
                    else
                    Body += $"{Field}=({DataType})clsdb.reader[\"{Field}\"];\n";
                }
            }

            //Loop through Columns that allow null values

            Body += "\n";
            foreach (KeyValuePair<string, string> kvp in _NullFieldsDict)
            {
                Body += $"if (clsdb.reader[\"{kvp.Key}\"] == DBNull.Value)" +
                                $"\n{kvp.Key} = null;" +
                                $"\nelse\n" +
                                $"{kvp.Key} =({kvp.Value})clsdb.reader[\"{kvp.Key}\"];\n\n";
            }


            return Body += "}\n" +
                "clsdb.ResetDataReader();\n}\n" +
                "catch { }\n" +
                "finally { clsdb.CloseConnection();clsdb.ResetSqlCommand(); }\n" +
                "return isFound;\n}\n";
        }
        private static string _GetFindHeader(string tableName, DataTable dtColumns, string fieldName)
        {
            string Header = "";

           Header += $"public static bool Get{tableName}InfoBy{fieldName}(";

            string DataType = "";

            foreach (DataRow Row in dtColumns.Rows)
            {
                if (Row["COLUMN_Name"].ToString() != fieldName)
                {
                    Header += "ref ";
                }
                DataType = _GetFieldDataType(Row["DATA_TYPE"].ToString());

                if (Row["IS_NULLABLE"].ToString() == "YES" && DataType != "string")
                {
                    DataType += "?";
                }

                Header += $"{DataType} {Row["COLUMN_NAME"]},";
            }
            Header = Header.Substring(0, (Header.Length - 1));

            return Header += ")";
        }

        public static string Find(string TableName, DataTable dtColumns, string FieldName)
        {
            string Find = "";

            Find += _GetFindHeader(TableName, dtColumns, FieldName);
            return Find += _GetFindBody(TableName, dtColumns, FieldName);
        }

        private static string _GetAddNewBody(string tableName, DataTable dtColumns)
        {
            string body = _GetInsertQuery(tableName, dtColumns);

            body += "clsdb.command = new SqlCommand(query, clsdb.connection);\n\n" +

             $"clsdb.AddWithValue(\"@{dtColumns.Rows[0][0]}\",clsdb.AutoID(\"{tableName}s\"));\n";

            _AddWithValue(ref body, dtColumns, enMode.AddNew);


            return body += "\n\n" +
                  "try\n{\n" +
                  "clsdb.OpenConnection();\n" +
                 $"{tableName}ID = clsdb.command.ExecuteNonQuery();\n\n" +
                  "}\n" +
                  "catch { }\n" +
                  "finally { clsdb.CloseConnection();clsdb.ResetSqlCommand(); }\n\n" +
                 $"return {tableName}ID;\n" +
                  "}\n";
        }

        private static string _GetAddNewHeader(string tableName, DataTable dtColumns)
        {
            string Header = "";

            Header += $"public static int AddNew{tableName}(";

            string DataType = "";
            foreach (DataRow Row in dtColumns.Rows)
            {
                DataType = _GetFieldDataType(Row["DATA_TYPE"].ToString());

                if (Row["COLUMN_NAME"].ToString() != dtColumns.Rows[0][0].ToString())
                {
                    if (Row["IS_NULLABLE"].ToString() == "YES" && DataType!="string")
                    {
                        DataType += "?";
                    }
                    Header += $"{DataType} {Row["COLUMN_NAME"]},";
                }
                   
            }

            return Header = Header.Substring(0, (Header.Length - 1)) + ")";

        }

        public static string AddNew(string TableName,DataTable dtColumns)
        {
            string AddNew = "";

            AddNew += _GetAddNewHeader(TableName,dtColumns);
            return AddNew += _GetAddNewBody(TableName, dtColumns);
        }

        private static string _GetInsertQuery(string tableName, DataTable dtColumns)
        {
            string Body = "\n{\n";

            string query = "";

            string Tab = "\t\t\t";

            query += $"INSERT INTO [dbo].[{tableName}s]\n{Tab}(";

            foreach (DataRow Row in dtColumns.Rows)
            {
                query += $"[{Row["COLUMN_NAME"]}]\n{Tab},";
            }
            query = query.Substring(0, (query.Length - 1)) + ")\n" +
                $"{Tab}VALUES\n{Tab}(";

            foreach (DataRow Row in dtColumns.Rows)
            {
                query += $"@{Row["COLUMN_NAME"]}\n{Tab},";
            }
            query = query.Substring(0, (query.Length - 1)) + ")";



            return Body += $"int {tableName}ID =-1;\n\n" +
                 $"string query = @\"{query}\";" + "\n\n";

        }

        private static string _GetUpdateQuery(string tableName,DataTable dtColumns)
        {
            string Body = "\n{\n";

            string query = "";

            string Tab = "\t\t\t";

            query += $"UPDATE INTO [dbo].[{tableName}s]\n{Tab}SET ";


            string PrimaryKey = "";
            byte counter = 0;

            foreach (DataRow Row in dtColumns.Rows)
            {
                if (counter == 0)
                {
                    PrimaryKey = Row["COLUMN_NAME"].ToString(); counter++;
                }
                else
                query += $"[{Row["COLUMN_NAME"]}]=@{Row["COLUMN_NAME"]}\n{Tab},";

            }

            query = query.Substring(0, (query.Length - 1));

            query += $"WHERE {PrimaryKey}=@{PrimaryKey};";


            


            return Body += $"int Affectedrows = 0;\n\n" +
                 $"string query = @\"{query}\";" + "\n\n";
        }

        private static void _AddWithValue(ref string body,DataTable dtColumns,enMode Mode)
        {
            string Field = "";
            foreach (DataRow Row in dtColumns.Rows)
            {
                if (Mode == enMode.AddNew)
                {
                    Mode = enMode.Update; continue;
                }
                   

                Field = Row["COLUMN_NAME"].ToString();

                if (Row["IS_NULLABLE"].ToString() == "YES")
                {

                     body += $"if ({Field} == null)\n" +
                         "{\n" +
                        $"clsdb.AddWithValue(\"@{Field}\", DBNull.Value);\n" +
                        "}\nelse\n" +
                        "{\n" +
                        $"clsdb.AddWithValue(\"@{Field}\", {Field});\n" +
                        "}\n\n";
                }
                else
                {
                     body += $"clsdb.AddWithValue(\"@{Field}\",{Field});\n";
                }
            }
        }
        private static string _GetUpdateBody(string tableName, DataTable dtColumns)
        {
            string body = _GetUpdateQuery(tableName, dtColumns);

            body += "clsdb.command = new SqlCommand(query, clsdb.connection);\n\n";

           
                 _AddWithValue(ref body, dtColumns,enMode.Update);

            return body += "\n\n" +
                  "try\n{\n" +
                  "clsdb.OpenConnection();\n" +
                  "Affectedrows = clsdb.command.ExecuteNonQuery();\n\n" +
                  "}\n" +
                  "catch { }\n" +
                  "finally { clsdb.CloseConnection();clsdb.ResetSqlCommand(); }\n\n" +
                  "return Affectedrows>0;\n" +
                  "}\n";
        }
        private static string _GetUpdateHeader(string tableName, DataTable dtColumns)
        {
            string Header = "";

            Header += $"public static bool Update{tableName}(";

            string DataType = "";
            foreach (DataRow Row in dtColumns.Rows)
            {
                DataType = _GetFieldDataType(Row["DATA_TYPE"].ToString());

                if (Row["IS_NULLABLE"].ToString() == "YES" && DataType != "string")
                {
                    DataType += "?";
                }
                Header += $"{DataType} {Row["COLUMN_NAME"]},";
            }

            return Header = Header.Substring(0, (Header.Length - 1)) + ")";

        }
        public static string Update(string TableName, DataTable dtColumns)
        {
            string Update = "";

            Update += _GetUpdateHeader(TableName, dtColumns);
            return Update += _GetUpdateBody(TableName, dtColumns);

        }
        private static string _GetDeleteBody(string tableName, string fieldName)
        {
            string body = "";

           return body += "\n{\n int rowsAffected = -1;\n" +
                $"string query = @\"DELETE FROM [{tableName}s] WHERE {fieldName}=@{fieldName}\";\n\n" +
                $"clsdb.command = new SqlCommand(query, clsdb.connection);\n\n" +
                $"clsdb.AddWithValue(\"@{fieldName}\", {fieldName});\n\n" +
                $"try\n" +
                 "{\n" +
                 "clsdb.OpenConnection();\n" +
                 "rowsAffected = clsdb.command.ExecuteNonQuery();\n}\n" +
                 "catch { }\n" +
                 "finally { clsdb.CloseConnection(); clsdb.ResetSqlCommand(); }\n\n" +
                 "return rowsAffected > 0;\n}";


        }
        private static string _GetDeleteHeader(string TableName,string fieldName,DataTable dtColumns)
        {
            foreach(DataRow Row in dtColumns.Rows)
            {
                if (Row["COLUMN_NAME"].ToString() == fieldName)
                {
                    return $"public static bool Delete(" +
                        $"{_GetFieldDataType(Row["DATA_TYPE"].ToString())} {fieldName})";
                }
            }
            return null;
        }
        public static string Delete(string TableName,DataTable dtColumns, string fieldName)
        {
            string Delete = "";

            Delete += _GetDeleteHeader(TableName, fieldName, dtColumns);
            return Delete += _GetDeleteBody(TableName,fieldName);

        }

        private static string _GetIsExistHeader(string fieldName,DataTable dtColumns)
        {
            string Header = "";

            Header += "public static bool IsExist(";

            foreach(DataRow Row in dtColumns.Rows)
            {
                if (Row["COLUMN_NAME"].ToString() == fieldName)
                {
                   return Header += $"{_GetFieldDataType(Row["DATA_TYPE"].ToString())} " +
                        $"{fieldName})\n";
                }
            }
            return Header;
        }

        public static string IsExist(string TableName,DataTable dtColumns,string fieldName)
        {
            string Code = "";

            Code += _GetIsExistHeader(fieldName, dtColumns);
            Code += "{\n";
            Code += $"return clsdb.IsExist(\"{TableName}s\", \"{fieldName}\", {fieldName});\n";
            return Code += "}\n";
        }

        public static string GetRecordsList(string ViewName,string TableName)
        {
            string RecordsList = "";

            return RecordsList += $"public static DataTable Get{TableName}sList()" +
                "\n{\n" +
                $"return clsdb.GetRecordsList(\"{ViewName}\");" +
                "\n}\n";
        }
       
    }
}
