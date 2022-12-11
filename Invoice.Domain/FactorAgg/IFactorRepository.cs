using Invoice.ApplicationContracts.Factor;

namespace Invoice.Domain.FactorAgg;
public interface IFactorRepository : IBaseRepository<long, Factor>
{
    List<FactorItemDto> GetFactors();
    List<FactorDto> GetFactorWithItems();
    FactorItemDto GetFactor(long id);
}
