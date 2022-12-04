using MySql.Data.MySqlClient;
using Reuse_it.Models.images;
using Reuse_it.Models.viewModels;
using System.Data;

namespace Reuse_it.Models.Infrastructure
{
    public interface IDBAccessor
    {
        DataSet Select(string query);
        Task<int> InsertProduct(string campi,string campiFoto,ProductViewModel pr);

        Task delete(string query);
    }
}
