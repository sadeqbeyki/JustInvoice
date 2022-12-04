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

    public EditFactor GetDetails(long id)
    {
        return _invoiceContext.Factors.Select(x => new EditFactor()
            {
                Id = x.Id,
                Name = x.Name,
                Total = x.Total,
                Description = x.Description
            }).FirstOrDefault(x => x.Id == id);
    }

    public List<FactorViewModel> GetFactors()
    {
        return _invoiceContext.Factors.Select(c => new FactorViewModel
        {
            Id = c.Id,
            Name = c.Name,
            Total = c.Total,
            Description = c.Description,
            CreationDate = c.CreationDate.ToFarsi()
        }).ToList();
    }
}
