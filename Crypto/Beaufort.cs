using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class Beaufort : Code
    {
        public string _key { get; set; }
        public Vigenere vigenere { get; set; }
        public char[][] _alphabetMatrix { get; set; }
        public Cezar _caesar { get; set; }
        public string _alphabet { get; set; }

        public Beaufort(string key)
        {
            _key = key;
            _caesar = new Cezar();
            _alphabet = "abcdefghijklmnopqrstuvwxyz";
            _alphabetMatrix = new char[_alphabet.Length][];
            _alphabetMatrix = initializeAlphabetMatrix();           
        }

        public string encode(string text)
        {
            string encodedText = "";
            string initializedKey;

            var indexSpaceList = Tools.getSpaceIndexes(text);

            if (text.Contains(" ")) ;                                                // if contains space, delete them
            {
                text = text.Replace(" ", "");
            }

            initializedKey = initializeKey(text);
 

            for (int i = 0; i < text.Length; i++)
            {
                encodedText += findEncodedChar(initializedKey[i], text[i]);
            }
            encodedText = Tools.addSpaces(indexSpaceList, encodedText);
            return encodedText;
        }



        public string decode(string text)
        {
           return encode(text);
        }

        char findEncodedChar(char keyChar, char textChar)
        {
            int i,j;

            for (i = 0; i < _alphabetMatrix[0].Length; i++)
            {
                if(_alphabetMatrix[0][i] == textChar)
                {
                    break;
                }
            }

            for ( j = 0; j < _alphabetMatrix[0].Length; j++)
            {
                if (_alphabetMatrix[j][i] == keyChar)
                {
                    break;
                }
            }

            return _alphabetMatrix[j][0];
        }

        string initializeKey(string text)
        {
            string initializedKey = "";

            for (int i = 0, j = 0; i < text.Length; i++, j++)
            {
                if (j == _key.Length)
                {
                    j = 0;
                }
                initializedKey += _key[j];
            }
            return initializedKey;
        }

        public char[][] initializeAlphabetMatrix()
        {
            for (int i = 0; i < _alphabet.Length; i++)
            {
                _caesar._step = i;
                _alphabetMatrix[i] = _caesar.calculateCryptoAlphabet().ToCharArray();
            }
            return _alphabetMatrix;
        }

    }
}
