using CodingStandards.Visitors;

namespace CodingStandards.SyntaxElements
{
    public abstract class SyntaxNodeBase
    {
        public abstract void Accept(SyntaxVisitorBase visitor);
    }
}