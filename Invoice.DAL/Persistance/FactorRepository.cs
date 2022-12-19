using AppFramework;
using Invoice.ApplicationContracts.Factor;
using Invoice.ApplicationContracts.Items;
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

	public FactorDto GetFactor(long id)
	{
		return _invoiceContext.Factors.Select(x => new FactorDto()
		{
			Id = x.Id,
			Name = x.Name,
			Total = x.Total,
			Description = x.Description,
			CreationDate = x.CreationDate.ToFarsi()

		}).FirstOrDefault(x => x.Id == id);
	}

	public List<FactorDto> GetFactors()
	{
		return _invoiceContext.Factors.Select(c => new FactorDto
		{
			Id = c.Id,
			Name = c.Name,
			Total = c.Total,
			Description = c.Description,
			CreationDate = c.CreationDate.ToFarsi()
		}).ToList();
	}

	public List<ItemDto> GetItems(long id)
	{
		return _invoiceContext.Items
			.Where(x => x.FactorId == id)
			.Select(x => new ItemDto
			{
				Id = x.Id,
				Price = x.Price,
				Count = x.Count,
				Sum = x.Sum,
				ProductId= x.ProductId,
				Product = x.Product.Name,
				UnitId= x.UnitId,
				Unit = x.Unit.Name
			}).ToList();
	}
}
