

namespace Model;
public class Image
{
    public uint ImageId
    {
        get; set;
    }

    public string File
    {
        get; set;
    }
    public string? Caption
    {
        get; set;
    }

    public bool IsThumbnail
    {
        get; set;
    } = false;

    public uint PropertyId { get; set; }

    public virtual Property Property
    {
        get; set;
    }

}

