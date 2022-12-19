﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.ApplicationContracts.Items;

public class ItemDto
{
    [Key]
    public long Id { get; set; }
    public string CreationDate { get; set; }
    [Required]
    [Range(1,999999, ErrorMessage = "وارد نمودن بیش از این مقدار امکانپذیر نیست")]
    [DisplayName("قیمت کنونی کالا")]
    public long Price { get; set; }
    public long Count { get; set; }
    public long Sum { get; set; }
    public long ProductId { get; set; }
    public string Product { get; set; }
    public long UnitId { get; set; }
    public string Unit { get; set; }
    //[ForeignKey("Factor")]
    public long FactorId { get; set; }
    public string Factor { get; set; }
}
