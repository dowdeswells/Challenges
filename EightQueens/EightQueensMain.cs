using System;
using System.Collections.Generic;
using System.IO;

namespace EightQueens
{
    public class EightQueensMain
    {
        public string Solve(string input)
        {
            try
            {
                return ProcessInput(input);
            }
            catch (CsvQueenSourceException e)
            {
                return "Involid input string";
            }
        }

        private static string ProcessInput(string input)
        {
            var textQueenSource = BuildQueenSource(input);
            var queenFinder = new AttackingQueenFinder(textQueenSource);
            var result = queenFinder.FindAttacker();

            if (result.Found)
            {
                return $"({result.Queen.Row},{result.Queen.Column})";
            }

            return "true";
        }

        private static CsvQueenSource BuildQueenSource(string input)
        {
            TextReader tr = new StringReader(input);
            var fieldReader = new CsvStringReaderFieldSplitter(tr);
            var coordinateReader = new CoordinatesStringReader();
            var textQueenSource = new CsvQueenSource(fieldReader, coordinateReader);
            return textQueenSource;
        }
    }
}