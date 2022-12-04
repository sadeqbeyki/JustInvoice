using Invoice.ApplicationContracts.Units;
using Invoice.Domain.UnitAgg;

namespace Invoice.ApplicationServices;
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
