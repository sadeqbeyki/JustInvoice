using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;

namespace Invoice.Domain.FactorAgg;
public interface IFactorRepository : IBaseRepository<long, Factor>
{
    FactorItemDto GetFactor(long id);
    List<FactorItemDto> GetFactors();
    List<ItemDto> GetItems(long id);
}
