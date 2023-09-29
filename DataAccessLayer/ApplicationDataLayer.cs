using clsdbClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.DataAccessLayer
{
    class ApplicationDataLayer
	{
		public static bool GetApplicationInfoByApplicationID(int ApplicationID, ref string ApplicationNo, ref DateTime ApplicationDate, ref int PersonID, ref int ServiceID, ref int? LicenceClassID, ref byte ApplicationStatus)
		{
			bool isFound = false;

			string query = "SELECT * FROM [Applications] WHERE ApplicationID=@ApplicationID";

			clsdb.command = new SqlCommand(query, clsdb.connection);

			clsdb.AddWithValue("@ApplicationID", ApplicationID);

			try
			{
				clsdb.OpenConnection();
				clsdb.reader = clsdb.command.ExecuteReader();

				if (clsdb.reader.Read())
				{
					isFound = true;
					ApplicationDate = (DateTime)clsdb.reader["ApplicationDate"];
					PersonID = (int)clsdb.reader["PersonID"];
					ServiceID = (int)clsdb.reader["ServiceID"];
					ApplicationStatus = (byte)clsdb.reader["ApplicationStatus"];

					if (clsdb.reader["ApplicationNo"] == DBNull.Value)
						ApplicationNo = null;
					else
						ApplicationNo = (string)clsdb.reader["ApplicationNo"];

					if (clsdb.reader["LicenceClassID"] == DBNull.Value)
						LicenceClassID = null;
					else
						LicenceClassID = (int)clsdb.reader["LicenceClassID"];

				}
				clsdb.ResetDataReader();
			}
			catch { }
			finally { clsdb.CloseConnection(); clsdb.ResetSqlCommand(); }
			return isFound;
		}
		public static bool GetApplicationInfoByApplicationNo(ref int ApplicationID, string ApplicationNo, ref DateTime ApplicationDate, ref int PersonID, ref int ServiceID, ref int? LicenceClassID, ref byte ApplicationStatus)
		{
			bool isFound = false;

			string query = "SELECT * FROM [Applications] WHERE ApplicationNo=@ApplicationNo";

			clsdb.command = new SqlCommand(query, clsdb.connection);

			clsdb.AddWithValue("@ApplicationNo", ApplicationNo);

			try
			{
				clsdb.OpenConnection();
				clsdb.reader = clsdb.command.ExecuteReader();

				if (clsdb.reader.Read())
				{
					isFound = true;
					ApplicationID = (int)clsdb.reader["ApplicationID"];
					ApplicationDate = (DateTime)clsdb.reader["ApplicationDate"];
					PersonID = (int)clsdb.reader["PersonID"];
					ServiceID = (int)clsdb.reader["ServiceID"];
					ApplicationStatus = (byte)clsdb.reader["ApplicationStatus"];

					if (clsdb.reader["LicenceClassID"] == DBNull.Value)
						LicenceClassID = null;
					else
						LicenceClassID = (int)clsdb.reader["LicenceClassID"];

				}
				clsdb.ResetDataReader();
			}
			catch { }
			finally { clsdb.CloseConnection(); clsdb.ResetSqlCommand(); }
			return isFound;
		}
		public static int AddNewApplication(string ApplicationNo, DateTime ApplicationDate, int PersonID, int ServiceID, int? LicenceClassID, byte ApplicationStatus)
		{
			int ApplicationID = -1;

			string query = @"INSERT INTO [dbo].[Applications]
			([ApplicationID]
			,[ApplicationNo]
			,[ApplicationDate]
			,[PersonID]
			,[ServiceID]
			,[LicenceClassID]
			,[ApplicationStatus]
			)
			VALUES
			(@ApplicationID
			,@ApplicationNo
			,@ApplicationDate
			,@PersonID
			,@ServiceID
			,@LicenceClassID
			,@ApplicationStatus
			)";

			clsdb.command = new SqlCommand(query, clsdb.connection);

			clsdb.AddWithValue("@ApplicationID", clsdb.AutoID("Applications"));
			if (ApplicationNo == null)
			{
				clsdb.AddWithValue("@ApplicationNo", DBNull.Value);
			}
			else
			{
				clsdb.AddWithValue("@ApplicationNo", ApplicationNo);
			}

			clsdb.AddWithValue("@ApplicationDate", ApplicationDate);
			clsdb.AddWithValue("@PersonID", PersonID);
			clsdb.AddWithValue("@ServiceID", ServiceID);
			if (LicenceClassID == null)
			{
				clsdb.AddWithValue("@LicenceClassID", DBNull.Value);
			}
			else
			{
				clsdb.AddWithValue("@LicenceClassID", LicenceClassID);
			}

			clsdb.AddWithValue("@ApplicationStatus", ApplicationStatus);


			try
			{
				clsdb.OpenConnection();
				ApplicationID = clsdb.command.ExecuteNonQuery();

			}
			catch { }
			finally { clsdb.CloseConnection(); clsdb.ResetSqlCommand(); }

			return ApplicationID;
		}
		public static bool UpdateApplication(int ApplicationID, string ApplicationNo, DateTime ApplicationDate, int PersonID, int ServiceID, int? LicenceClassID, byte ApplicationStatus)
		{
			int Affectedrows = 0;

			string query = @"UPDATE INTO [dbo].[Applications]
			SET [ApplicationNo]=@ApplicationNo
			,[ApplicationDate]=@ApplicationDate
			,[PersonID]=@PersonID
			,[ServiceID]=@ServiceID
			,[LicenceClassID]=@LicenceClassID
			,[ApplicationStatus]=@ApplicationStatus
			WHERE ApplicationID=@ApplicationID;";

			clsdb.command = new SqlCommand(query, clsdb.connection);

			clsdb.AddWithValue("@ApplicationID", ApplicationID);
			if (ApplicationNo == null)
			{
				clsdb.AddWithValue("@ApplicationNo", DBNull.Value);
			}
			else
			{
				clsdb.AddWithValue("@ApplicationNo", ApplicationNo);
			}

			clsdb.AddWithValue("@ApplicationDate", ApplicationDate);
			clsdb.AddWithValue("@PersonID", PersonID);
			clsdb.AddWithValue("@ServiceID", ServiceID);
			if (LicenceClassID == null)
			{
				clsdb.AddWithValue("@LicenceClassID", DBNull.Value);
			}
			else
			{
				clsdb.AddWithValue("@LicenceClassID", LicenceClassID);
			}

			clsdb.AddWithValue("@ApplicationStatus", ApplicationStatus);


			try
			{
				clsdb.OpenConnection();
				Affectedrows = clsdb.command.ExecuteNonQuery();

			}
			catch { }
			finally { clsdb.CloseConnection(); clsdb.ResetSqlCommand(); }

			return Affectedrows > 0;
		}
		public static bool Delete(int ApplicationID)
		{
			int rowsAffected = -1;
			string query = @"DELETE FROM [Applications] WHERE ApplicationID=@ApplicationID";

			clsdb.command = new SqlCommand(query, clsdb.connection);

			clsdb.AddWithValue("@ApplicationID", ApplicationID);

			try
			{
				clsdb.OpenConnection();
				rowsAffected = clsdb.command.ExecuteNonQuery();
			}
			catch { }
			finally { clsdb.CloseConnection(); clsdb.ResetSqlCommand(); }

			return rowsAffected > 0;
		}
		public static bool Delete(string ApplicationNo)
		{
			int rowsAffected = -1;
			string query = @"DELETE FROM [Applications] WHERE ApplicationNo=@ApplicationNo";

			clsdb.command = new SqlCommand(query, clsdb.connection);

			clsdb.AddWithValue("@ApplicationNo", ApplicationNo);

			try
			{
				clsdb.OpenConnection();
				rowsAffected = clsdb.command.ExecuteNonQuery();
			}
			catch { }
			finally { clsdb.CloseConnection(); clsdb.ResetSqlCommand(); }

			return rowsAffected > 0;
		}
		public static bool IsExist(int ApplicationID)
		{
			return clsdb.IsExist("Applications", "ApplicationID", ApplicationID);
		}
		public static bool IsExist(string ApplicationNo)
		{
			return clsdb.IsExist("Applications", "ApplicationNo", ApplicationNo);
		}
		public static DataTable GetApplicationsList()
		{
			return clsdb.GetRecordsList("ApplicationDetails");
		}

	}
}
