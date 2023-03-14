using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Election;

public class Candidate
{
    public uint CandidateId { get; set; }

    [Required, MaxLength(128)]
    public string First { get; set; }

    [Required, MaxLength(128)]
    public string Last { get; set; }

    public string Website { get; set; }

    public string Email { get; set; }

    public virtual Party Party { get; set; }

    [Required]
    public virtual Riding Riding { get; set; }

    public virtual ICollection<Vote> Votes { get; set; }

    [NotMapped]
    public string Name
    {
        get
        {
            return First + " " + Last;
        }
        set
        {
            var strArr = value.Split(' ');
            First = strArr[0];
            Last = strArr[1];
        }
    }
}
