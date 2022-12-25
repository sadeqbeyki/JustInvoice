using AppFramework;
using Invoice.ApplicationContracts.Invoice;
using Invoice.ApplicationContracts.Items;
using Invoice.Domain.InvoiceAgg;
using Invoice.Domain.ItemAgg;
using Invoice.Domain.ProductAgg;
using System.Linq.Expressions;

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

        //List<ItemDto> items = _invoiceRepository.GetItems(model.Id).ToList();
        //_invoiceRepository.PreEdit(items);

        var photoPath = $"{model.Name}";
        var photoUrl = _fileUploader.Upload(model.Photo, photoPath);

        if (invoice != null)
        {
            invoice.Id = model.Id;
            invoice.Name = model.Name;
            invoice.Description = model.Description;
            invoice.PhotoUrl = photoUrl;
            invoice.Total = model.Total;

            invoice.Items = model.Items.Select(i => new Item
            {
                Price = i.Price,
                Count = i.Count,
                Sum = i.Price * i.Count,
                ProductId = i.ProductId,
                UnitId = i.UnitId,
            }).ToList();

        }
        _invoiceRepository.Update(invoice);
        return operation.Succeeded();
    }
    #endregion


    #region Delete
    public OperationResult Delete(long id)
    {
        var operation = new OperationResult();
        var invoice = _invoiceRepository.GetDetails(id);
        if (invoice == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);
        _invoiceRepository.Delete(id);
        return operation.Succeeded();
    }
    #endregion


    public OperationResult Edit(InvoiceDto model)
    {
        var operation = new OperationResult();
        var invoice = _invoiceRepository.GetInvoiceWithItems(model.Id);
        var items = _invoiceRepository.GetItem(model.Id).ToList();

        if (invoice == null)
            return operation.Failed(ApplicationMessages.RecordNotFound);

        if (_invoiceRepository.Exists(x => x.Name == model.Name && x.Id != model.Id))
            return operation.Failed(ApplicationMessages.DuplicatedRecord);


        var photoPath = $"{model.Name}";
        var photoUrl = _fileUploader.Upload(model.Photo, photoPath);

        if (invoice != null)
        {
            invoice.Id = model.Id;
            invoice.Name = model.Name;
            invoice.Description = model.Description;
            invoice.PhotoUrl = photoUrl;
            invoice.Total = model.Total;

            foreach (var item in invoice.Items)
            {
                foreach (var i in model.Items)
                {

                    item.Id = i.Id;
                    item.InvoiceId = i.InvoiceId;
                    item.Price = i.Price;
                    item.Count = i.Count;
                    item.Sum = i.Price * i.Count;
                    item.ProductId = i.ProductId;
                    item.UnitId = i.UnitId;
                }

            }
            
        }

        _invoiceRepository.Update(invoice);
        return operation.Succeeded();
    }
}
