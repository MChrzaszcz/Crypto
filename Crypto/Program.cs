using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Crypto
{
    /*Szyfry:
-Szyfr Cezara
-Płotkowy
-Hilla
-Viginere'a
-Playfaira
-Beaufort
-funkcja MD5
W przypadku projektu należy zaimplementować: na ocenę dst - trzy pierwsze szyfry, na ocenę db - pięć pierwszych szyfrów i na ocenę bdb - wszystkie szyfry. 
    * */
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Vigenere v = new Vigenere("rey", "akwarium");
            //string decTxt = v.encode();
            //v.decode(decTxt);


            //Cezar c = new Cezar(3);
            //string cEncTxt =  c.encode("akwarium");
            //string cDecTxt = c.decode(cEncTxt);

            //Hill hill = new Hill(DenseMatrix.OfArray(new double[,] {
            //{3,3},
            //{2,5}
            //}));
            //string a = hill.encrypt("vino");
            //string b = hill.decrypt(a);

            //string c = "";


            //Playfair pl = new Playfair(null, "snaiper", "ameba");
            //string enc = pl.encode();
            //pl.decode();

            //  Beaufort bb = new Beaufort("haslo");
            //  string en =  bb.encode("tajnainformacja");
            //  string de = bb.decode(en);

            Application.Run(new Form1());           

        }
    }
}
