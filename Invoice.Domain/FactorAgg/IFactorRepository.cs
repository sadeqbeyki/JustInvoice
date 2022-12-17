using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;

namespace Invoice.Domain.FactorAgg;
public interface IFactorRepository : IBaseRepository<long, Factor>
{
    FactorDto GetFactor(long id);
    List<FactorDto> GetFactors();
    List<ItemDto> GetItems(long id);
}
