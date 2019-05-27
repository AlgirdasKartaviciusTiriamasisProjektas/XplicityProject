using CodingStandards.SyntaxElements;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodingStandards.Parsing
{
    public static class DummyParser
    {
        public static CompilationUnitSyntax Parse(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var compilationUnitSyntax = new CompilationUnitSyntax();

            //parse all interface names
            GetGroupsByPattern("interface\\s+([A-aZ-z0-9_]+)", content)
                .ForEach(name => compilationUnitSyntax.AddMember(new InterfaceDeclarationSyntax(name)));

            //parse all class names
            GetGroupsByPattern("class\\s+([A-aZ-z0-9_]+)", content)
                .ForEach(name => compilationUnitSyntax.AddMember(new ClassDeclarationSyntax(name)));

            return compilationUnitSyntax;
        }

        private static List<string> GetGroupsByPattern(string pattern, string content)
        {
            if (string.IsNullOrWhiteSpace(pattern))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(pattern));
            }

            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            var groups = new List<string>();

            var interfaceRecognitionRegex = new Regex(pattern);

            var match = interfaceRecognitionRegex.Match(content);

            while (match.Success)
            {
                groups.Add(match.Groups[1].Value);

                match = match.NextMatch();
            }

            return groups;
        }
    }
}