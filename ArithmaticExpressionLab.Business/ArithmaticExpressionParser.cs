using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace ArithmaticExpressionLab.Business
{
    public static class ArithmaticExpressionParser
    {
        private static readonly Regex Regex = new Regex(@"(?<leftExpression>.+)(?<operator>[\+\-]{1})(?<rightOperand>.+)", RegexOptions.Compiled);

        public static BinaryExpression Parse(string expressionText)
        {
            if (!Regex.IsMatch(expressionText))
            {
                throw new ArithmaticExpressionException("The expression is invalid");
            }

            var matches = Regex.Matches(expressionText);
            var match = matches[0];
            var leftExpressionText = match.Groups["leftExpression"].Value;
            var operatorText = match.Groups["operator"].Value;
            var rightOperandText = match.Groups["rightOperand"].Value;
            var expressionType = operatorText == "+" ? ExpressionType.Add : ExpressionType.Subtract;

            if (!int.TryParse(rightOperandText, out var rightOperand))
            {
                var exception = new ArithmaticExpressionException("One of the right operands is invalid.");
                exception.Data["Operand"] = rightOperandText;
                throw exception;
            }

            if (!Regex.IsMatch(leftExpressionText))
            {
                if (!int.TryParse(leftExpressionText, out var leftOperand))
                {
                    var exception = new ArithmaticExpressionException("One of the left operands is invalid.");
                    exception.Data["Operand"] = leftExpressionText;
                    throw exception;
                }

                return
                    Expression.MakeBinary(
                        expressionType,
                        Expression.Constant(leftOperand),
                        Expression.Constant(rightOperand));
            }

            var leftExpression = Parse(leftExpressionText);
            return
                Expression.MakeBinary(
                    expressionType,
                    leftExpression,
                    Expression.Constant(rightOperand));

        }
    }
}
