using AppFramework;
using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
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

    public OperationResult Create(CreateFactor commandFactor)
    {
        OperationResult operation = new();
        Factor factor = new()
        {
            Id = commandFactor.Id,
            Name = commandFactor.Name,
            Total = commandFactor.Total,
            Description = commandFactor.Description,
        };

        foreach (var item in commandFactor.Items)
        {
            Item factorItem = new()
            {
                FactorId = item.Id,
                Price = item.Price,
                Count = item.Count,
                Sum = item.Sum,
                ProductId = item.ProductId,
                UnitId = item.UnitId,
            };
        }

        _factorRepository.Create(factor);
        //_itemRepository.Create(factorItem);
        return operation.Succeeded();
    }

    public void Delete(int key)
    {
        _factorRepository.Delete(key);
    }

    public OperationResult Edit(EditFactor command)
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

    public EditFactor? GetDetails(long id)
    {
        return _factorRepository.GetDetails(id);
    }


    public List<FactorViewModel> GetFactors()
    {
        return _factorRepository.GetFactors();
    }
}
