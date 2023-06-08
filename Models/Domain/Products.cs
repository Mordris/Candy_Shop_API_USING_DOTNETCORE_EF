using System.Security.Policy;

namespace CandyShopAPI.Models.Domain
{
    public class Products
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public long Price { get; set; }
        public string ImageURL { get; set; }
    }
}
