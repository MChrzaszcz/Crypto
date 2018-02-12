using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class Cezar : Code
    {
        public string _alphabet { get; set; }
        public string _cryptoAlphabet { get; set; }
        public int _step { get; set; }
        public string _text { get; set; }
        public string _encodedText { get; set; }

        public Cezar(int step)
        {
            _alphabet = "abcdefghijklmnopqrstuvwxyz";
            _step = step;
            calculateCryptoAlphabet();
        }

        public Cezar()
        {
            _alphabet = "abcdefghijklmnopqrstuvwxyz";
        }

        public string calculateCryptoAlphabet()
        {
            _cryptoAlphabet = "";

            for (int i = _step; i < _alphabet.Length; i++)
            {
                _cryptoAlphabet += _alphabet[i];
            }
            for (int i = 0; i < _step; i++)
            {
                _cryptoAlphabet += _alphabet[i];
            }
            return _cryptoAlphabet;
        }

        public string encode(string text)
        {
            _text = text;
            string encodedText = "";
            int indexInAlphabet;

            var indexSpaceList = Tools.getSpaceIndexes(_text);

            if (_text.Contains(" ")) ;                                                // if contains space, delete them
            {
                _text = text.Replace(" ", "");
            }


            foreach (char letter in _text)
            {
                indexInAlphabet = _alphabet.IndexOf(letter);
                encodedText += _cryptoAlphabet[indexInAlphabet];
            }
            encodedText = Tools.addSpaces(indexSpaceList, encodedText);
            return encodedText;
        }

        public string decode(string text)
        {
            _text = text;
            string decodedText = "";
            int indexInAlphabet;

            var indexSpaceList = Tools.getSpaceIndexes(_text);

            if (_text.Contains(" ")) ;                                                // if contains space, delete them
            {
                _text = _text.Replace(" ", "");
            }

            calculateCryptoAlphabet();

            foreach (char letter in text)
            {
                indexInAlphabet = _cryptoAlphabet.IndexOf(letter);
                if (indexInAlphabet - _step < 0)
                {
                    indexInAlphabet = _cryptoAlphabet.Length - Math.Abs(indexInAlphabet - _step);
                }
                else indexInAlphabet -= _step;
                decodedText += _cryptoAlphabet[indexInAlphabet]; 
            }

            decodedText = Tools.addSpaces(indexSpaceList, decodedText);
            return decodedText;
        }

    }
}