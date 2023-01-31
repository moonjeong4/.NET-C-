using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model;
public class Property
{
    public uint PropertyId
    {
        get; set;
    }

    public string Name
    {
        get; set;
    }

    public string? Description
    {
        get; set;
    }

    public uint NumRooms
    {
        get; set;
    }

    [NotMapped]
    public string Amenities
    {
        get
        {
            string at = "Amenities: ";
            foreach (var pa in PropertyAmenities)
            {
                at = at + pa.Amenity.Name + "  ";
            }
            return at;
        }
    }

    [NotMapped]
    public string Thum
    {
        get
        {
            foreach (var pa in Images)
            {
                if (pa.IsThumbnail)
                {
                    return pa.File;
                }

            }
            return "none";
        }
    }


    [NotMapped]
    public float AverageRating
    {
        get
        {
            float ar = 0;
            foreach (var r in Ratings)
            {
                ar += r.Stars;
            }
            return ar / Ratings.Count;
        }
    }



    public virtual ICollection<Rating> Ratings { get; set; }

    public virtual ICollection<PropertyAmenity> PropertyAmenities
    {
        get; set;
    }

    public uint OwnerUserId { get; set; }

    public virtual User Owner
    {
        get; set;
    }

    public virtual Address Address
    {
        get; set;
    }

    public virtual ICollection<Image> Images
    {
        get; set;
    }
}

