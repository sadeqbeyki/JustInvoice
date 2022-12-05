using Invoice.ApplicationContracts.Items;

namespace Invoice.Domain.ItemAgg;
public interface IItemRepository : IBaseRepository<long, Item>
{
    List<ItemDto> GetItems();
    EditItem GetDetails(long id);

}
