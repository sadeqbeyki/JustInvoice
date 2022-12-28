using JI.ApplicationContracts.Units;
using JI.Domain.UnitAgg;
using JI.Persistence.Common;

namespace JI.Persistence.Repositories;

public class UnitRepository : BaseRepository<long, Unit>, IUnitRepository
{
    private readonly InvoiceContext _invoiceContext;

    public UnitRepository(InvoiceContext invoiceContext) : base(invoiceContext)
    {
        _invoiceContext = invoiceContext;
    }

    public List<UnitViewModel> GetUnits()
    {
        return _invoiceContext.Units.Select(c => new UnitViewModel
        {
            Id = c.Id,
            Name = c.Name,

        }).ToList();
    }
}
