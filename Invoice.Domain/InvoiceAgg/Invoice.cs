using Invoice.Domain.ItemAgg;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Invoice.Domain.InvoiceAgg;

public class Invoice : BaseEntity
{
    public Invoice()
    {
        Items = new List<Item>();
    }

    public string Name { get; set; }

    public long Total { get; set; }

    public string Description { get; set; }
    public List<Item> Items { get; set; }

    public string PhotoUrl { get; set; }
    //[Required(ErrorMessage = "Please Choose The Profile Photo")]
    [Display(Name = "Profile Photo")]
    [NotMapped]
    public string Photo { get; set; }

    public void Edit(List<Item> items)
    {
        Items = items;
    }
}
