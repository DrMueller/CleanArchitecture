﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Models;
using Mmu.CleanArchitecture.DomainModels.Areas.Base.Specifications;

namespace Mmu.CleanArchitecture.DataAccess.Areas.Querying.Services.Servants
{
    public interface ISpecificationEvaluator
    {
        IQueryable<TEntity> ApplySpecification<TEntity>(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
            where TEntity : EntityBase;
    }
}