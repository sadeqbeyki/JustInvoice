using InvoiceFramework;
using JI.Domain.UnitAgg;
using JI.DomainContracts.Common;

namespace JI.DomainContracts.Units;

public interface IUnitRepository : IBaseRepository<long, Unit>
{
    List<UnitDto> GetUnits();
    OperationResult Create(UnitDto unit);
    OperationResult Update(UnitDto unit);

}
