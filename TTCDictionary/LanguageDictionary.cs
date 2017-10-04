using System.Collections.Generic;
using System.Linq;

namespace TTCDictionary
{
    /// <summary>
    /// Language Dictionary Class
    /// </summary>
    public class LanguageDictionary : ILanguageDictionary
    {
        private Dictionary<string, string> lngDictionary;

        /// <summary>
        /// Initialize the dictionary object for languague
        /// </summary>
        /// <param name="lngDictionary"></param>
        public LanguageDictionary(Dictionary<string, string> lngDictionary)
        {
            this.lngDictionary = lngDictionary;
        }

        /// <summary>
        /// Check method determines the word in dictionary if it exist then it return true else false.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="word"></param>
        /// <returns>true if exists else false</returns>
        public bool Check(string language, string word)
        {
            if (lngDictionary.Any(i => i.Key == language && i.Value == word))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Add method add to the dictionary for language. It returns true if it was successfully added. If it was not, it returns false.
        /// </summary>
        /// <param name="language"></param>
        /// <param name="word"></param>
        /// <returns>true if added successfully else false</returns>
        public bool Add(string language, string word)
        {
            if (lngDictionary.Any(i => i.Key == language && i.Value == word))
            {
                return false;
            }
            lngDictionary.Add(language, word);
            return true;
        }

        /// <summary>
        /// Search method finds the word in all languages that start with the `word`
        /// </summary>
        /// <param name="word"></param>
        /// <returns>return the searched items</returns>
        public IEnumerable<string> Search(string word)
        {
            List<string> searchedlist = (from x in lngDictionary where x.Value.Contains(word) select x.Value).ToList();
            return searchedlist;
        }
    }
}
