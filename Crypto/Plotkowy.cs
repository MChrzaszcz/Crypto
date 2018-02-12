using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class Plotkowy : Code
    {
        public int _rows { get; set; }
        public int _cols { get; set; }
        public string _text { get; set; }
        public string _encodedText { get; set; }


        public Plotkowy(int rows)
        {
            _rows = rows;
            
        }

        public string encode(string text)                // creating matrix with chars
        {

            
            string encodedText = "";          
            bool descend = true;
            var indexSpaceList = Tools.getSpaceIndexes(text);

            if (_rows == 1)
            {
                return text;
            }

            if (text.Contains(" ")) ;                                                // if contains space, delete them
            {
                text = text.Replace(" ", "");
            }

            _cols = text.Length;
            char[,] matrix = new char[_rows, _cols];
            initializeMatrix(matrix);


            for (int i = 0, j = 0; i < _cols; i++)
            {

                matrix[j, i] = text.ElementAt(i);

                if (j == _rows - 1)
                {
                    descend = false;
                }
                else if (j == 0)
                {
                    descend = true;
                }

                if (descend)
                    j += 1;
                else
                    j -= 1;

            }

            for (int i = 0; i < _rows; i++)             // reading rows of matrix and creating encoding text
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (matrix[i, j] != '.')
                    {
                        encodedText += matrix[i, j];
                    }
                }
            }
            _encodedText = encodedText;
            _encodedText = Tools.addSpaces(indexSpaceList, _encodedText);

            return _encodedText;
        }
        
        public string decode(string text)
        {

            var indexSpaceList = Tools.getSpaceIndexes(text);
            bool descend = true;
            string decodedText = "";

            if (_rows == 1)
            {
                return text;
            }

            if (text.Contains(" ")) ;                                                // if contains space, delete them
            {
                text = text.Replace(" ", "");
            }

            _cols = text.Length;
            char[,] decodeMatrix = new char[_rows, _cols];           
            initializeMatrix(decodeMatrix);



            for (int i = 0, j = 0; i < _cols; i++)  // initzialize matrix, set 'c' where will be any char
            {

                decodeMatrix[j, i] = 'c';

                if (j == _rows - 1)
                {
                    descend = false;
                }
                else if (j == 0)
                {
                    descend = true;
                }

                if (descend)
                    j += 1;
                else
                    j -= 1;

            }

            for (int i = 0, m = 0; i < _rows; i++)   // change 'c' to proper char
            {
                for (int j = 0; j < _cols; j++)
                {
                    if (decodeMatrix[i, j] == 'c')
                    {
                        decodeMatrix[i, j] = text[m];
                        m += 1;
                    }
                }
            }

            for (int i = 0, j = 0; i < _cols; i++)    // get text by walking through matrix
            {

                decodedText += decodeMatrix[j, i];

                if (j == _rows - 1)
                {
                    descend = false;
                }
                else if (j == 0)
                {
                    descend = true;
                }

                if (descend)
                    j += 1;
                else
                    j -= 1;

            }
            decodedText = Tools.addSpaces(indexSpaceList, decodedText);
            return decodedText;
        }





        private char[] initializeSubMatrix(char[] matrix)
        {
            for (int j = 0; j < _cols; j++)
            {
                matrix[j] = '.';
            }
            return matrix;
        }

        private char[,] initializeMatrix(char[,] matrix)
        {
            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _cols; j++)
                {
                    matrix[i, j] = '.';
                }
            }
            return matrix;
        }

    }
}
