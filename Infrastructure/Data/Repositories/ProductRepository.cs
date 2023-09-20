using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly StoreDbContext _context;
        public ProductRepository(StoreDbContext context)
        {
            _context = context;
        }

    Task<IReadOnlyList<ProductBrand>> IProductRepository.GetProductBrandsAsync()
    {
        throw new NotImplementedException();
    }

    Task<Product> IProductRepository.GetProductByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    Task<IReadOnlyList<Product>> IProductRepository.GetProductsAsync()
    {
        throw new NotImplementedException();
    }

    Task<IReadOnlyList<ProductType>> IProductRepository.GetProductTypesAsync()
    {
        throw new NotImplementedException();
    }
}
