using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ТI1
{
    class Desipherator
    {
        private char[,] Array;
        private int Key;
        private char[] Alphabet;


        public Desipherator(int key, char[] alphabet)
        {
            Key = key;
            Alphabet = alphabet;
            Array = new char[2, 26];
            for (int i = 0; i < 26; i++)
            {
                Array[0, i] = alphabet[i]; 
            }
        }

        public void SetSecondRow(int key)
        {
            for(int i = 0; i < 26; i++)
            {
                Array[1,i] = Alphabet[i * key % 26];
                char ch = Array[1, i];
            }
        }

        public void ClearSecondRow()
        {
            for(int i = 0; i < 26; i++)
            {
                Array[1, i] = ' ';
            }
        }
        
        public string Desipher(string sipheredText)
        {
            string result = "";
            foreach(char c in sipheredText)
            {
                for(int i = 0; i < 26; i++)
                {
                    if(c == ' ')
                    {
                       result += ' ';
                        break;
                    }
                    if(char.ToUpper(c) == Array[1, i])
                    {
                        result += Array[0, i];
                        break;
                    }
                }
            }
            return result;
        }
        
    }
}
