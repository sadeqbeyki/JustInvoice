using AppFramework;

namespace Invoice.ApplicationContracts.Factor;

public interface IFactorApplication
{
    OperationResult Create(CreateFactor command);
    OperationResult Edit(EditFactor command);
    EditFactor? GetDetails(long id);
    List<FactorViewModel> GetFactors();
    void Delete(int key);

}
