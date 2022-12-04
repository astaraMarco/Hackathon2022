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
            var productsSet = db.Select(query);
            foreach (DataRow product in productsSet.Tables[0].Rows) {
                ProductViewModel productViewModel = ProductViewModel.mapRowSell(product);
                selled.Add(productViewModel);
            }
            return selled;
        }

        public async Task<int> addProductSell(ProductViewModel pr) {
            string campi = "nome:descrizione:grandezza:usura:price_buy";
            string campiFoto = "img:path:fk_prodotto";
            var esito = await db.InsertProduct(campi, campiFoto, pr);

            return esito;
            
        }


        public ProductViewModel GetProduct(int id)
        {

            string query = "select * from prodotto,foto where id_prodotto ="+id.ToString();
            var productsSet = db.Select(query);
            var product = productsSet.Tables[0].Rows[0];
            ProductViewModel productViewModel = ProductViewModel.mapRowSell(product);

            return productViewModel;


        }
    }
}
