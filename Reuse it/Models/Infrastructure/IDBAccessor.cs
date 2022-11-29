using Reuse_it.Models.viewModels;
using System.Data;

namespace Reuse_it.Models.Infrastructure
{
    public interface IDBAccessor
    {
        DataSet Query(string query);
        Task<bool> QueryAdd(ProductViewModel pr);
    }
}
