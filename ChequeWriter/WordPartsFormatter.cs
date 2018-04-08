using System;
using System.Collections.Generic;

namespace ChequeWriter
{
    public class WordPartsFormatter
    {
        private readonly Dictionary<int, string> _wordPartNames = new Dictionary<int, string>
        {
            {0, ""},
            {1, "thousand"},
            {2, "million"},
            {3, "billion"},
            {4, "trillion"},
        };
        
        public string Format(List<string> wordParts)
        {
            var sentanceParts = RemoveBlankPartsAndPutInSentanceOrder(wordParts);

            var length = sentanceParts.Count;
            if (length == 0)
            {
                return string.Empty;
            }

            if (length == 1)
            {
                return sentanceParts[0];
            }
            
            var sentance = AssembleWithCommas(sentanceParts);

            return sentance;
        }

        private List<string> RemoveBlankPartsAndPutInSentanceOrder(List<string> wordParts)
        {
            var sentancePartsWithoutCommas = new List<string>();
            var length = wordParts.Count;
            int i = length - 1;
            while (i >= 0)
            {
                var partname = _wordPartNames[i];
                var namedWords = AssembleFromWordsAndName(wordParts[i], partname);
                if (namedWords.Length > 0)
                {
                    sentancePartsWithoutCommas.Add(namedWords);
                }

                i--;
            }

            return sentancePartsWithoutCommas;
        }

        private string AssembleWithCommas(List<string> sentanceParts)
        {
            var length = sentanceParts.Count;
            var conjunctor = new Conjunctor(", ");
            int i = 0;
            while(i <= length - 2)
            {
                conjunctor.Append(sentanceParts[i]);
                i++;
            } 

            var sofar = conjunctor.ToString();

            return $"{sofar} {sentanceParts[length - 1]}";
        }
       
        private string AssembleFromWordsAndName(string wordPart, string partname)
        {
            if (string.IsNullOrWhiteSpace(wordPart))
            {
                return string.Empty;
            }
            var conjunctor = new Conjunctor(" ");
            conjunctor.Append(wordPart);
            conjunctor.Append(partname);
            return conjunctor.ToString();
        }

    }
}