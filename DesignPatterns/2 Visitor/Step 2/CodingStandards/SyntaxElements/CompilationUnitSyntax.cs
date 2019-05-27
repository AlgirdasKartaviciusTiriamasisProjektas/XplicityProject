using CodingStandards.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingStandards.SyntaxElements
{
    public class CompilationUnitSyntax : SyntaxNodeBase
    {
        private readonly List<SyntaxNodeBase> _members = new List<SyntaxNodeBase>();

        public IEnumerable<SyntaxNodeBase> Members => _members.AsReadOnly();

        public CompilationUnitSyntax AddMember(SyntaxNodeBase member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member));
            }

            _members.Add(member);

            return this;
        }

        public override void Accept(SyntaxVisitorBase visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException(nameof(visitor));
            }

            visitor.VisitCompilationUnit(this);

            Members.OfType<ClassDeclarationSyntax>()
                .ToList()
                .ForEach(visitor.VisitClassDeclaration);

            Members.OfType<InterfaceDeclarationSyntax>()
                .ToList()
                .ForEach(visitor.VisitInterfaceDeclaration);
        }
    }
}