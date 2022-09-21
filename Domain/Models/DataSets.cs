using System;
namespace Domain.Models
{

    public class DataSet
    {
        public int DataSetId;
        public string Name;
    }
    public class Field
    {
        public int FieldId;
        public string Name;
        public int DataSetId;
        public int FieldTypeId;
    }
}

