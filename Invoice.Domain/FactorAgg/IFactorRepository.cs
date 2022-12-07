using Invoice.ApplicationContracts.Factor;

namespace Invoice.Domain.FactorAgg;
public interface IFactorRepository : IBaseRepository<long, Factor>
{
    List<FactorItemDto> GetFactors();
    EditFactor GetDetails(long id);

}
