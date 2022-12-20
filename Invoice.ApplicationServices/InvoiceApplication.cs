using AppFramework;
using Invoice.ApplicationContracts.Invoice;
using Invoice.ApplicationContracts.Items;
using Invoice.Domain.InvoiceAgg;
using Invoice.Domain.ItemAgg;

namespace Invoice.ApplicationServices;

public class InvoiceApplication : IInvoiceApplication
{
    private readonly IInvoiceRepository _invoiceRepository;
    private readonly IFileUploader _fileUploader;


    public InvoiceApplication(IInvoiceRepository factorRepository,
        IFileUploader fileUploader)
    {
        _invoiceRepository = factorRepository;
        _fileUploader = fileUploader;
    }


    #region Create
    public OperationResult Create(InvoiceDto model)
    {
        OperationResult operation = new();
        var photoPath = $"{model.Name}";
        var photoName = _fileUploader.Upload(model.Photo, photoPath);
        Domain.InvoiceAgg.Invoice factor = new()
        {
            Id = model.Id,
            Name = model.Name,
            Description = model.Description,
            PhotoUrl = photoName,
            Items = new List<Item>(model.Items.Select(i => new Item
            {
                Price = i.Price,
                Count = i.Count,
                Sum = i.Price * i.Count,
                ProductId = i.ProductId,
                UnitId = i.UnitId,

            }).ToList()),
            Total = model.Total
        };
        _invoiceRepository.Create(factor);
        return operation.Succeeded();
    }

    #endregion


    #region Read
    public InvoiceDto GetDetails(long id)
    {
        return _invoiceRepository.GetDetails(id);
    }
    public InvoiceDto GetInvoice(long id)
    {
        return _invoiceRepository.GetInvoice(id);
    }

    public List<InvoiceDto> GetInvoices()
    {
        return _invoiceRepository.GetInvoices();
    }

    public List<ItemDto> GetItems(long id)
    {
        return _invoiceRepository.GetItems(id);
    }
    #endregion


    #region Update
    public OperationResult Update(InvoiceDto model)
    {
        OperationResult operation = new();
        var invoice = _invoiceRepository.Get(model.Id);
        var items = invoice.Items.ToList();

        var photoPath = $"{model.Name}";
        var photoName = _fileUploader.Upload(model.Photo, photoPath);

        if (invoice != null)
        {
            invoice.Id = model.Id;
            invoice.Name = model.Name;
            invoice.Description = model.Description;
            invoice.PhotoUrl = photoName;
            invoice.Items = model.Items.Select(i => new Item
            {
                Price = i.Price,
                Count = i.Count,
                Sum = i.Price * i.Count,
                ProductId = i.ProductId,
                UnitId = i.UnitId,

            }).ToList();
            invoice.Total = model.Total;
        }
        _invoiceRepository.Update(invoice);
        return operation.Succeeded();
    }
    #endregion


    #region Delete
    public void Delete(int key)
    {
        _invoiceRepository.Delete(key);
    }

    public InvoiceDto GetDelete(long id)
    {
        return _invoiceRepository.GetDelete(id);
    }


    #endregion





}
