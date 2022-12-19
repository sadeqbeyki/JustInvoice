using AppFramework;
using Invoice.ApplicationContracts.Items;

namespace Invoice.ApplicationContracts.Factor;

public interface IFactorApplication
{
    OperationResult Create(FactorDto command);
    OperationResult Update(FactorDto command);
    FactorDto GetFactor(long id);
    List<ItemDto> GetItems(long id);
    List<FactorDto> GetFactors();
    void Delete(int key);

}
