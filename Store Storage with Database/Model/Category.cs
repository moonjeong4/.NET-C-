using System.Collections.Generic;

namespace D6Lab4.Model;

public class Category
{
    public uint CategoryId { get; set; }

    public string CategoryName { get; set; }



    public virtual ICollection<Product> Products { get; set; }

}
