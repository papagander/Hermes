﻿global using Domain.Models.DataCore;
global using Domain;
using DataAccess.EFCore.Interfaces.Repositories.DataCore;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository.DataCore
{
    public class ConjoinerRepository 
        : UniquelyNamedRepository<Conjoiner>
        , IConjoinerRepository
    {
        public ConjoinerRepository(ReportContext _context) : base(_context)
        {
        }

        public void Add(string name) => AddNameOnly(name);
    }
}
