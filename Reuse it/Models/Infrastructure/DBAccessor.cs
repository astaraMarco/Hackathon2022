using Microsoft.CodeAnalysis.CSharp.Syntax;
using MySql.Data.MySqlClient;
using Reuse_it.Models.images;
using Reuse_it.Models.viewModels;
using System.Data;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Reuse_it.Models.Infrastructure
{
    public class DBAccessor : IDBAccessor
    {
        public DataSet Select(string query)
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

       
         public async Task<int> InsertProduct(string campi,string campiFoto,ProductViewModel pr){

           
            string query = this.creaQuery("prodotto", campi.Split(":"));
            query += this.creaQuery("foto", campiFoto.Split(":"));


            using (var conn = new MySqlConnection("Server=localhost;Database=reuseit_db;User=root;Password=;"))
            {
                using (MySqlCommand? cmb = new MySqlCommand("", conn))
                {
                    conn.Open();
                    cmb.CommandText = query;

                    foreach (string s in campi.Split(":"))
                    {
                        switch (s)
                        {

                            case "nome":
                                cmb.Parameters.AddWithValue($"@{s}", pr.nome);
                                break;
                            case "descrizione":
                                cmb.Parameters.AddWithValue($"@{s}", pr.descrizione);
                                break;
                            case "grandezza":
                                cmb.Parameters.AddWithValue($"@{s}", pr.size.ToString());
                                break;
                            case "usura":
                                cmb.Parameters.AddWithValue($"@{s}", pr.usura.ToString());
                                break;
                            case "price_buy":
                                cmb.Parameters.AddWithValue($"@{s}", pr.priceBuy);
                                break;
                            case "price_rent":
                                cmb.Parameters.AddWithValue($"@{s}", pr.priceRent);

                                break;
                            default:
                                return -1;
                        }
                    }

                    await pr.foto.ConvertIFromFileInPath();
                    var data = image.convertToUpload(pr.foto);
                    if (data == null)
                    {
                        return -1;
                    }
                    MySqlParameter blob = new MySqlParameter("@img", MySqlDbType.Blob, data.Length);
                    blob.Value = data;
                    foreach (string s in campiFoto.Split(":"))
                    {
                        switch (s)
                        {
                            case "img":

                                cmb.Parameters.Add(blob);
                                break;
                            case "path":
                                cmb.Parameters.AddWithValue($"@{s}", pr.foto.pathFoto);
                                break;
                            case "fk_prodotto":
                                break;


                        }
                    }
                    //cmb = await this.InsertImage(campiFoto,pr.foto,cmb).Result;
                    
                    var result = await cmb.ExecuteNonQueryAsync();
                    if (!(result == -1)) {
                        return 1;
                    }
                    return 0;
                }
            }
        }

        private string creaQuery(string tabella,string[] campi ) {



            string query = $"INSERT INTO `{tabella}`(";
            foreach (var s in campi)
            {

                if (campi[(campi.Length - 1)] == s)
                {
                    query += $"`{s}`";
                }
                else
                {
                    query += $"`{s}`,";
                }

            }
            query += $") VALUES (";
            for (int i = 0; i < campi.Length; i++)
            {
                string s = campi[i];

                if (s == "fk_prodotto")
                {
                    query += "last_insert_id()";
                }
                else {
                    query += $"@{s}";
                    
                }
                if (i == campi.Length - 1)
                {
                    query += $"); ";
                }
                else
                {
                    query += $", ";
                }
            }


            return query;
        }

    }
}
