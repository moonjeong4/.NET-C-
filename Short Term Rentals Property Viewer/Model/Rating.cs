namespace Model;
public class Rating
{
    public uint RatingId
    {
        get; set;
    }

    /// <summary>
    /// Star rating out of 5
    /// </summary>
    public uint Stars
    {
        get; set;
    }

    public string? Review
    {
        get; set;
    }

    public uint PropertyId { get; set; }
    public uint UserId { get; set; }

    public virtual Property Property
    {
        get; set;
    }

    public virtual User User
    {
        get; set;
    }


}

