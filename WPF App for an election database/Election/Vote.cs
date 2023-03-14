using System.ComponentModel.DataAnnotations;

namespace Election;

public class Vote
{

    public uint VoteId { get; set; }

    [Required]
    public DateTime CastTime { get; set; }

    public virtual Candidate Candidate { get; set; }
}
