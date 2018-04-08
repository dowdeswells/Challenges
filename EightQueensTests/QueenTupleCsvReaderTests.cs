using System.IO;
using System.Linq;
using EightQueens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EightQueensTests
{
    [TestClass]
    public class QueenTupleCsvReaderTests
    {
        
        [TestMethod]
        [DataRow("\"aaa\"", "aaa")]
        [DataRow("\"a,a\"", "a,a")]
        [DataRow("\"(1,2)\"", "(1,2)")]
        public void Reader_CsvField_ReadsCorrectly(string input, string expected)
        {
            var csvStringReaderFieldSplitter = new CsvStringReaderFieldSplitter(new StringReader(input));
            var fields = csvStringReaderFieldSplitter.Tokenize().ToList();
            Assert.AreEqual(1, fields.Count());
            Assert.AreEqual(expected, fields.First().Field);
        }

        [TestMethod]
        [DataRow("\"aaa\",\"bbb\",\"ccc\"", "aaa", "bbb", "ccc")]
        [DataRow("\"aaa\", \"bbb\", \"ccc\"", "aaa", "bbb", "ccc")]
        [DataRow("     \"aaa\"   ,    \"bbb\"   ,    \"ccc\"", "aaa", "bbb", "ccc")]
        public void Reader_MultipleFields_ReadsCorrectly(string input, string expected1, string expected2,
            string expected3)
        {
            string[] expected = new[] {expected1, expected2, expected3};
            var csvStringReaderFieldSplitter = new CsvStringReaderFieldSplitter(new StringReader(input));

            var fields = csvStringReaderFieldSplitter.Tokenize().ToList();
            Assert.AreEqual(expected.Length, fields.Count());
            for (var i = 0; i < expected.Length; i++)
            {
                var expectedField = expected[i];
                var actualField = fields.Skip(i).First().Field;
                Assert.AreEqual(expectedField, actualField);
            }
        }
    }
}