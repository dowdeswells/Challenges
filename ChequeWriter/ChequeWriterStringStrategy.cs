using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ChequeWriter
{
    public class ChequeWriterStringStrategy
    {
        private class WordResult
        {
            public string Words { get; set; }
            public bool AmountIsZero { get; set; }
            public bool AmountIsGreaterThanOne { get; set; }
        }
        
        public string ToWords(string input)
        {
            var decimalPointPos = input.IndexOf(".", StringComparison.InvariantCultureIgnoreCase);
            var integerPart = decimalPointPos < 0 ? input : input.Substring(0, decimalPointPos);
            var fractionalPart = decimalPointPos < 0 || decimalPointPos == input.Length - 1 ? string.Empty : input.Substring(decimalPointPos + 1);
            var dollarWords = ToWords(integerPart, "dollars", "one dollar");
            var centWords = ToWords(fractionalPart, "cents", "one cent");
            
            var conjuctor = new Conjunctor(" and ");
            conjuctor.Append(dollarWords);
            conjuctor.Append(centWords);
            return conjuctor.ToString();
        }

        private string ToWords(string numericInput, string denominationPlural, string singular)
        {
            if (string.IsNullOrWhiteSpace(numericInput))
            {
                return string.Empty;
            }

            var wordResult = BuildWordResult(numericInput, denominationPlural);

            if (wordResult.AmountIsZero)
            {
                return string.Empty;
            }

            if (!wordResult.AmountIsGreaterThanOne)
            {
                return singular;
            }

            return wordResult.Words;
        }
        
        

        private WordResult BuildWordResult(string whole, string denominationText)
        {
            bool amountIsZero = true;
            bool amountIsGreaterThanOne = false;
            var triples = ToTriplesLeastSignificantFirst(whole);
            var triplesAsWords = new List<string>();
            for (var i = 0; i < triples.Count; i++)
            {
                var triple = triples[i];
                var number = int.Parse(triple);
                if (number > 0)
                {
                    amountIsZero = false;
                }

                if (number > 1 || (number == 1 && i > 0))
                {
                    amountIsGreaterThanOne = true;
                }

                var threeDigitNumber = ThreeDigitNumber.FromInt(number);
                triplesAsWords.Add(threeDigitNumber.ToWords());
            }

            var result = new WordResult
            {
                AmountIsZero = amountIsZero,
                AmountIsGreaterThanOne = amountIsGreaterThanOne,
            };

            if (!amountIsZero && amountIsGreaterThanOne)
            {
                var formatter = new WordPartsFormatter();
                result.Words = formatter.Format(triplesAsWords) + " " + denominationText;
            }
            return result;
        }

        private List<string> ToTriplesLeastSignificantFirst(string whole)
        {
            List<string> triples = new List<string>();
            int pos = whole.Length - 1;
            while (pos > 2)
            {
                var triple = whole.Substring(pos - 2, 3);
                triples.Add(triple);
                pos = pos - 3;
            }
            triples.Add(whole.Substring(0, pos+1));
            return triples;
        }
    }
}