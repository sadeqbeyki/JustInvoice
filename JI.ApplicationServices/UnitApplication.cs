using JI.ApplicationContracts.Units;
using JI.Domain.UnitAgg;

namespace JI.ApplicationServices;
public class UnitApplication : IUnitApplication
{
    private readonly IUnitRepository _unitRepository;

    public UnitApplication(IUnitRepository unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public List<UnitViewModel> GetUnits()
    {
        return _unitRepository.GetUnits();
    }
}
