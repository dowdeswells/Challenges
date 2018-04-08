using ChequeWriter;
using NUnit.Framework;

namespace ChequeWriterTests
{
    [TestFixture]
    public class ThreeDigitNumberTests
    {
        [Test]
        [TestCase(3, "three")]
        [TestCase(666, "six hundred and sixty six")]
        [TestCase(999, "nine hundred and ninety nine")]
        [TestCase(103, "one hundred and three")]
        [TestCase(23, "twenty three")]
        [TestCase(12, "twelve")]
        [TestCase(100, "one hundred")]
        public void Number_ToWords_MatchesExpected(int number, string expectedWords)
        {
            var sut = ThreeDigitNumber.FromInt(number);
            var words = sut.ToWords();
            Assert.AreEqual(expectedWords, words);
        }
    }
}