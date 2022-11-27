using Reuse_it.Models.viewModels;

namespace Reuse_it.Models.services
{
    public interface IProductService
    {
        ProductViewModel GetProduct(int id);
        List<ProductViewModel> GetProducts(); 
        public bool addProduct(string query);

    }
}