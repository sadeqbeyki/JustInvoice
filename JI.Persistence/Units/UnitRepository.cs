using InvoiceFramework;
using JI.Domain.UnitAgg;
using JI.DomainContracts.Units;
using JI.Persistence.Common;

namespace JI.Persistence.Units;

public class UnitRepository : BaseRepository<long, Unit>, IUnitRepository
{
    private readonly InvoiceDbContext _invoiceContext;

    public UnitRepository(InvoiceDbContext invoiceContext) : base(invoiceContext)
    {
        _invoiceContext = invoiceContext;
    }

    public OperationResult Create(UnitDto unit)
    {
        throw new NotImplementedException();
    }

    public List<UnitDto> GetUnits()
    {
        return _invoiceContext.Units.Select(c => new UnitDto
        {
            Id = c.Id,
            Name = c.Name,

        }).ToList();
    }

    public OperationResult Update(UnitDto unit)
    {
        throw new NotImplementedException();
    }
}
