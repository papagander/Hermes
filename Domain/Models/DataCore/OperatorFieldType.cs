using Domain.Interfaces.Models;
using Domain.Models.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.DataCore
{
    public class OperatorFieldType 
        : Indexed
        , IReferences<Operator>
    {
        public Operator Operator { get; set; }
        public int OperatorId { get; set; }
        public SqlDbType DbType { get; set; }
        [NotMapped]
        Operator IReferences<Operator>.MyTRef { get => Operator; }
        [NotMapped]
        int IReferences<Operator>.MyTRefId { get => OperatorId; }
    }
}