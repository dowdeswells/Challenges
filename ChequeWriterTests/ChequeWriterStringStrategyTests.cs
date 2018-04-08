using ChequeWriter;
using NUnit.Framework;

namespace ChequeWriterTests
{
    [TestFixture]
    public class ChequeWriterStringStrategyTests
    {
        [Test]
        [TestCase("635462", "six hundred and thirty five thousand four hundred and sixty two dollars")]
        [TestCase("99635462", "ninety nine million, six hundred and thirty five thousand four hundred and sixty two dollars")]
        [TestCase("635000000", "six hundred and thirty five million dollars")]
        [TestCase("635000000000", "six hundred and thirty five billion dollars")]
        [TestCase("635482000000", "six hundred and thirty five billion four hundred and eighty two million dollars")]
        [TestCase("100000000000", "one hundred billion dollars")]
        [TestCase("987654321234", "nine hundred and eighty seven billion, six hundred and fifty four million, three hundred and twenty one thousand two hundred and thirty four dollars")]
        [TestCase("1000000000", "one billion dollars")]
        public void Writer_WholeNumbers_ProducesExpected(string input, string expectedOutput)
        {
            var writer = new ChequeWriterStringStrategy();
            var actual = writer.ToWords(input);
            Assert.AreEqual(expectedOutput, actual);
        }
        [Test]
        [TestCase("0.01", "one cent")]
        [TestCase("0.73", "seventy three cents")]
        public void Writer_CentsOnly_ProducesExpected(string input, string expectedOutput)
        {
            var writer = new ChequeWriterStringStrategy();
            var actual = writer.ToWords(input);
            Assert.AreEqual(expectedOutput, actual);
        }
        
        [Test]
        [TestCase("635462.55", "six hundred and thirty five thousand four hundred and sixty two dollars and fifty five cents")]
        [TestCase("1.01", "one dollar and one cent")]
        [TestCase("0.00", "")]
        [TestCase("00.00", "")]
        [TestCase("000.00", "")]
        [TestCase("0000.00", "")]
        [TestCase("00000.00", "")]
        public void Writer_DollarsAndCents_ProducesExpected(string input, string expectedOutput)
        {
            var writer = new ChequeWriterStringStrategy();
            var actual = writer.ToWords(input);
            Assert.AreEqual(expectedOutput, actual);
        }
    }
}