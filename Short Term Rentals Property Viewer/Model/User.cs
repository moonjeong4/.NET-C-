using System;

namespace Model;
public class User
{
    public uint UserId
    {
        get; set;
    }
    public string UserName
    {
        get; set;
    }
    public string? First
    {
        get; set;
    }
    public string? Last
    {
        get; set;
    }

    public string Email
    {
        get; set;
    }
    public DateTime LastLogin
    {
        get; set;
    }
    public DateTime Joined
    {
        get; set;
    }

    public string ImageFile
    {
        get; set;
    }

    public virtual Address Address
    {
        get; set;
    }
}

