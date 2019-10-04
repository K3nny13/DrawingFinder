using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SQLite;
using Dapper;
using System.Windows;

namespace DrawingFinder
{
	public static class SqliteDataAccess
	{
		public static List<Folder> LoadFolders(string search)
		{
			try {
				using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString())) {
					string query = string.Format("select * from drawing_locations where folder_name like '%{0}%'", search);
					var output = cnn.Query<Folder>(query, new DynamicParameters());
	
					return output.ToList();
				}
			}
			catch {
				MessageBox.Show("Database not in location");
				var error = new Folder("Database not in location", "Database not in location");
				var error_list = new List<Folder>();
				error_list.Add(error);
				return error_list;
			}
		}

		private static string LoadConnectionString(string id = "Default")
		{
			return ConfigurationManager.ConnectionStrings[id].ConnectionString;
		}
	}
}
