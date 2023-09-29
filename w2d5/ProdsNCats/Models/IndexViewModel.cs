#pragma warning disable CS8618
namespace ProdsNCats.Models;

public class IndexViewModel
{
    public Product Product;
    public List<Product> AllProducts;
    public Category Category;
    public List<Category> AllCategories;
    public Association Association;
    public List<Association> Associations;

    public int CategoryId;
    public int ProductId;

}