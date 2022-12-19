﻿using AppFramework;
using Invoice.ApplicationContracts.Items;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public string PhotoUrl { get; set; }
    [Required(ErrorMessage = "Please Choose The Profile Photo")]
    [Display(Name = "Profile Photo")]
    [NotMapped]
    public IFormFile Photo { get; set; }
}