using System.ComponentModel.DataAnnotations;

namespace Election;

public class Province
{
    public uint ProvinceId { get; set; }

    [Required, MaxLength(128)]
    public string ProvinceName { get; set; }

    [Required, MaxLength(128)]
    public string ShortCode { get; set; }

    public virtual ICollection<Riding> Ridings { get; set; }
}
