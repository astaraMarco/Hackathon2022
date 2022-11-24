
using MySql.Data.MySqlClient;
using System.Data;

namespace Reuse_it.Models.Infrastructure
{
    public class DBAccessor : IDBAccessor
    {
        public DataSet Query(string query)
        {

            using (var conn = new MySqlConnection("Server=localhost;Database=reuseit_db;User=root;Password=;")) {
                conn.Open();
                using (var cmb = new MySqlCommand(query, conn)) {
                    using (var reader = cmb.ExecuteReader()) {
                        var dataS= new DataSet();
                        var dataT=new DataTable();
                        dataS.Tables.Add(dataT);
                        dataT.Load(reader);
                        return dataS;
                    }
                }
            }

        }
    }
}
