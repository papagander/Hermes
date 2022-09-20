
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

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
public class Operator
{
    public int OperatorId;
    public string Name;
}
public class FieldTypeOperator
{
    public int FieldTypeOperatorId;
    public FieldType FieldType;
    public int FieldTypeId;
    public Operator Operator;
    public int OperatorId;
}
