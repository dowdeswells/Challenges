using EightQueens;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EightQueensTests
{
    [TestClass]
    public class EightQueensMainTests
    {
        [TestMethod]
        [DataRow("\"(2,1)\", \"(4,2)\", \"(6,3)\", \"(8,4)\", \"(3,5)\", \"(1,6)\", \"(7,7)\", \"(5,8)\"")]
        public void EightQueens_NonAttackingQueens_ReturnsTrueString(string input)
        {
            var main = new EightQueensMain();
            var actualOutput = main.Solve(input);
            
            Assert.AreEqual("true", actualOutput);
        }
        
        [TestMethod]
        [DataRow("\"(2,1)\", \"(4,3)\", \"(6,3)\", \"(8,4)\", \"(3,4)\", \"(1,6)\", \"(7,7)\", \"(5,8)\"", "(2,1)")]
        [DataRow("\"(2,1)\", \"(5,3)\", \"(6,3)\", \"(8,4)\", \"(3,4)\", \"(1,8)\", \"(7,7)\", \"(5,8)\"", "(5,3)")]
        public void EightQueens_AttackingQueens_ReturnsAttackingQueenCoordinates(string input, string expectedOutput)
        {
            var main = new EightQueensMain();
            var actualOutput = main.Solve(input);
            
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        
    }
}