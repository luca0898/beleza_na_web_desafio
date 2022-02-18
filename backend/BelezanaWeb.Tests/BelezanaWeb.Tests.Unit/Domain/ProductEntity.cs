using BelezanaWeb.Domain.Entities;
using System.Collections.Generic;
using Xunit;

namespace BelezanaWeb.Tests.Unit.Domain
{
    public class ProductEntity
    {
        [Fact]
        public void ProductIsMarketable_MustBeTrue_WhenInventoryQuantityIsGreaterThenZero()
        {
            Product entity = new()
            {
                Inventory = new()
                {
                    Warehouses = new List<Warehouse>()
                    {
                        new()
                        {
                            Quantity = 10
                        }
                    }
                }
            };

            Assert.True(entity.IsMarketable);
        }

        [Fact]
        public void ProductIsMarketable_MustBeFalse_WhenProductHasNoInventory()
        {
            Product entity = new();

            Assert.False(entity.IsMarketable);
        }
    }
}
