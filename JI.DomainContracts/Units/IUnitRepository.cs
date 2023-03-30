﻿using AppFramework;
using JI.DomainContracts.Common;
using JI.DomainContracts.Units;

namespace JI.Domain.UnitAgg;

public interface IUnitRepository : IBaseRepository<long, Unit>
{
    List<UnitDto> GetUnits();
    OperationResult Create(Unit unit);
    OperationResult Update(Unit unit);

}
