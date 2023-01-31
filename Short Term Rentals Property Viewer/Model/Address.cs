using System.ComponentModel.DataAnnotations;


namespace Model;
public class Address
{
    public uint AddressId
    {
        get; set;
    }


    [MaxLength(7)]
    public string Number
    {
        get; set;
    }


    public string Street
    {
        get; set;
    }

    public string Province
    {
        get; set;
    }
    public string City
    {
        get; set;
    }

    public string PostalCode
    {
        get; set;
    }

    public virtual Country Country
    {
        get; set;
    }


}

