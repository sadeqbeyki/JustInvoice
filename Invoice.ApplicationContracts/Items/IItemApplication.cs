﻿using AppFramework;

namespace Invoice.ApplicationContracts.Items;

public interface IItemApplication
{
    OperationResult Create(CreateItem command);
    OperationResult Edit(EditItem command);
    EditItem? GetDetails(long id);
    List<ItemDto> GetItems();
    void Delete(int key);

}