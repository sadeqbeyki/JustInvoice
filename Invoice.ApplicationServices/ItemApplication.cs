using AppFramework;
using Invoice.ApplicationContracts.Items;
using Invoice.Domain.ItemAgg;

namespace Invoice.ApplicationServices;

public class ItemApplication : IItemApplication
{
    private readonly IItemRepository _itemRepository;

    public ItemApplication(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public OperationResult Create(CreateItem command)
    {
        OperationResult operation = new();
        Item item = new()
        {
            //Name = command.Name,
            ProductId = command.ProductId,
            UnitId = command.UnitId,
            Price = command.Price,
            Count = command.Count,
            Sum = command.Count * command.Price,
            //Description = command.Description,
        };
        _itemRepository.Create(item);
        return operation.Succeeded();
    }

    public void Delete(int key)
    {
        _itemRepository.Delete(key);
    }

    public OperationResult Edit(EditItem command)
    {
        OperationResult operation = new();
        var item = _itemRepository.Get(command.Id);
        if (item != null)
        {
            item.Id = command.Id;
            //item.Name = command.Name;
            item.ProductId = command.ProductId;
            item.UnitId = command.UnitId;
            item.Price = command.Price;
            item.Count = command.Count;
            item.Sum = command.Count*command.Price;
            //item.Description = command.Description;
        }
        _itemRepository.Update(item);
        return operation.Succeeded();
    }

    public EditItem? GetDetails(long id)
    {
        return _itemRepository.GetDetails(id);
    }


    public List<ItemViewModel> GetItems()
    {
        return _itemRepository.GetItems();
    }
}
