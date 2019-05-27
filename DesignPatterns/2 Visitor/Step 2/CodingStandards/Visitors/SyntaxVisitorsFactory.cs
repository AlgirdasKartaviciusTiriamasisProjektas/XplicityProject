using System.Collections.Generic;

namespace CodingStandards.Visitors
{
    public class SyntaxVisitorsFactory
    {
        public IEnumerable<SyntaxVisitorBase> Create()
        {
            return new SyntaxVisitorBase[]
            {
                new InterfaceShouldStartFromI(),
                new FileShouldContainOnlyOneRoot()
            };
        }
    }
}
