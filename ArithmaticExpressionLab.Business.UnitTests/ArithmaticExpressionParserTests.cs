using System;
using System.Linq.Expressions;
using FluentAssertions;
using Xunit;

namespace ArithmaticExpressionLab.Business.UnitTests
{
    public class ArithmaticExpressionParserTests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("1 +")]
        [InlineData("+ 1")]
        public void GivenInvalidExpression_ThrowException(string expressionText)
        {
            Action action = () => ArithmaticExpressionParser.Parse(expressionText);
            action.Should().Throw<ArithmaticExpressionException>().WithMessage("The expression is invalid");
        }

        [Theory]
        [InlineData("1 + a")]
        [InlineData("1 + 1 + a")]
        public void GivenInvalidRightOperand_ThrowException(string expressionText)
        {
            Action action = () => ArithmaticExpressionParser.Parse(expressionText);
            action.Should().Throw<ArithmaticExpressionException>().WithMessage("One of the right operands is invalid.");
        }

        [Theory]
        [InlineData("a + 1")]
        [InlineData("a + 1 + 1")]
        public void GivenInvalidLeftOperand_ThrowException(string expressionText)
        {
            Action action = () => ArithmaticExpressionParser.Parse(expressionText);
            action.Should().Throw<ArithmaticExpressionException>().WithMessage("One of the left operands is invalid.");
        }

        [Theory]
        [InlineData("1+1")]
        [InlineData("1 + 1")]
        [InlineData("1     + 1")]
        [InlineData(" 1 + 1 ")]
        [InlineData(" 1 + 1     ")]
        public void Given1Plus1_Return1Plus1(string expressionText)
        {
            var expression = ArithmaticExpressionParser.Parse(expressionText);
            expression.ToString().Should().Be(Expression.MakeBinary(
                ExpressionType.Add,
                Expression.Constant(1),
                Expression.Constant(1)).ToString());
        }

        [Fact]
        public void Given1Minus1_Return1Minus1()
        {
            var expression = ArithmaticExpressionParser.Parse("1-1");
            expression.ToString().Should().Be(Expression.MakeBinary(
                ExpressionType.Subtract,
                Expression.Constant(1),
                Expression.Constant(1)).ToString());
        }

        [Fact]
        public void Given1Plus1Minus1_Return1Plus1Minus1()
        {
            var expression = ArithmaticExpressionParser.Parse("1+1-1");
            expression.ToString().Should().Be(Expression.MakeBinary(
                ExpressionType.Subtract,
                Expression.MakeBinary(
                    ExpressionType.Add,
                    Expression.Constant(1),
                    Expression.Constant(1)),
                Expression.Constant(1)).ToString());
        }
    }
}
