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
            //generazione statica dei prodotti 
            /*for (int i = 0; i < 10; i++)
            {
                var tmp = new ProductViewModel();
                tmp.Id = i;
                tmp.descrizione = "bla bla bla bla bla";
                tmp.usura = Enumerations.Usury.nuovo;
                tmp.nome = i.ToString();
                tmp.size = new Size(i * 3, i / 5, i + 2);
                tmp.foto = new images.image(i, "/image/" + i.ToString() + ".jpg");
                tmp.priceBuy = i * 10;
                tmp.priceRent = i * 10 / (i*2 + 1);
                selled.Add(tmp);
            }*/
            string query = "select * from prodotto,foto where fk_prodotto = id_prodotto";
            DataSet productsSet = db.Query(query);
            foreach (DataRow product in productsSet.Tables[0].Rows) {
                ProductViewModel productViewModel = ProductViewModel.mapRow(product);
                selled.Add(productViewModel);
            }
            return selled;
        }

        public ProductViewModel GetProduct(int id)
        {
            return new ProductViewModel();

        }
    }
}
