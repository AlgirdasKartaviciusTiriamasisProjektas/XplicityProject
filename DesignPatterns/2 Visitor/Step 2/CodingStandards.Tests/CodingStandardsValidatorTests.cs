using System;
using Xunit;

namespace CodingStandards.Tests
{
    public class CodingStandardsValidatorTests
    {
        [Theory]
        [InlineData("public interface IMyInterface {}")]
        [InlineData("interface IMyInterface {}")]
        [InlineData("public class MyClass {}")]
        [InlineData("class MyClass {}")]
        public void ItValidates_ValidContent(string content)
        {
            // Prepare

            var codingStandardsValidator = new CodingStandardsValidator();

            //Act & Assert

            codingStandardsValidator.Check(content);
        }

        [Theory]
        [InlineData("public interface myInterface {}")]
        [InlineData("public interface MyInterface {}")]
        [InlineData("public interface iMyInterface {}")]
        [InlineData("class MyClass1 {} class MyClass2 {}")]
        [InlineData("interface IMyInterface {} class MyClass {}")]
        [InlineData("interface IMyInterface1 {} interface IMyInterface2 {}")]
        public void ItThrowsException_InvalidContent(string content)
        {
            // Prepare

            var codingStandardsValidator = new CodingStandardsValidator();

            //Act & Assert

            Assert.ThrowsAny<Exception>(() =>
                codingStandardsValidator.Check(content));
        }
    }
}
