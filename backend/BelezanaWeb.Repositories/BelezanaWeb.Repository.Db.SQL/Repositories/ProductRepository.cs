using BelezanaWeb.Db.SQL.Repositories.Shared;
using BelezanaWeb.Product.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BelezanaWeb.Db.SQL.Repositories
{
    public class ProductRepository : GenericRelationalRepository<Product.Entities.Product>, IProductRepository
    {

        public ProductRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
