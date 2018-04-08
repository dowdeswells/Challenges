using System.Linq;
using EightQueens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EightQueensTests
{
    [TestClass]
    public class CoordinatesStringReaderTests
    {
        [TestMethod]
        [DataRow("(2,1)", 2, 1)]
        [DataRow("(99,100)", 99, 100)]
        public void Reader_ValidFieldString_ReturnsExpectedCoordinates(string field, int row, int column)
        {
            var reader = new CoordinatesStringReader();
            var coordinate = reader.TransformField(field);
            Assert.AreEqual(row, coordinate.Row);
            Assert.AreEqual(column, coordinate.Column);
        }

    }
}