namespace Lab3;

internal class Signee
{

    public string? First
    {
        get; set;
    }
    public string? Last
    {
        get; set;
    }
    public string? Number
    {
        get; set;
    }
    public string? Email
    {
        get; set;
    }

    public Signee(string? first, string? last, string? number, string? email)
    {
        First = first;
        Last = last;
        Number = number;
        Email = email;
    }

    public override string? ToString()
    {
        return First + ", " + Last + ", " + Number + ", " + Email;
    }
}
