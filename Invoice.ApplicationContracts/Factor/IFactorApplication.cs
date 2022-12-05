using AppFramework;
using Invoice.ApplicationContracts.Items;

namespace Invoice.ApplicationContracts.Factor;

public interface IFactorApplication
{
    OperationResult Create(CreateFactor commandFactor);
    OperationResult Edit(EditFactor command);
    EditFactor? GetDetails(long id);
    List<FactorViewModel> GetFactors();
    void Delete(int key);

}
