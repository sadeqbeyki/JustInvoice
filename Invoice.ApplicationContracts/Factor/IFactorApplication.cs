using AppFramework;

namespace Invoice.ApplicationContracts.Factor;

public interface IFactorApplication
{
    OperationResult Create(FactorItemDto command);
    OperationResult Edit(FactorDto command);
    FactorDto? GetDetails(long id);
    List<FactorItemDto> GetFactors();
    void Delete(int key);

}
