using AppFramework;

namespace Invoice.ApplicationContracts.Factor;

public interface IFactorApplication
{
    OperationResult Create(FactorDto command);
    OperationResult Edit(FactorDto command);
    FactorDto? GetDetails(long id);
    List<FactorDto> GetFactors();
    void Delete(int key);

}
