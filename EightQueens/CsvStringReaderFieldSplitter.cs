using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EightQueens
{
    public class CsvStringReaderFieldSplitter
    {
        private readonly TextReader _input;
        private bool _isEndOfInput;
        private char _currentChar;
        
        public CsvStringReaderFieldSplitter(TextReader inputLine)
        {
            _input = inputLine;
        }

        public IEnumerable<FieldToken> Tokenize()
        {
            while (AdvanceToStartToken())
            {
                var fieldToken = ProcessToEndOfToken();
                yield return fieldToken;
                if (!fieldToken.IsValid)
                {
                    break;
                }
            }
        }

        private FieldToken ProcessToEndOfToken()
        {
            StringBuilder collected = new StringBuilder();
            while (ReadNext())
            {
                if (CurrentChar() == '"')
                {
                    return FieldToken.ValidToken(collected.ToString());
                }
                else
                {
                    collected.Append(CurrentChar());
                }
            }

            return FieldToken.Invalid();
        }



        private bool AdvanceToStartToken()
        {
            while (ReadNext())
            {
                if (CurrentChar() == '"')
                {
                    return true;
                }
            }

            return false;
        }

        
        private bool EndOfInput()
        {
            return _isEndOfInput;
        }
        
        private char CurrentChar()
        {
            return _currentChar;
        }


        
        private bool ReadNext()
        {
            var lastReadValue = _input.Read();
            if (lastReadValue > 0)
            {
                _currentChar = (char) lastReadValue;
                return true;
            }

            _isEndOfInput = true;
            return false;
        }
    }
}