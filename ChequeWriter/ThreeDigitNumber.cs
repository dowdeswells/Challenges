namespace ChequeWriter
{
    public class ThreeDigitNumber
    {
        struct DoubleNumber
        {
            public int Sometys;
            public int Units;
        }

        private DoubleNumber? _doubleNumber;
        private int _hundreds, _units;

        public static ThreeDigitNumber FromInt(int number)
        {
            var hundreds = number / 100;
            var remainder = number - hundreds * 100;
            if (remainder >= 1 && remainder <= 19)
            {
                return new ThreeDigitNumber
                {
                    _hundreds = hundreds,
                    _units = remainder,
                    _doubleNumber = null,
                };
            }

            var sometys = remainder / 10;
            var units = remainder - sometys * 10;
            return new ThreeDigitNumber
            {
                _hundreds = hundreds,
                _doubleNumber = new DoubleNumber
                {
                    Sometys = sometys,
                    Units = units
                }
            };
        }

        public string ToWords()
        {
            var builder = new ThreeDigitNumberWordBuilder();
            builder.FillHundreds(_hundreds);
            if (_doubleNumber.HasValue)
            {
                builder.FillDoubleWord(_doubleNumber.Value.Sometys, _doubleNumber.Value.Units);
            }
            else
            {
                builder.FillSingleWord(_units);
            }

            return builder.BuildSentance();
        }
    }
}