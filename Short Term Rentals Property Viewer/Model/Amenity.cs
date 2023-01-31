using System.Collections.Generic;

namespace Model;
public class Amenity
{

    public int AmenityId
    {
        get; set;
    }

    public string Name
    {
        get; set;
    }

    public virtual ICollection<PropertyAmenity> PropertyAmenities
    {
        get; set;
    }
}

