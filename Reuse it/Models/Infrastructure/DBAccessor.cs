
using MySql.Data.MySqlClient;
using Reuse_it.Models.viewModels;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

         public async Task<bool> QueryAdd(ProductViewModel pr){
            using (var conn = new MySqlConnection("Server=localhost;Database=reuseit_db;User=root;Password=;"))
            {
                using (var cmb = new MySqlCommand("", conn))
                {

                    await pr.foto.ConvertIFromFileInPath();
                    byte[] data = pr.foto.convertToByte();
                    if (data == null) {
                        return false;
                    }
                    conn.Open();
                
                    cmb.CommandText = "INSERT INTO `prodotto`( `nome`, `descrizione`, `grandezza`, `usura`, `price_buy`, `price_rent`) " +
                        "VALUES (@pr.nome,@pr.descrizione,@pr.size,@pr.usura,@pr.priceBuy,'NULL');\r\n" +
                    "INSERT INTO `foto`(`img`,`fk_prodotto`) VALUES (@Data,last_insert_id()) ";
                    MySqlParameter blob = new MySqlParameter("@Data", MySqlDbType.Blob, data.Length);
                    blob.Value = data;

                    cmb.Parameters.Add(blob);
                    cmb.Parameters.AddWithValue("@pr.nome", pr.nome);
                    cmb.Parameters.AddWithValue("@pr.descrizione", pr.descrizione);
                    cmb.Parameters.AddWithValue("@pr.size", pr.size.ToString());
                    cmb.Parameters.AddWithValue("@pr.usura", pr.usura.ToString());
                    cmb.Parameters.AddWithValue("@pr.priceBuy", pr.priceBuy);
                   

                    int result = cmb.ExecuteNonQuery();
                    if (!(result == -1)) { 
                        return true;
                    }
                    return false;
                }
            }
        }


    }
}
