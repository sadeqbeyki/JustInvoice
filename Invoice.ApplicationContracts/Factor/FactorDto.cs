using AppFramework;
using Invoice.ApplicationContracts.Items;
using System.ComponentModel.DataAnnotations;

namespace Invoice.ApplicationContracts.Factor;

public class FactorDto
{
    [Key]
    public long Id { get; set; }

    public string CreationDate { get; set; }
    [Required]
    [StringLength(150)]
    public string Name { get; set; }
    public long Total { get; set; }
    [Required]
    [StringLength(250)]
    public string Description { get; set; }
    public List<ItemDto> Items { get; set; } = new List<ItemDto>();

    public FactorDto()
    {
        CreationDate = DateTime.Now.ToFarsi();
    }
}