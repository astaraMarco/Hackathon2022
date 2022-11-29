using Reuse_it.Models.Infrastructure;
using Reuse_it.Models.viewModels;
using System.Data;

namespace Reuse_it.Models.services
{
    public class ProductService : IProductService
    {
        IDBAccessor db;
        public ProductService(IDBAccessor db)
        {
            this.db = db;
        }
        public List<ProductViewModel> GetProducts()
        {
            var selled = new List<ProductViewModel>();
            string query = "select * from prodotto,foto where fk_prodotto = id_prodotto";
            DataSet productsSet = db.Query(query);
            foreach (DataRow product in productsSet.Tables[0].Rows) {
                ProductViewModel productViewModel = ProductViewModel.mapRow(product);
                selled.Add(productViewModel);
            }
            return selled;
        }

        public Task<bool> addProduct(ProductViewModel pr) {
            return db.QueryAdd(pr); ;
        }


        public ProductViewModel GetProduct(int id)
        {
            return new ProductViewModel();

        }
    }
}
