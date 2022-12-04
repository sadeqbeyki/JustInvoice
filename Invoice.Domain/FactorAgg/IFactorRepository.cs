using Invoice.ApplicationContracts.Factor;

namespace Invoice.Domain.FactorAgg;
public interface IFactorRepository : IBaseRepository<long, Factor>
{
    List<FactorViewModel> GetFactors();
    EditFactor GetDetails(long id);

}
