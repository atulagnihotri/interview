using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;

namespace TTCDictionary.UnitTests
{
    [TestFixture]
    public class LanguageDictionaryTest
    {
        private LanguageDictionary lDictionary;

        private Dictionary<string, string> lstDictionary;

        [SetUp]
        public void Setup()
        {
            lstDictionary = new Dictionary<string, string>();

            lDictionary = new LanguageDictionary(lstDictionary);
        }

        #region Test cases for Adding value to dictionary
        [Test]
        public void When_adding_a_word_which_does_not_exist_should_return_true()
        {
            // Arrange.
            var word = "en";
            var lang = "English";

            // Act.
            var result = this.lDictionary.Add(lang, word);

            // Assert.
            Assert.IsTrue(result);

            var listCheck = this.lstDictionary.FirstOrDefault(i => i.Key == lang && i.Value == word);

            Assert.IsTrue(listCheck.Key == lang);
            Assert.IsTrue(listCheck.Value == word);
        }

        [Test]
        public void When_adding_a_word_which_does_exist_should_return_false()
        {
            // Arrange.
            var word = "en";
            this.lDictionary.Add("English", word);

            // Act.
            var result = this.lDictionary.Add("English", word);

            // Assert.
            Assert.IsFalse(result);
        }

        [Test]
        public void When_adding_a_word_which_does_exist_but_in_a_different_language_should_return_true()
        {
            // Arrange.
            var word = "en";
            this.lDictionary.Add("English", word);

            // Act.
            var result = this.lDictionary.Add("German", word);

            // Assert.
            Assert.IsTrue(result);
        }
        #endregion

        #region Test cases for checking value in dictionary
        [Test]
        public void When_checking_a_word_which_does_not_exist_should_return_false()
        {
            // Arrange.
            var word = "en";

            // Act.
            var result = this.lDictionary.Check("English", word);

            // Assert.
            Assert.IsFalse(result);
        }

        [Test]
        public void When_checking_a_word_which_does_exist_should_return_true()
        {
            // Arrange.
            var word = "en";
            this.lDictionary.Add("English", word);

            // Act.
            var result = this.lDictionary.Check("English", word);

            // Assert.
            Assert.IsTrue(result);
        }
        #endregion

        #region Test cases for searching value in dictionary
        [Test]
        public void When_searching_a_word_which_does_exist_should_return_value()
        {
            // Arrange.
            this.lDictionary.Add("English", "en");
            this.lDictionary.Add("German", "de");
            // Act.
            var result = this.lDictionary.Search("en");

            // Assert.
            Assert.IsTrue(result.Contains("en"));
        }

        [Test]
        public void When_searching_a_word_which_does_not_exist_should_return_empty_list()
        {
            // Arrange.
            this.lDictionary.Add("English", "en");
            this.lDictionary.Add("German", "de");
            // Act.
            var result = this.lDictionary.Search("es-ES");

            // Assert.
            Assert.That(result, Is.Empty);
            Assert.IsFalse(result.Contains("es-ES"));
        }
        #endregion

        /// <summary>
        /// Dispose all the object to clean up the memory
        /// </summary>
        [TearDown]
        public void Dispose()
        {
            lstDictionary = null;
            lDictionary = null;
        }
    }
}
