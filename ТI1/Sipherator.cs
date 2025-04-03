using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ТI1
{
    public class Sipherator
    { 
        private char[] Alphabet;
        private int Key;

        public Sipherator(int key, char[] alphabet)
        {
            Key = key;
            Alphabet = alphabet;
        }

        

        public string Ensipher(string plainText)
        {
            int i = 0;
            string result = "";
            char[] symbols = plainText.ToCharArray();
            foreach (char c in symbols)
            {
                i = Array.IndexOf(Alphabet, char.ToUpper(c));
                if (i != -1)
                {
                    result += Alphabet.ElementAt(i * Key % Alphabet.Length);
                }
                else
                {
                    if (c == ' ')
                    {
                        result += ' ';
                    }
                }
            }
            return result;
        }
    }
}
