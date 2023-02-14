using System.Collections.Generic;

namespace D5Lab3.Model
{
    public partial class Menu
    {


        public uint MenuId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string MenuPhoto { get; set; } = null!;

        public virtual ICollection<Customer> Customers { get; set; }


    }
}
