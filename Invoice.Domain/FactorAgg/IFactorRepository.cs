using Invoice.ApplicationContracts.Factor;

namespace Invoice.Domain.FactorAgg;
public interface IFactorRepository : IBaseRepository<long, Factor>
{
    List<FactorDto> GetFactors();
    EditFactor GetDetails(long id);

}
