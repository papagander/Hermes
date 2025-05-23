﻿using Domain.Models.DataCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Interfaces.Repositories.DataCore;
public interface IConjoinerRepository 
    : IUniquelyNamedRepository<Conjoiner>
{
    void Add(string name);
}
