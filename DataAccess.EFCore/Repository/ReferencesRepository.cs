﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EFCore.Repository
{
    internal class ReferencesRepository<T, TRef> : IndexedRepository<T>, IReferencesRepository<T, TRef>
        where T : class, IReferences<TRef> where TRef : class, IIndexed
    {
        public ReferencesRepository(ReportContext _context) : base(_context) { }
        public IEnumerable<T> GetRange(TRef MyTRef)
         => (from MyT in context.Set<T>() where MyT.MyTRefId == MyTRef.Id select MyT);

        /*public IEnumerable<T> GetRange(int MyTRefId)
         => (from MyT in context.Set<T>() where MyT.MyTRefId == MyTRefId select MyT);*/

    }
}
