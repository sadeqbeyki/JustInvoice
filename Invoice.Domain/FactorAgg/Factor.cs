
using Invoice.Domain.ItemAgg;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Domain.FactorAgg
{
    public class Factor : BaseEntity
    {
        public Factor()
        {
            Items = new List<Item>();
        }
        public string Name { get; set; }
        public long Total { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        public string PhotoUrl { get; set; }
        [Required(ErrorMessage ="Please Choose The Profile Photo")]
        [Display(Name ="Profile Photo")]
        [NotMapped]
        public string Photo { get; set; }

    }
}
