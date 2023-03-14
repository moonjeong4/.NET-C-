using System.ComponentModel.DataAnnotations;

namespace Election;

public class Party
{

    public uint PartyId { get; set; }

    [Required, MaxLength(128)]
    public string PartyName { get; set; }

    public string PartyWebsite { get; set; }

    public string PartyEmail { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; }
}
