using System.Linq;
using CodingStandards.Parsing;
using CodingStandards.Visitors;

namespace CodingStandards
{
    public class CodingStandardsValidator
    {
        public void Check(string content)
        {
            var compilationUnitSyntax = DummyParser.Parse(content);

            new SyntaxVisitorsFactory()
                .Create()
                .ToList()
                .ForEach(compilationUnitSyntax.Accept);
        }
    }
}
