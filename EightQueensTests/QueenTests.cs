using EightQueens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;


namespace EightQueensTests
{
    [TestClass]
    public class QueenTests
    {
        [TestMethod]
        [DataRow(1,2,4,2)]
        [DataRow(1,2,1,4)]
        public void Queen_QueenOnSameRowOrColumn_IsAttacking(int q1Row, int q1Column, int q2Row, int q2Column)
        {
            var q1 = new Queen(q1Row, q1Column);
            var q2 = new Queen(q2Row, q2Column);
            
            Assert.IsTrue(q1.IsAttacking(q2));
        }
        
        [TestMethod]
        [DataRow(1,2,4,3)]
        public void Queen_QueenNotOnSameRowOrColumn_IsNotAttacking(int q1Row, int q1Column, int q2Row, int q2Column)
        {
            var q1 = new Queen(q1Row, q1Column);
            var q2 = new Queen(q2Row, q2Column);
            
            Assert.IsFalse(q1.IsAttacking(q2));
        } 
        
                
        [TestMethod]
        [DataRow(1,1,2,2)]
        [DataRow(1,4,4,7)]
        [DataRow(4,7, 1,4)]
        [DataRow(2,5, 8,5)]
        public void Queen_QueenInSameDiagonal_IsAttacking(int q1Row, int q1Column, int q2Row, int q2Column)
        {
            var q1 = new Queen(q1Row, q1Column);
            var q2 = new Queen(q2Row, q2Column);
            
            Assert.IsTrue(q1.IsAttacking(q2));
        }  
    }
}