using System.Collections.Generic;
using System.Text;

namespace ChequeWriter
{
    public class ThreeDigitNumberWordBuilder
    {
        private readonly Dictionary<int, string> _numbersOneToNineteen = new Dictionary<int, string>
        {
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"},
            {10, "ten"},
            {11, "eleven"},
            {12, "twelve"},
            {13, "thirteen"},
            {14, "fourteen"},
            {15, "fifteen"},
            {16, "sixteen"},
            {17, "seventeen"},
            {18, "eighteen"},
            {19, "nineteen"},
        };

        private readonly Dictionary<int, string> _sometys = new Dictionary<int, string>
        {
            {2, "twenty"},
            {3, "thirty"},
            {4, "fourty"},
            {5, "fifty"},
            {6, "sixty"},
            {7, "seventy"},
            {8, "eighty"},
            {9, "ninety"},
        };

        private string _hundredsValue, _sometyValue;
        
        public void FillHundreds(int hundreds)
        {
            if (hundreds > 0)
            {
                _hundredsValue = _numbersOneToNineteen[hundreds] + " hundred";
            }
        }

        public void FillSingleWord(int units)
        {
            if (units > 0)
            {
                _sometyValue = $"{_numbersOneToNineteen[units]}";
            }
        }
        
        public void FillDoubleWord(int somety, int units)
        {
            if (somety > 0 && units > 0)
            {
                _sometyValue = $"{_sometys[somety]} {_numbersOneToNineteen[units]}";
            }
        }

        public string BuildSentance()
        {
            var words = new Conjunctor(" and ");
            words.Append(_hundredsValue);
            words.Append(_sometyValue);
            return words.ToString();
        }


    }
}