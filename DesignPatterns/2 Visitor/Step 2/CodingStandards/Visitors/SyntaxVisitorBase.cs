using CodingStandards.SyntaxElements;

namespace CodingStandards.Visitors
{
    public abstract class SyntaxVisitorBase
    {
        public virtual void VisitCompilationUnit(CompilationUnitSyntax node)
        {
            //nothing
        }

        public virtual void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            //nothing
        }

        public virtual void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            //nothing
        }
    }
}