using Invoice.ApplicationContracts.Factor;
using Invoice.Domain.ItemAgg;
using Invoice.Domain.ProductAgg;

namespace Invoice.Domain.FactorAgg;
public interface IFactorRepository : IBaseRepository<long, Factor>
{
    List<FactorItemDto> GetFactors();
    EditFactor GetDetails(long id);


}
