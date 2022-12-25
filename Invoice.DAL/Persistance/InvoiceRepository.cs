using AppFramework;
using Invoice.ApplicationContracts.Invoice;
using Invoice.ApplicationContracts.Items;
using Invoice.DAL.Common;
using Invoice.Domain.InvoiceAgg;
using Invoice.Domain.ItemAgg;
using Invoice.Domain.ProductAgg;
using Microsoft.EntityFrameworkCore;

namespace Invoice.DAL.Persistance;

public class InvoiceRepository : BaseRepository<long, Domain.InvoiceAgg.Invoice>, IInvoiceRepository
{
    private readonly InvoiceContext _invoiceContext;

    public InvoiceRepository(InvoiceContext invoiceContext) : base(invoiceContext)
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


        //return _invoiceContext.Invoices
        //    .Include(itm => itm.Items)
        //    .Where(inv => inv.Id == id).FirstOrDefault();
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
    public InvoiceDto GetInvoice(long id)
    {
        return _invoiceContext.Invoices.Select(x => new InvoiceDto()
        {
            Id = x.Id,
            Name = x.Name,
            Total = x.Total,
            Description = x.Description,
            CreationDate = x.CreationDate.ToFarsi()
        }).FirstOrDefault(x => x.Id == id);
    }
    public List<ItemDto> GetItems(long id)
    {
        return _invoiceContext.Items
            .Where(x => x.InvoiceId == id)
            .Select(x => new ItemDto
            {
                Id = x.Id,
                Price = x.Price,
                Count = x.Count,
                Sum = x.Sum,
                ProductId = x.ProductId,
                Product = x.Product.Name,
                UnitId = x.UnitId,
                Unit = x.Unit.Name
            }).ToList();
    }

    public Domain.InvoiceAgg.Invoice GetInvoiceWithItems(long id)
    {
        return _invoiceContext.Invoices
            .Include(x => x.Items)
            .FirstOrDefault(x => x.Id == id);
    }
    public IQueryable<Item> GetItem(long id)
    {
        return _invoiceContext.Items.Where(x => x.InvoiceId == id);
    }


}
