namespace Model;
public class PropertyAmenity
{

    public uint PropertyAmenityId
    {
        get; set;
    }

    public decimal? Cost
    {
        get; set;
    }

    public string? Notes
    {
        get; set;
    }


    public virtual Amenity Amenity
    {
        get; set;
    }


    public virtual Property Property
    {
        get; set;
    }

}

