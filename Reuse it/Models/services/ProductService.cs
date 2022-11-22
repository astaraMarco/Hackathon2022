using Reuse_it.Models.viewModels;

namespace Reuse_it.Models.services
{
    public class ProductService
    {
        public List<ProductViewModel> GetProduct()
        {
            var selled = new List<ProductViewModel>();
            //generazione statica dei prodotti 
            for (int i = 0; i < 10; i++)
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
            }
            return selled;
        }

        public ProductViewModel GetProduct(int id)
        {
            var i = 2;
            var tmp = new ProductViewModel();
            tmp.Id = i;
            tmp.descrizione = "bla bla bla bla bla";
            tmp.usura = Enumerations.Usury.nuovo;
            tmp.nome = i.ToString();
            tmp.size = new Size(i * 3, i / 5, i + 2);
            tmp.foto = new images.image(i, "/image/" + i.ToString() + ".jpg");
            tmp.priceBuy = i * 10;
            tmp.priceRent = i * 10 / (i * 2 + 1);
            return tmp;
            
        }
    }
}
