using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class Vigenere : Code
    {
        public int _alphSize { get; set; }
        public char[][] _alphabetMatrix { get; set; }
        public string _alphabet { get; set; }
        public string _text { get; set; }
        public string _key { get; set; }
        public Cezar _cezar { get; set; }
        public static int _keyCounter { get; set; }
        public string _encodedText { get; set; }

        public Vigenere(string key)
        {
            _key = key;
            //_text = text;
            _alphabet = "abcdefghijklmnopqrstuvwxyz";
            _alphSize = _alphabet.Length;
            _alphabetMatrix = new char[_alphSize][];
            _cezar = new Cezar();
            initializeAlphabetMatrix();
        }


        public string encode(string text)
        {
            _text = text;
            int k = 0;
            char[] encodingAlphabet;
            var indexSpaceList = text.ToCharArray().Select(c => { k += 1; return c == ' ' ? k : -1; }); // if space add index else add -1
            string encodedText = "";
            int indexInAlphabet;
            _keyCounter = 0;
            if (_text.Contains(" "))                                                 
            {
                _text = _text.Replace(" ", "");             // if text contains spaces, delete them
            }

            foreach (char letter in _text)
            {
                encodingAlphabet = _alphabetMatrix[getProperAlphabetIndex()];
                indexInAlphabet = _alphabet.IndexOf(letter);
                encodedText += encodingAlphabet[indexInAlphabet];
                _keyCounter %= _key.Length;
            }
            _keyCounter = 0;
            _encodedText = encodedText;
            encodedText = Tools.addSpaces(indexSpaceList, encodedText);
            return encodedText;
        }

        public string decode(string encodedText)
        {
            int k = 0;
            var indexSpaceList = encodedText.ToCharArray().Select(c => { k += 1; return c == ' ' ? k : -1; }); // if space add index else add -1
            string decodedText = "";
            int alphabetId = 0;
            int letterId = 0;

            if (encodedText.Contains(" ")) 
            {
                encodedText = encodedText.Replace(" ", "");             // if text contains spaces, delete them
            }

            foreach (char letter in encodedText)
            { 
                alphabetId = getProperAlphabetIndex();
                letterId = getLetterIndex(letter);
                decodedText += _alphabet[getFinalLetterIndex(letterId, alphabetId)];
            }

            decodedText = Tools.addSpaces(indexSpaceList, decodedText);
            return decodedText;
        }

        int getFinalLetterIndex(int letterId, int alphabetId)
        {
            if (letterId - alphabetId < 0)
                return _alphSize - Math.Abs(letterId - alphabetId);
            else
                return letterId - alphabetId;

        }        
        int getAlphabet(char letter)
        {
            for (int i = 0; i < _alphSize; i++)
            {
                if ((_alphabetMatrix[i])[0] == letter)
                {
                    return i;                       // return step for Cezar
                }
            }
            return -1;  //smth go wrong
        }


        int getLetterIndex(char lookingLetter)
        {
            int keyIndex = _keyCounter % 2;

            for (int i = 0; i <_alphSize; i++)
            {
                    if (_alphabet[i] == lookingLetter)
                    {
                        return i;
                    }
                }
            

            _keyCounter += 1;

            return keyIndex;
        }

            int getProperAlphabetIndex()
        {

            for (int i = 0; i < _alphSize; i++)
            {
               
                if ((_alphabetMatrix[i])[0] == _key[_keyCounter % _key.Length])
                {
                    _keyCounter += 1;
                    return i;
                }
            }
            return -1;
        }

       public char[][] initializeAlphabetMatrix()
        {
            for (int i = 0; i < _alphSize; i++)
            {
                    _cezar._step = i;
                    _alphabetMatrix[i] = _cezar.calculateCryptoAlphabet().ToCharArray();
            }
            return _alphabetMatrix;          
        }
    }
}
