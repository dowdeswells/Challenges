using System.Text;

namespace ChequeWriter
{
    public class Conjunctor
    {
        private readonly string _separator;
        private readonly StringBuilder _sb = new StringBuilder();

        public Conjunctor(string separator)
        {
            _separator = separator;
        }
        public void Append(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (_sb.Length > 0)
                {
                    _sb.Append($"{_separator}");
                }
                
                _sb.Append(value);
            }
        }

        public override string ToString()
        {
            return _sb.ToString();
        }
    }
}