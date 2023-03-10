using System.Collections.Generic;

namespace D6Lab4.Model;

public class Manufacturer
{
    public uint ManufacturerId { get; set; }

    public string ManufacturerName { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public virtual ICollection<Product> ManufactureredProducts { get; set; }

}
