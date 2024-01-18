

namespace WebApplicationASPNetDemo.Seeding;
using ViewModels.Product;

public static class ProductsData
{
  
    public static IEnumerable<ProductViewModel> Products = new List<ProductViewModel>()
    {
        new ProductViewModel()
        {
            Id= Guid.NewGuid(),
            Name = "Cheese",
            Price=7.00m
        },
        new ProductViewModel()
        {
            Id= Guid.NewGuid(),
            Name = "Ham",
            Price = 7.00m
        },
        new ProductViewModel()
        {
            Id= Guid.NewGuid(),
            Name = "Bread",
            Price = 1.00m
        }

    };
}
