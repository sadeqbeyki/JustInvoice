using Invoice.ApplicationContracts.Units;
using Invoice.DAL.Common;
using Invoice.Domain.UnitAgg;

namespace Invoice.DAL.Persistance;

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
