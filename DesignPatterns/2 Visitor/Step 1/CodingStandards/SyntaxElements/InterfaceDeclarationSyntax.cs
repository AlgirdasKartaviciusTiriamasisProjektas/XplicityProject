using System;
using CodingStandards.Visitors;

namespace CodingStandards.SyntaxElements
{
    public class InterfaceDeclarationSyntax : SyntaxNodeBase
    {
        public string Name { get; set; }

        public InterfaceDeclarationSyntax(string name)
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

            visitor.VisitInterfaceDeclaration(this);
        }

        //add your code here
    }
}