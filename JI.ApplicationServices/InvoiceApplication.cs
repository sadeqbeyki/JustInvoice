using AppFramework;
using JI.ApplicationContracts.Invoice;
using JI.Domain.InvoiceAgg;
using JI.Domain.ItemAgg;

namespace JI.ApplicationServices;

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

        model.Items.RemoveAll(r => r.Count == 0);
        model.Items.RemoveAll(r => r.IsDeleted == true);

        var photoPath = $"{model.Name}";
        var photoName = _fileUploader.Upload(model.Photo, photoPath);
        Invoice factor = new()
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

    public List<InvoiceDto> GetInvoices()
    {
        return _invoiceRepository.GetInvoices();
    }
    #endregion


    #region Update
    public OperationResult Update(InvoiceDto model)
    {
        OperationResult operation = new();

        _invoiceRepository.DelEdit(model);

        var invoice = _invoiceRepository.Get(model.Id);

        model.Items.RemoveAll(r => r.Count == 0 && r.Price == 0);
        model.Items.RemoveAll(r => r.IsDeleted == true);

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
        _invoiceRepository.AddEdit(invoice);
        return operation.Succeeded();
    }

    public OperationResult Edit(InvoiceDto model)
    {
        var operation = new OperationResult();
        var invoice = _invoiceRepository.Get(model.Id);

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


}
