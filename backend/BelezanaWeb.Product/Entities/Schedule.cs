using BelezanaWeb.Product.Entities.Shared;
using System;

namespace BelezanaWeb.Product.Entities
{
    public class Schedule : Entity
    {
        public DateTime Date { get; set; }

        public bool ProcedurePerformed { get; set; }
    }
}
