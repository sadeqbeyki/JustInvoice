using JI.Domain.UnitAgg;
using JI.DomainContracts.Units;

namespace JI.ApplicationServices.Units.Query;
public class GetAllUnitsQuery : IGetAllUnitsQuery
{
    private readonly IUnitRepository _unitRepository;

    public GetAllUnitsQuery(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public List<UnitDto> GetUnits()
    {
        return _unitRepository.GetUnits();
    }
}
