using System.ComponentModel.DataAnnotations;

namespace Election;

public class Riding
{
    public uint RidingId { get; set; }

    [Required, MaxLength(128)]
    public string RidingName { get; set; }

    [Required]
    public virtual Province Province { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; }

}
