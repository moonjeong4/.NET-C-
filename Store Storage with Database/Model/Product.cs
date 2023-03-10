using System;
using System.Collections.Generic;

namespace D6Lab4.Model;

public class Product
{

    public uint ProductId { get; set; }

    public string ProductName { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public DateTime DateAvaillable { get; set; }

    public uint ManufacturerId { get; set; }

    public virtual Manufacturer Manufacturer { get; set; }



    public virtual ICollection<Category> Categories { get; set; }

}
