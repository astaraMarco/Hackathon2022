using Reuse_it.Enumerations;
using Reuse_it.Models.images;

namespace Reuse_it.Models.viewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? nome { get; set; }
        public string? descrizione { get; set; }
        public Size size { get; set; }
        public Usury usura { get; set; }
        public image foto { get; set; }
        public decimal priceBuy { get; set; }
        public decimal priceRent { get; set; }
    }
}
