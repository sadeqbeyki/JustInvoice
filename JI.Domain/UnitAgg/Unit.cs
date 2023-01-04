﻿using JI.Domain.Common;
using JI.Domain.InvoiceAgg;

namespace JI.Domain.UnitAgg;

public class Unit : EntityBase
{
    public string Name { get; set; }
    public List<Item> Items { get; set; }

}
