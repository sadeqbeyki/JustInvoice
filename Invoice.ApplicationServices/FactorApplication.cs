using AppFramework;
using Invoice.ApplicationContracts.Factor;
using Invoice.Domain.FactorAgg;
using Invoice.Domain.ItemAgg;

namespace Invoice.ApplicationServices;

public class FactorApplication : IFactorApplication
{
    private readonly IFactorRepository _factorRepository;
    private readonly IItemRepository _itemRepository;

    public FactorApplication(IFactorRepository factorRepository,
        IItemRepository itemRepository)
    {
        _factorRepository = factorRepository;
        _itemRepository = itemRepository;
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

    public FactorDto? GetDetails(long id)
    {
        return _factorRepository.GetDetails(id);
    }


    public List<FactorItemDto> GetFactors()
    {
        return _factorRepository.GetFactors();
    }

    public OperationResult Create(FactorItemDto command)
    {
        OperationResult operation = new();
        Factor factor = new()
        {
            Id = command.Id,
            Name = command.Name,
            Total = command.Total,
            Description = command.Description,
            Items = new List<Item>
            {
                new Item
                {
                    Price=command.Price,
                    Count= command.Count,
                    Sum=command.Price*command.Count,
                    ProductId=command.ProductId,
                    UnitId=command.UnitId,
                }
            }
        };
        _factorRepository.Create(factor);
        //_factorRepository.SaveChanges();
        return operation.Succeeded();
    }

}
