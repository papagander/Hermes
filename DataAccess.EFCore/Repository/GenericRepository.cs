global using DataAccess.EFCore.Interfaces;
global using Domain.Models;
global using System.Linq;
global using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository;
public class GenericRepository<T> 
{
    protected readonly ReportContext _context;
    public GenericRepository(ReportContext context)
    {
        _context = context;
    }
}
