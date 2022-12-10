
using Domain.Interfaces.Models;
using Domain.Models.FieldSets;
using Domain.Models.Generic;

namespace Domain.Models.Queries;

public class Query : Named, IReferences<FieldSets.FieldSet>, IReferencedBy<Field>
{
    public FieldSet FieldSet { get; set; }
    public List<Field> Fields { get; set; }
    public Statement? Statement { get; set; }

    public string ExecutionString
    {
        get
        {

            string output = "";
            // Add fields (SELECT SerialNumber, ModelNumber, DateReceived)
            output += $"SELECT [{Fields[0].Name}]";
            for (int i = 1; i < Fields.Count; i++)
                output += $", [{Fields[i].Name}]";

            // Add FieldSet( FROM Receiving)
            output += $" FROM [{FieldSet.Name}]";
            // Add top statement:
            // WHERE ( ( Customer = 'Galanz' AND Category = 'Microwaves' ) OR ( Customer = 'Capital Brands' AND Category = 'Vaccuums') ) AND WeeksAgo(1)
            if (Statement is not null) output += $" WHERE {Statement.ExecutionString}";
            output += ";";
            return output;
        }
    }
    public override string ToString() => $"{FieldSet.Name}.{Name}";

    public int FieldSetId { get; set; }
    public int? StatementId { get; set; }
    int IReferences<FieldSet>.MyTRefId { get => FieldSetId; }
    FieldSet IReferences<FieldSet>.MyTRef { get => FieldSet; }
    List<Field> IReferencedBy<Field>.MyTs { get => Fields; set => Fields = value; }
}




