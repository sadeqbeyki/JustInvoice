using JI.Domain.UnitAgg;
using JI.DomainContracts.Units;
using JI.Persistence.Common;

namespace JI.Persistence.Units;

public class UnitRepository : BaseRepository<long, Unit>, IUnitRepository
{
    private readonly InvoiceContext _invoiceContext;

    public UnitRepository(InvoiceContext invoiceContext) : base(invoiceContext)
    {
        _invoiceContext = invoiceContext;
    }

    public List<UnitDto> GetUnits()
    {
        return _invoiceContext.Units.Select(c => new UnitDto
        {
            Id = c.Id,
            Name = c.Name,

        }).ToList();
    }
}
