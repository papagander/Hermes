﻿using Domain.Models.DataCore;
using Domain.Models.FieldSets;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFieldSetService
    {
        int CreateFieldSet(string name, IEnumerable<Field> fields);
        int AddFields(FieldSet fieldSet, IEnumerable<Field> fields);
        int Remove(FieldSet fieldSet);
        int Remove(string name);
        IEnumerable<FieldSet> GetFieldSets();
    }
}
