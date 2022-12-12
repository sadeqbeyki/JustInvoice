using AppFramework;
using Invoice.ApplicationContracts.Items;

namespace Invoice.ApplicationContracts.Factor;

public interface IFactorApplication
{
    OperationResult Create(FactorItemDto command);
    OperationResult Edit(FactorItemDto command);
    FactorItemDto? GetFactor(long id);
    List<ItemDto> GetItems(long id);
    List<FactorItemDto> GetFactors();
    void Delete(int key);

}
