using System.Globalization;

namespace NgernTidLorTestProject
{
    public sealed class ExpressionEvaluator
    {
        private string _expression = string.Empty;
        private int _position;

        public double Evaluate(string? expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("Expression is empty.");

            // เตรียมอินพุต (ตัดช่องว่าง)
            _expression = Normalize(expression);
            _position = 0;

            double value = ParseExpression();
            if (_position != _expression.Length)
                throw new ArgumentException($"Unexpected token '{_expression[_position]}' at position {_position}.");
            return value;
        }

        private static string Normalize(string expression)
        {
            //ลบช่องว่าง
            IEnumerable<char> normalizeChars = expression
                .Where(c => !char.IsWhiteSpace(c));

            return string.Concat(normalizeChars);
        }

        // expr := term (('+'|'-') term)*
        private double ParseExpression()
        {
            double value = EvaluateMultiplyDivide();
            while (true)
            {
                if (Match('+')) value += EvaluateMultiplyDivide();
                else if (Match('-')) value -= EvaluateMultiplyDivide();
                else break;
            }
            return value;
        }

        // term := factor (('*'|'/') factor)*
        private double EvaluateMultiplyDivide()
        {
            double value = EvaluateSingleValue();
            while (true)
            {
                if (Match('*'))
                {
                    value *= EvaluateSingleValue();
                }
                else if (Match('/'))
                {
                    double divisor = EvaluateSingleValue();
                    if (divisor == 0) throw new DivideByZeroException();
                    value /= divisor;
                }
                else break;
            }
            return value;
        }

        // factor := number | '(' expr ')' | unary +/- factor
        private double EvaluateSingleValue()
        {
            if (_position >= _expression.Length)
                throw new ArgumentException("Unexpected end of expression.");

            // unary +/-
            if (Match('+')) return EvaluateSingleValue();
            if (Match('-')) return -EvaluateSingleValue();

            // parentheses
            if (Match('('))
            {
                double inner = ParseExpression();
                if (!Match(')')) throw new ArgumentException("Missing ')'.");
                return inner;
            }

            // number
            return ParseNumber();
        }

        private bool IsCurrentChar(char expected)
        {
            return HasMoreChars() && _expression[_position] == expected;
        }

        private bool HasMoreChars()
        {
            return _position < _expression.Length;
        }

        private double ParseNumber()
        {
            int start = _position;
            bool hasDigit = false;

            while (HasMoreChars() && char.IsDigit(_expression[_position]))
            { _position++; hasDigit = true; }

            if (IsCurrentChar('.'))
            {
                _position++;
                while (HasMoreChars() && char.IsDigit(_expression[_position]))
                { _position++; hasDigit = true; }
            }

            if (!hasDigit)
                throw new ArgumentException($"Expected number at position {start}.");

            var token = _expression[start.._position].ToString();
            if (!double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                throw new ArgumentException($"Invalid number '{token}'.");
            return value;
        }

        private bool Match(char c)
        {
            if (IsCurrentChar(c))
            {
                _position++;
                return true;
            }
            return false;
        }

    }
}