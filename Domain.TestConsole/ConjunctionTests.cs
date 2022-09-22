using Domain.Models.DataCore;

using System;
namespace Domain.TestConsole
{
    public class ConjunctionTests
    {
        DbContextOptions DbContextOptions;

        public ConjunctionTests(DbContextOptions dbContextOptions)
        {
            DbContextOptions = dbContextOptions;
        }


        public void ConjunctionToStringTest()
        {
            Conjoiner and = new Conjoiner();
            Conjoiner or = new Conjoiner();
            Field Count = new Field();
            Field ModelNum = new Field();
            Field Rma = new Field();
            Field DateReceived = new Field();
            Field Category = new Field();
            ModelNum.Name = "Serial Number";
            and.ConjoinerName = "AND";


        }
        public Criterion CreateCriterion(Field field, Operator @operator,
            List<CriterionValue> criterionValues, Conjunction? conjunction = null)
        {
            Criterion criterion = new Criterion();
            criterion.Statement = new Statement();
            criterion.Field = field;
            criterion.Operator = @operator;
            criterion.CriterionValues = criterionValues;
            criterion.Statement.Conjunction = conjunction;
            return criterion;

        }
        public void CreateDefaultFieldTypesAndOperators()
        {
            // Types
            var stringType = new FieldType  { Name = "string"};
            var intType = new FieldType { Name = "int" };
            var dateTimeType = new FieldType { Name = "DateTime" };

            // Hello Operator
            var equals = new Operator { Name = "equals", Symbol = "=" };
            var greaterThan = new Operator { Name = "greater than", Symbol = ">"};
            var lessThan = new Operator { Name = "less than", Symbol = "<"};
            var contains = new Operator { Name = "contains", Symbol = null};
        }
    }
}

