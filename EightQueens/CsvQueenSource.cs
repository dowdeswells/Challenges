using System;
using System.Collections.Generic;

namespace EightQueens
{
    public class CsvQueenSource : IQueenSource
    {
        private readonly CsvStringReaderFieldSplitter _fieldReader;
        private readonly CoordinatesStringReader _coordinatesStringReader;

        public CsvQueenSource(CsvStringReaderFieldSplitter fieldReader, 
            CoordinatesStringReader coordinatesStringReader)
        {
            _fieldReader = fieldReader;
            _coordinatesStringReader = coordinatesStringReader;
        }


        public IEnumerable<Queen> Queens()
        {
            foreach (var fieldToken in _fieldReader.Tokenize())
            {
                if (fieldToken.IsValid)
                {
                    var coordinate = _coordinatesStringReader.TransformField(fieldToken.Field);
                    var queen = new Queen(coordinate.Row, coordinate.Column);
                    yield return queen;
                }
                else
                {
                    throw new CsvQueenSourceException();
                }
            }
        }
    }

    public class CsvQueenSourceException : Exception
    {
    }
}