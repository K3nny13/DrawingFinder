using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace DrawingFinder
{
    public static class SqliteDataAccess
    {
        public static List<Folder> LoadFolders(string search)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = string.Format("select * from drawing_locations where folder_name like '%{0}%'", search);
                var output = cnn.Query<Folder>(query, new DynamicParameters());

                return output.ToList();
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
