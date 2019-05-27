using CodingStandards.Visitors;
using System;

namespace CodingStandards.SyntaxElements
{
    public class ClassDeclarationSyntax : SyntaxNodeBase
    {
        public string Name { get; set; }

        public ClassDeclarationSyntax(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            }

            Name = name;
        }

        public override void Accept(SyntaxVisitorBase visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            visitor.VisitClassDeclaration(this);
        }
    }
}