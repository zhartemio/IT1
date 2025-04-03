using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ТI1
{
    class VigSipherator
    {
        private string KeyWord;
        private char[] Alphabet;

        public VigSipherator(string keyWord, char[] alphabet)
        {
            KeyWord=keyWord;
            Alphabet=alphabet;
        }

        public string VigEnsipher(string plaintext)
        {
            int keyWordLength, alphabetLenth;
            keyWordLength = KeyWord.Length;
            alphabetLenth = Alphabet.Length;
            string result = "";
            for (int i = 0; i < plaintext.Length; i++)
            {
                result += Alphabet[(Array.IndexOf(Alphabet, char.ToUpper(plaintext[i])) + Array.IndexOf(Alphabet, char.ToUpper(KeyWord[i % keyWordLength]))) % alphabetLenth];
            }
            return result;
        }

        public string CleanTextBox(string Text)
        {
            string result = "";

            for (int i = 0; i < Text.Length; i++)
            {
                if (Array.IndexOf(Alphabet, char.ToUpper(Text[i])) != -1)
                {
                    result += Text[i];
                }
            }
            return result;
        }
    }
}
