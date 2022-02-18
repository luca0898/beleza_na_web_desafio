using BelezanaWeb.Domain.Entities;
using System.Collections.Generic;
using Xunit;

namespace BelezanaWeb.Tests.Unit.Domain
{
    public class InventoryEntity
    {
        [Fact]
        public void InventoryQuantity_ShouldBeEqualToTheSumOfTheQuantitiesInTheWarehouses()
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
                        },
                        new()
                        {
                            Quantity = 10
                        }
                    }
                }
            };

            Assert.True(entity.Inventory.Quantity == 20);
        }
    }
}
