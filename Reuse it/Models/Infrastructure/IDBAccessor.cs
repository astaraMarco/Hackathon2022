using System.Data;

namespace Reuse_it.Models.Infrastructure
{
    public interface IDBAccessor
    {
        DataSet Query(string query);
        bool QueryAdd(string query);
    }
}
