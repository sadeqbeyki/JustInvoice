using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JI.ApplicationContracts.Items;

public class ItemDto
{
    [Key]
    public long Id { get; set; }
    public string CreationDate { get; set; }
    [Required]
    [Range(1, 999999, ErrorMessage = "مقدار باید بین 100 و 999999 باشد")]
    [DisplayName("قیمت کنونی کالا")]
    public long Price { get; set; }
    [Required]
    [Range(1, 999999, ErrorMessage = "مقدار باید بین 1 و 999999 باشد")]
    [DisplayName("تعداد کالا")]
    public long Count { get; set; }
    public long Sum { get; set; }
    public long ProductId { get; set; }
    public string Product { get; set; }
    public long UnitId { get; set; }
    public string Unit { get; set; }
    public long InvoiceId { get; set; }
    public string Invoice { get; set; }
    [NotMapped]
    public bool IsDeleted { get; set; } = false;
}
