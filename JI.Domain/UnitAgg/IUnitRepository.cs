using JI.ApplicationContracts.Units;

namespace JI.Domain.UnitAgg;

public interface IUnitRepository : IBaseRepository<long, Unit>
{
    List<UnitViewModel> GetUnits();

}
