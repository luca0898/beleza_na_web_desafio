using BelezanaWeb.Product.Contracts.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BelezanaWeb.Product.Entities.Shared
{
    public class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}
