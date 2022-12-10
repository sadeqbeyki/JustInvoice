using AppFramework;

namespace Invoice.ApplicationContracts.Factor;

public interface IFactorApplication
{
    OperationResult Create(FactorItemDto command);
    OperationResult Edit(FactorItemDto command);
    FactorItemDto? GetFactor(long id);
    List<FactorItemDto> GetFactors();
    void Delete(int key);

}
