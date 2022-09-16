
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data;

public class Template
{
    public int TemplateId;
    public string Name;
}
public class Field
{
    public int FieldId;
    public string Name;
    public Template Template;
    public int TemplateId;
    public FieldType FieldType;
    public int FieldTypeId;
}

public class FieldType
{
    public int FieldTypeId;
    public string Name;
}
public class Operation
{
    public int OperationId;
    public string Name;
}
public class FieldTypeOperation
{
    public int FieldTypeOperationId;
    public FieldType FieldType;
    public int FieldTypeId;
    public Operation Operation;
    public int OperationId;
}
