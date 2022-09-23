using Domain.Interfaces.Models;
using Domain.Models.DataCore;

using System;

namespace Domain.Models
{

    public class DataSet : INamed, IReferencedBy<Field>
    {
        public int DataSetId;
        public string DataSetName;
        public List<Field> Fields;
        string INamed.Name { get { return DataSetName; } set { DataSetName = value; } }
        int IIndexed.Id { get { return DataSetId; } set { DataSetId = value; } }

        public DataSet(string name)
        {
            DataSetName = name;
        }

        List<Field> IReferencedBy<Field>.MyTs
        {
            get { return Fields; }
        }
    }
    public class Field : INamed, IReferences<DataSet>, IReferences<FieldType>
    {
        public int FieldId;
        public string FieldName;
        public int DataSetId;
        public int FieldTypeId;
        public FieldType FieldType;
        public DataSet DataSet;
        private List<QueryField> queryFields;
        public List<Query> Queries;

        public Field(FieldType fieldType, DataSet dataSet, string name)
        {
            FieldType = fieldType;
            DataSet = dataSet;
            FieldName = name;
        }

        string INamed.Name { get { return FieldName; } set { FieldName = value; } }
        int IIndexed.Id { get { return FieldId; } set { FieldId = value; } }
        int IReferences<DataSet>.TDex { get { return DataSetId; } set { DataSetId = value; } }
        int IReferences<FieldType>.TDex { get { return FieldTypeId; } set { FieldTypeId = value; } }
        DataSet IReferences<DataSet>.MyT { get { return DataSet; } set { DataSet = value; } }
        FieldType IReferences<FieldType>.MyT { get { return FieldType; } set { FieldType = value; } }
    }
}

