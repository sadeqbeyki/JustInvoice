using AppFramework;
using Invoice.ApplicationContracts.Factor;
using Invoice.DAL.Common;
using Invoice.Domain.FactorAgg;

namespace Invoice.DAL.Persistance;

public class FactorRepository : BaseRepository<long, Factor>, IFactorRepository
{
    private readonly InvoiceContext _invoiceContext;

    public FactorRepository(InvoiceContext invoiceContext) : base(invoiceContext)
    {
        _invoiceContext = invoiceContext;
    }

    public FactorItemDto GetFactor(long id)
    {
        return _invoiceContext.Factors.Select(x => new FactorItemDto()
        {
            Id = x.Id,
            Name = x.Name,
            Total = x.Total,
            Description = x.Description,
            CreationDate = x.CreationDate.ToFarsi()

        }).FirstOrDefault(x => x.Id == id);
    }

    public List<FactorItemDto> GetFactors()
    {
        return _invoiceContext.Factors.Select(c => new FactorItemDto
        {
            Id = c.Id,
            Name = c.Name,
            Total = c.Total,
            Description = c.Description,
            CreationDate = c.CreationDate.ToFarsi()
        }).ToList();
    }
}
