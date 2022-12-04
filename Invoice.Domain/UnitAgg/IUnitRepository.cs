using Invoice.ApplicationContracts.Units;

namespace Invoice.Domain.UnitAgg;

public interface IUnitRepository : IBaseRepository<long, Unit>
{
    List<UnitViewModel> GetUnits();

}
