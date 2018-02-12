using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    class Playfair : Code
    {
        //public char[,] _matrix { get; set; }
        public string _key { get; set; }
        public string _alphabet { get; set; }
        public string  _text { get; set; }
        public string _encodedText { get; set; }


        public Playfair(string key)
        {
            //_matrix = matrix;
            _key = key;
            //_text = text;
            _alphabet = "abcdefghiklmnopqrstuvwxyz";
        }

        public string encode(string text)
        {
            _text = text;
            var indexSpaceList = Tools.getSpaceIndexes(_text);

            if (_text.Contains(" ")) ;                                                // if contains space, delete them
            {
                _text = _text.Replace(" ", "");
            }

            char[,] keyMatrix = calculateKeyMatrix(getUnrepeatedKey());
            char[,] dividedText = divideTextTo2Char();
            List<List<char>> encryptedDividedText = encodeDecodeDividedText(keyMatrix, dividedText, false);
            _encodedText = extractTextFromCharList(encryptedDividedText);
            _encodedText = Tools.addSpaces(indexSpaceList, _encodedText);
            return _encodedText;
        }

        public string decode(string text)
        {
            _text = text;
            var indexSpaceList = Tools.getSpaceIndexes(_text);

            if (_text.Contains(" ")) ;                                                // if contains space, delete them
            {
                _text = text.Replace(" ", "");
            }

            char[,] keyMatrix = calculateKeyMatrix(getUnrepeatedKey());
            char[,] dividedText = divideTextTo2Char();
            List<List<char>> decryptedDividedText = encodeDecodeDividedText(keyMatrix, dividedText, true);
            string decodedText = extractTextFromCharList(decryptedDividedText);
            decodedText = Tools.addSpaces(indexSpaceList, decodedText);
            return decodedText;
        }


        /// <summary>
        /// Encode or decode given list of list of char. Inner list contains 2 column, outer contains rows
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="dividedText"></param>
        /// <param name="decode"></param>
        /// <returns></returns>
        List<List<char>> encodeDecodeDividedText(char[,] matrix, char[,] dividedText, bool decode)
        {

            List<List<int>> charCoordinates = getCharCoordinates(matrix, dividedText);
            List<List<char>> encodedDividedText = new List<List<char>>();
           
            
            for (int row = 0, col1 = 0, col2 = 0, row1 = 0, row2 = 0; row < charCoordinates.Count; row++) // row1,col1 indicate to location
            {                                                                                             // of first char of 2-element dividedText(list).
                List<int> lineCoordinantes = charCoordinates.ElementAt(row);                              // row12,col12 indicate to location
                List<char> encodedDividedLine = new List<char>();                                         // of second char of 2-element dividedText(list)
                int direction = decode ? -1 : 1;

                // diffrent row and col
                if (lineCoordinantes.ElementAt(0) != lineCoordinantes.ElementAt(2) &&
                    lineCoordinantes.ElementAt(1) != lineCoordinantes.ElementAt(3))
                {
                    col1 = lineCoordinantes.ElementAt(3);
                    col2 = lineCoordinantes.ElementAt(1);
                    row1 = lineCoordinantes.ElementAt(0);
                    row2 = lineCoordinantes.ElementAt(2);
                }
                // the same col 
                else if (lineCoordinantes.ElementAt(0) != lineCoordinantes.ElementAt(2))                   
                {
                    col1 = lineCoordinantes.ElementAt(1);
                    col2 = lineCoordinantes.ElementAt(3);


                    if (lineCoordinantes.ElementAt(0) == matrix.GetLength(0) - 1 && direction == 1)   //if first char will be in the right edge
                    {
                        row1 = 0;
                        row2 = lineCoordinantes.ElementAt(2) + direction;
                    }
                    else if (lineCoordinantes.ElementAt(2) == matrix.GetLength(0) - 1 && direction == 1)  //if second char will be in the right edge
                    {
                        row1 = lineCoordinantes.ElementAt(0) + direction;
                        row2 = 0;
                    }
                    else if (lineCoordinantes.ElementAt(0) == 0 && direction == -1)  //if second char will be in the left edge
                    {
                        row1 = matrix.GetLength(0) - 1;
                        row2 = lineCoordinantes.ElementAt(2) + direction;
                    }
                    else if (lineCoordinantes.ElementAt(2) == 0 && direction == -1)  //if second char will be in the left edge
                    {
                        row1 = lineCoordinantes.ElementAt(0) + direction;
                        row2 = matrix.GetLength(0) - 1;
                    }
                    else                                                            //if chars will be in the middle of the matrix
                    {
                        row1 = lineCoordinantes.ElementAt(0) + direction;
                        row2 = lineCoordinantes.ElementAt(2) + direction;
                    }
                    
                }
                // the same row
                else if (lineCoordinantes.ElementAt(1) != lineCoordinantes.ElementAt(3))
                {
                    row1 = lineCoordinantes.ElementAt(0);
                    row2 = lineCoordinantes.ElementAt(2);                   

                    if (lineCoordinantes.ElementAt(1) == matrix.GetLength(1) - 1 && direction == 1)  //if first char will be in the edge
                    {
                        col1 = 0;
                        col2 = lineCoordinantes.ElementAt(3) + direction;
                    }
                    else if (lineCoordinantes.ElementAt(3) == matrix.GetLength(1) - 1 && direction == 1) //if second char will be in the edge
                    {
                        col1 = lineCoordinantes.ElementAt(1) + direction;
                        col2 = 0;
                    }
                    else if (lineCoordinantes.ElementAt(1) == 0 && direction == -1) //if second char will be in the edge
                    {
                        col1 = matrix.GetLength(1) - 1;
                        col2 = lineCoordinantes.ElementAt(3) + direction;
                    }
                    else if (lineCoordinantes.ElementAt(3) == 0 && direction == -1) //if second char will be in the edge
                    {
                        col1 = lineCoordinantes.ElementAt(1) + direction;
                        col2 = matrix.GetLength(1) - 1;
                    }
                    else
                    {
                        col1 = lineCoordinantes.ElementAt(1) + direction;
                        col2 = lineCoordinantes.ElementAt(3) + direction;
                    }
                }

                encodedDividedLine.Add(matrix[row1,col1]);
                encodedDividedLine.Add(matrix[row2,col2]);
                encodedDividedText.Insert(row, encodedDividedLine);

            }
            return encodedDividedText;
        }



        /// <summary>
        /// Returns a list of list. Inner list contains coordinats of 2 chars from divided text. 0 and 2 Indexes indicate to rows,
        /// 1 and 3 indicates to columns.
        /// </summary>
        /// <param name="matrix">
        /// Matrix of key.
        /// </param>
        /// <param name="dividedText"></param>
        /// <returns></returns>
        List<List<int>> getCharCoordinates(char[,] matrix, char[,] dividedText)
        {
            const int coordinatesAmount = 2;
            List<int> coordinate = null;
            List<List<int>> charCoordinates = new List<List<int>>();
            char[,] encodedDividedText = new char[dividedText.GetLength(0), dividedText.GetLength(0)];
            int a = dividedText.GetLength(0); //row
            int b = dividedText.GetLength(1); // col
            int c = dividedText.Length;


            for (int row1 = 0; row1 < dividedText.GetLength(0); row1++)
            {
                coordinate = new List<int>(coordinatesAmount);

                for (int  col1 = 0; col1 < dividedText.GetLength(1); col1++)
                {
                    for (int row2 = 0; row2 < matrix.GetLength(0); row2++)
                    {
                        for (int col2 = 0; col2 < matrix.GetLength(1); col2++)
                        {
                            if (matrix[row2, col2] == dividedText[row1, col1])
                            {                                
                                coordinate.Add(row2);
                                coordinate.Add(col2);
                            }
                        }                       
                    }                                                            
                }
                 charCoordinates.Add(coordinate);
            }
            return charCoordinates;
        }

        string extractTextFromCharList(List<List<char>> dividexText)
        {
            string text = "";
            int rowSize = (int)Math.Ceiling((double)text.Length / 2);


            for (int row = 0, i = 0; i < dividexText.Count; row++, i++)
            {
                for (int col = 0; col < dividexText.ElementAt(0).Count; col++)
                {
                    text += dividexText.ElementAt(row).ElementAt(col);
                }

                
            }

            return text;
        }

            char[,] divideTextTo2Char()
            {
            string text = _text;

            if (text.Length % 2 != 0)
            {
                text += "x";
            }

            int rowSize = (int)Math.Ceiling((double)text.Length / 2);
            char[,] dividedText = new char[rowSize, 2];


            for (int row = 0, col = 0, i = 0; i < text.Length; col++, i++)
            {
                if (col % 2 == 0 && row != 0 || row == 0 && col == 2)
                {
                    row += 1;
                    col = 0;
                }

                dividedText[row, col] = text.ElementAt(i);
            }
            return dividedText;
        }


        char[,] calculateKeyMatrix(string unrepeatedKey)
        {
            char[,] keyMatrix = new char[5, 5];
            int i = 0, j = 0;

            //Add unrepeated key to entry matrix
            for (int k = 0; ; j++)
            {
                if (j > keyMatrix.GetLength(0) - 1)
                {
                    i += 1;
                    k += j;
                    j = 0;
                }

                if (j + k > unrepeatedKey.Length - 1)
                {
                    break;
                }
                keyMatrix[i, j] = unrepeatedKey[j + k];
            }


            int indexOfLastChar = _alphabet.IndexOf(unrepeatedKey.Last()); // k =  get index in alphabet of the last char in unrepeatedKey 

            // Add rest of alphabet to entry matrix
            for (int k = indexOfLastChar;  ; k++)  
            {
                if (keyMatrix[4,4] != '\0')
                {
                    break;
                }

                if (k == _alphabet.Length)
                {
                    k = 0;
                }               

                if (j > keyMatrix.GetLength(0) - 1)
                {
                    i += 1;
                    j = 0;
                }


                if (!unrepeatedKey.Contains(_alphabet[k]))
                {
                    keyMatrix[i, j] = _alphabet[k];
                    j += 1;
                }
            }

            return keyMatrix;
        }

        public string getUnrepeatedKey()
        {
            string unrepeatedKey = _key;


            for (int i = 0; i < unrepeatedKey.Length; i++)
            {
                for (int j = i + 1; j < unrepeatedKey.Length ; j++)
                {
                    if (unrepeatedKey[j] == unrepeatedKey[i] || unrepeatedKey[j] == ' ')
                    {
                        unrepeatedKey = unrepeatedKey.Remove(j, 1);
                    }
                }
            }
            return unrepeatedKey;
        }
    }
}
