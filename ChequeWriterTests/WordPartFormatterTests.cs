using ChequeWriter;
using System.Collections.Generic;
using NUnit.Framework;

namespace ChequeWriterTests
{
    [TestFixture]
    public class WordPartFormatterTests
    {
        [Test]
        public void Formatter_3Parts_FormatsMillionsThousandsAndLeftover()
        {
            var wordParts = new List<string>
            {
                "103",
                "246",
                "321",
            };

            var formatter = new WordPartsFormatter();
            var actual = formatter.Format(wordParts);

            Assert.AreEqual("321 million, 246 thousand 103", actual);
        }
    }
}