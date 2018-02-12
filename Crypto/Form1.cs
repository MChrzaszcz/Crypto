using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Form1 : Form
    {
        private Code code;
        public Form1()
        {
            InitializeComponent();
        }

        private void selectCodeClick(object sender, EventArgs e)
        {
            hideAll();
            cleanAll();

            if (hill.Checked)
            {
                matrixVisible();

            }
            else
            {
                standardVisible();
            }
        }

        private void encodeClick(object sender, EventArgs e)
        {
            setInputCode();

            if (code is Hill)
            {
                if (((Hill)code)._decryptKey == null)
                {
                    MessageBox.Show("Wprowadzono niewłaściwą macierz.");
                    return;
                }
            }

            outputText.Text = code.encode(inputText.Text);
        }

        private void decodeClick(object sender, EventArgs e)
        {
            setInputCode();
            if (code is Hill)
            {
                if (((Hill)code)._decryptKey == null)
                {
                    MessageBox.Show("Wprowadzono niewłaściwą macierz.");
                    return;
                }
            }

            outputText.Text = code.decode(inputText.Text);
        }

        void setInputCode()
        {
            string text = "";

            if (caesar.Checked)
            {
                int step = Int32.Parse(inputKey.Text);
                text = inputText.Text;
                code = new Cezar(step);
            }
            else if (plotkowy.Checked)
            {
                int rows = Int32.Parse(inputKey.Text);
                text = inputText.Text;
                code = new Plotkowy(rows);
            }
            else if (vigenere.Checked)
            {
                string key = inputKey.Text;
                text = inputText.Text;
                code = new Vigenere(key);
            }
            else if (playfair.Checked)
            {
                string key = inputKey.Text;
                text = inputText.Text;
                code = new Playfair(key);
            }
            else if (beaufort.Checked)
            {
                string key = inputKey.Text;
                text = inputText.Text;
                code = new Beaufort(key);
            }
            else if (hill.Checked)
            {
                string key = inputMatrix.Text;
                text = inputText.Text;
                inputMatrixReverse.Text = "";
               // inputMatrix.Text = "";
                //Matrix<double> keyMatrix = DenseMatrix.OfArray(stringToArray(key));
                Hill hill = new Hill(DenseMatrix.OfArray(stringToArray(key)));
                code = hill;
                if (hill._decryptKey == null)
                {
                    return;
                }
                
                var arr = hill._decryptKey.ToArray();

                for (int i = 0, j= 0; i < 2; j++)
                {
                    if(j == 2)
                    {
                        inputMatrixReverse.Text += "\r\n";
                        j = -1;
                        i += 1;
                        continue;
                    }
                    
                    inputMatrixReverse.Text += arr[i,j] ;
                    if (j != 1)
                    {
                        inputMatrixReverse.Text += " ";
                    }
                    hill._decryptKey = DenseMatrix.OfArray(stringToArray(key));
                }
                string reverseKey = inputMatrixReverse.Text;
                hill._decryptKey = DenseMatrix.OfArray(stringToArray(reverseKey));
                //inputMatrixReverse.Text = hill._decryptKey.ToArray().ToString();


            }
        }

        private double[,] stringToArray(string text)
        {
            int j = 1;
            for (int i = 0; i < text.Length - 1; i++)
            {
                char a = text[i];
                char b = text[i + 1];
                if (text[i] == ' ' && Char.IsDigit(text[i + 1]) || Char.IsDigit(text[i]) && text[i + 1] == '\r')
                {
                    if (text[i + 1] == '\r')
                        break;
                    j += 1;
                }
            }

            double[,] array = new double[j, j];
            string digit = "";
            j = 0;

            for (int i = 0, i1 = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    digit += text[i];
                }
               
                    if (i == text.Length - 1 && Char.IsDigit(text[i]))
                    {
                    array[j, i1] = Double.Parse(digit);
                    break;
                }

                    if (Char.IsDigit(text[i]) && !Char.IsDigit(text[i + 1]))
                    {
                        array[j, i1] = Double.Parse(digit);
                        digit = "";
                        i1 += 1;
                    }
                  

                    if (text[i] == '\r')
                    {
                        j += 1;
                        i1 = 0;
                    }
                }
            
            return array;
        }

        private void standardVisible()
        {
            key.Visible = true;
            inputKey.Visible = true;
            inputText.Visible = true;
            input.Visible = true;
            output.Visible = true;
            encode.Visible = true;
            decode.Visible = true;
            outputText.Visible = true;
            output.Visible = true;
        }

        private void matrixVisible()
        {
           // standardVisible();
           // key.Visible = true;
            //inputKey.Visible = true;
            inputText.Visible = true;
            input.Visible = true;
            output.Visible = true;
            encode.Visible = true;
            decode.Visible = true;
            outputText.Visible = true;
            output.Visible = true;
            inputMatrix.Visible = true;
            matrix.Visible = true;
            matrixReverse.Visible = true;
            inputMatrixReverse.Visible = true;

            //inputMatrix.Visible = true;
            //textInput.Visible = true;
            //text.Visible = true;
            //encodedText.Visible = true;
            //encode.Visible = true;
            //decode.Visible = true;
        }

        private void cleanAll()
        {
            inputKey.Text = "";
            inputMatrix.Text = "";
            inputMatrixReverse.Text = "";
            inputText.Text = "";
            outputText.Text = "";
        }

        private void hideAll()
        {
            key.Visible = false;
            inputKey.Visible = false;
            inputMatrix.Visible = false;
            matrix.Visible = false;
            inputText.Visible = false;
            input.Visible = false;
            output.Visible = false;
            encode.Visible = false;
            decode.Visible = false;
            outputText.Visible = false;
            output.Visible = false;
            matrix.Visible = false;
            matrixReverse.Visible = false;
            inputMatrixReverse.Visible = false;
        }
    }
}
