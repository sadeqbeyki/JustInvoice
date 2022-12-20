using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Invoice.ApplicationContracts.Items;

public class ItemDto
{
    [Key]
    public long Id { get; set; }
    public string CreationDate { get; set; }
    [Required]
    [Range(100,999999, ErrorMessage = "مقدار باید بین 100 و 999999 باشد")]
    [DisplayName("قیمت کنونی کالا")]
    public long Price { get; set; }
    public long Count { get; set; }
    public long Sum { get; set; }
    public long ProductId { get; set; }
    public string Product { get; set; }
    public long UnitId { get; set; }
    public string Unit { get; set; }
    //[ForeignKey("Factor")]
    public long InvoiceId { get; set; }
    public string Invoice { get; set; }
}
