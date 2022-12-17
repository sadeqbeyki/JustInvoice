using AppFramework;
using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
using Invoice.Domain.FactorAgg;
using Invoice.Domain.ItemAgg;

namespace Invoice.ApplicationServices;

public class FactorApplication : IFactorApplication
{
    private readonly IFactorRepository _factorRepository;
    private readonly IFileUploader _fileUploader;


    public FactorApplication(IFactorRepository factorRepository,
        IFileUploader fileUploader)
    {
        _factorRepository = factorRepository;
        _fileUploader = fileUploader;
    }

    public void Delete(int key)
    {
        _factorRepository.Delete(key);
    }

    public OperationResult Edit(FactorDto command)
    {
        OperationResult operation = new();
        var factor = _factorRepository.Get(command.Id);
        if (factor != null)
        {
            factor.Id = command.Id;
            factor.Name = command.Name;
            factor.Total = command.Total;
            factor.Description = command.Description;
        }
        _factorRepository.Update(factor);
        return operation.Succeeded();
    }

    public FactorDto GetFactor(long id)
    {
        return _factorRepository.GetFactor(id);
    }

    public List<FactorDto> GetFactors()
    {
        return _factorRepository.GetFactors();
    }

    public List<ItemDto> GetItems(long id)
    {
        return _factorRepository.GetItems(id);
    }

    public OperationResult Create(FactorDto model)
    {
        OperationResult operation = new();
        var photoPath = $"{model.Name}";
        var photoName = _fileUploader.Upload(model.Photo, photoPath);
        Factor factor = new()
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
        _factorRepository.Create(factor);
        return operation.Succeeded();
    }


}
