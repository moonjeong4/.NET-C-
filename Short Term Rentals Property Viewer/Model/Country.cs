using System.ComponentModel.DataAnnotations;

namespace Model;
public class Country
{
    public uint CountryId
    {
        get; set;
    }

    [Required]
    public string Name
    {
        get; set;
    }
}

