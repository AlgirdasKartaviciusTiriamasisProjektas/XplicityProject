using CodingStandards.SyntaxElements;

namespace CodingStandards.Visitors
{
    public class InterfaceShouldStartFromI : SyntaxVisitorBase
    {
        public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
        {
            base.VisitInterfaceDeclaration(node);
        }

        public override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            base.VisitClassDeclaration(node);
        }

        public override void VisitCompilationUnit(CompilationUnitSyntax node)
        {
            base.VisitCompilationUnit(node);
        }
    }
}
