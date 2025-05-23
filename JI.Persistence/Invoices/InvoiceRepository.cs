using InvoiceFramework;
using JI.ApplicationContracts.Invoice;
using JI.Domain.InvoiceAgg;
using JI.DomainContracts.Invoices;
using JI.Persistence.Common;
using Microsoft.EntityFrameworkCore;

namespace JI.Persistence.Invoices;

public class InvoiceRepository : BaseRepository<long, Invoice>, IInvoiceRepository
{
    private readonly InvoiceDbContext _invoiceContext;

    public InvoiceRepository(InvoiceDbContext invoiceContext) : base(invoiceContext)
    {
        _invoiceContext = invoiceContext;
    }

    public InvoiceDto GetDetails(long id)
    {
        return _invoiceContext.Invoices.Select(inv => new InvoiceDto()
        {
            Id = inv.Id,
            Name = inv.Name,
            Total = inv.Items.Sum(s => s.Sum),
            Description = inv.Description,
            CreationDate = inv.CreationDate.ToFarsi(),
            PhotoUrl = inv.PhotoUrl,
            Items = inv.Items.Select(itm => new ItemDto()
            {
                Id = itm.Id,
                Count = itm.Count,
                Price = itm.Price,
                Sum = itm.Count * itm.Price,
                Invoice = itm.Invoice.Name,
                InvoiceId = itm.InvoiceId,
                Product = itm.Product.Name,
                ProductId = itm.ProductId,
                Unit = itm.Unit.Name,
                UnitId = itm.UnitId,
                CreationDate = itm.CreationDate.ToFarsi()
            }).ToList()
        }).FirstOrDefault(x => x.Id == id);
    }
    public List<InvoiceDto> GetInvoices()
    {
        return _invoiceContext.Invoices.Select(c => new InvoiceDto
        {
            Id = c.Id,
            Name = c.Name,
            Total = c.Items.Sum(s => s.Sum),
            PhotoUrl = c.PhotoUrl,
            Description = c.Description,
            CreationDate = c.CreationDate.ToFarsi()
        }).ToList();
    }
    public void DelEdit(InvoiceDto invoice)
    {
        List<Item> items = _invoiceContext.Items
            .Where(item => item.InvoiceId == invoice.Id).ToList();
        _invoiceContext.Items.RemoveRange(items);
        _invoiceContext.SaveChanges();
    }
    public void AddEdit(Invoice invoice)
    {
        _invoiceContext.Attach(invoice);
        _invoiceContext.Entry(invoice).State = EntityState.Modified;
        _invoiceContext.Items.AddRange(invoice.Items);
        _invoiceContext.SaveChanges();
    }
}
