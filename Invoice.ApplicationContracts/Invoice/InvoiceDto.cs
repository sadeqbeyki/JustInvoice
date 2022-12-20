using AppFramework;
using Invoice.ApplicationContracts.Items;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Invoice.ApplicationContracts.Invoice;

public class InvoiceDto
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

    public InvoiceDto()
    {
        CreationDate = DateTime.Now.ToFarsi();
    }

    public string PhotoUrl { get; set; }

    public IFormFile Photo { get; set; }
}