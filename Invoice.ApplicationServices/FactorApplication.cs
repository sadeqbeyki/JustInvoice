using AppFramework;
using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
using Invoice.Domain.FactorAgg;
using Invoice.Domain.ItemAgg;

namespace Invoice.ApplicationServices;

public class FactorApplication : IFactorApplication
{
    private readonly IFactorRepository _factorRepository;

    public FactorApplication(IFactorRepository factorRepository)
    {
        _factorRepository = factorRepository;
    }

    public OperationResult Create(CreateFactor command)
    {
        OperationResult operation = new();
        Factor factor = new()
        {
            Name = command.Name,
            Total = command.Total,
            Description = command.Description,
        };
        _factorRepository.Create(factor);
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
