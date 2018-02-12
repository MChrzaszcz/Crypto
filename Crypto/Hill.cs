using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Collections.Generic;


namespace Crypto
{
    class Hill : Code
    {
        public int _keySize { get; set; }  // text will be divided into n blocks       
        public string _text { get; set; }
        public Matrix<double> _encryptKey { get; set; }
        public Matrix<double> _decryptKey { get; set; }
        public string _alphabet = "abcdefghijklmnopqrstuvwxyz";
        const int _alphabetSize = 26;
        bool _isEncrypt;
        bool _isEven = true;



        public Hill(Matrix encryptKey)
        {
            _encryptKey = encryptKey;
            _decryptKey = getDecryptKey(_encryptKey);
            _isEncrypt = true;
        }


        public string encode(string text)
        {
            int encryptKeySize = _encryptKey.ColumnCount;
            int i = 0;
            int k = 0;
            int j = -encryptKeySize;
            Matrix<double> key;
            int nSizeBlock = 2;
            key = _isEncrypt ? _encryptKey : _decryptKey;                           // set key matrix : decrypt or encrypt
            var indexSpaceList = Tools.getSpaceIndexes(text);

            if (text.Contains(" "));                                                // if contains space, delete them
            {
                text = text.Replace(" ","");
            }

            if (text.Length % 2 != 0)                                               // if text isn't even add extra char
            {
                text += 'q';
            }

            var digits = text
                .Select(c => (double)(c - 97))                                      // convert letter to double in ASCII
                .ToArray();


            string output = text.ToCharArray()

                    .Where(d => { j++; i++; return i % encryptKeySize == 0; })                  // if modulo of index and key size is 0, take                                                                
                    .Select(d => digits.Skip(j).Take(nSizeBlock))                               // key size elements and create matrix                           
                    .Select(d => Matrix.Build.DenseOfColumnArrays(d.ToArray()))                 // that based on that elements;
                    .Select(matrix => key.Multiply(matrix))                                     // encrypt: multiply key and given matrixes;            
                    .SelectMany(d => d.ToColumnMajorArray())                                    // from matrix to array;                   
                    .Select(d => d.ToString(CultureInfo.CurrentCulture))                        // from array to string;
                    .Select(d => _alphabet[(Int32.Parse(d) % _alphabetSize)].ToString())        // convert digits to string
                    .Aggregate((a, b) => a + b);                                                // output string;

            output = Tools.addSpaces(indexSpaceList, output);
            return output;
          }       


        private string addSpaces(IEnumerable<int> indexSpaceList, string output)
        {
            foreach(int spaceIndex in indexSpaceList)
            {
                if(spaceIndex != -1)
                {
                    output = output.Insert(spaceIndex - 1, " ");
                }
            }
            return output;
            
        }

        public string decode(string text)
        {
            _isEncrypt = false;
            string decodedText = encode(text);
            int i = 0;

            if (decodedText[decodedText.Length - 1] == 'q')
            {
                decodedText = decodedText.Remove(text.Length - 1);
            }
            return decodedText;
        }

    
        Matrix<double> getDecryptKey(Matrix<double> matrix)
        {
            double determinant = Math.Round(matrix.Determinant());
            int reverseDeterminant = getReverseDeterminant(determinant);
            if (reverseDeterminant == 0)
            {
                return null;
            }
            Matrix<double> decryptKey = Matrix.Build.Dense(matrix.RowCount, matrix.ColumnCount);
            matrix.CopyTo(decryptKey);           
          
            decryptKey = findMinor(decryptKey);
            decryptKey = decryptKey.Transpose();            
            decryptKey.MapConvert(d => d < 0 ? _alphabetSize - (-d * reverseDeterminant) % _alphabetSize
                                 : (reverseDeterminant * d) % _alphabetSize
                                    , decryptKey);
          
            return decryptKey;
        }
        
        private void multiplyMatrixByDeterminant(Matrix<double> matrix, int determinant)
        {
            matrix.Map(d => d > 0 ? determinant * d : _alphabetSize - (-d * determinant) % _alphabetSize);   
        }

        private Matrix<double> findMinor(Matrix<double> matrix)
        {
            int i = 0;
            int j = 1;
            //Matrix<double> matrix2;
            Matrix<double> tempMatrix = Matrix.Build.Dense(matrix.RowCount, matrix.ColumnCount);
            Matrix<double> tempMatrix2 = Matrix.Build.Dense(matrix.RowCount, matrix.ColumnCount);
            Vector<double> vector = matrix.Row(0);

            for (int k1 = 0, k2 = matrix.RowCount - 1; k1 < matrix.RowCount ; k1++, k2--)  // column and rows number is equal
            {

 
                    vector = matrix.Row(k1);                // change order - rows
                    tempMatrix = tempMatrix.RemoveRow(k2);
                    tempMatrix = tempMatrix.InsertRow(k2, vector);
                

            }

            for (int k1 = 0, k2 = matrix.RowCount - 1; k1 < matrix.RowCount ; k1++, k2--)  // column and rows number is equal
            {
                vector = tempMatrix.Column(k1);                // change order - cols
                tempMatrix2 = tempMatrix2.RemoveColumn(k2);
                tempMatrix2 = tempMatrix2.InsertColumn(k2, vector);

                

            }

            tempMatrix2.MapConvert(d =>
            {
                i += 1;
                if (i == matrix.RowCount + 1)    // if itereation cross bounds switch to begining of next row
                {
                    i = 1;
                    j += 1;
                }
                return (j + i) % 2 == 0 ? d : d * (-1);
            }, tempMatrix2);   // if sum of j and i indexes isn't even multiply value, descripted by these indexes, by -1

            return tempMatrix2;
        }

        private int getReverseDeterminant(double determinant)
        {
            if(determinant > 0)
            for (int i = 0; ; i++)
            {
                if(determinant * i % _alphabetSize == 1)   //alphabetSize is a modulo
                {
                    return i;
                }
                if(i > 10000)
                    {
                        return 0;
                    }
            }

            else if(determinant < 0)
            {
                for (int i = 1; ; i++)
                {
                    if (_alphabetSize + ((determinant * i) % _alphabetSize) == 1)
                    {
                        return i;
                    }

                    if (i > 10000)
                    {
                        return 0;
                    }
                }
            }

            return 0;
        }
    } 
}
