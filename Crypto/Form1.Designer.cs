namespace Crypto
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.caesar = new System.Windows.Forms.RadioButton();
            this.plotkowy = new System.Windows.Forms.RadioButton();
            this.vigenere = new System.Windows.Forms.RadioButton();
            this.playfair = new System.Windows.Forms.RadioButton();
            this.hill = new System.Windows.Forms.RadioButton();
            this.beaufort = new System.Windows.Forms.RadioButton();
            this.selectEncryption = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.TextBox();
            this.inputKey = new System.Windows.Forms.TextBox();
            this.inputMatrix = new System.Windows.Forms.TextBox();
            this.input = new System.Windows.Forms.Label();
            this.matrix = new System.Windows.Forms.Label();
            this.key = new System.Windows.Forms.Label();
            this.outputText = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.Label();
            this.encode = new System.Windows.Forms.Button();
            this.decode = new System.Windows.Forms.Button();
            this.inputMatrixReverse = new System.Windows.Forms.TextBox();
            this.matrixReverse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // caesar
            // 
            this.caesar.AutoSize = true;
            this.caesar.Location = new System.Drawing.Point(42, 72);
            this.caesar.Name = "caesar";
            this.caesar.Size = new System.Drawing.Size(110, 21);
            this.caesar.TabIndex = 0;
            this.caesar.TabStop = true;
            this.caesar.Text = "Szyfr Cezara";
            this.caesar.UseVisualStyleBackColor = true;
            // 
            // plotkowy
            // 
            this.plotkowy.AutoSize = true;
            this.plotkowy.Location = new System.Drawing.Point(42, 110);
            this.plotkowy.Name = "plotkowy";
            this.plotkowy.Size = new System.Drawing.Size(119, 21);
            this.plotkowy.TabIndex = 1;
            this.plotkowy.TabStop = true;
            this.plotkowy.Text = "Szyfr płotkowy";
            this.plotkowy.UseVisualStyleBackColor = true;
            // 
            // vigenere
            // 
            this.vigenere.AutoSize = true;
            this.vigenere.Location = new System.Drawing.Point(42, 151);
            this.vigenere.Name = "vigenere";
            this.vigenere.Size = new System.Drawing.Size(122, 21);
            this.vigenere.TabIndex = 2;
            this.vigenere.TabStop = true;
            this.vigenere.Text = "Szyfr Vigenere";
            this.vigenere.UseVisualStyleBackColor = true;
            // 
            // playfair
            // 
            this.playfair.AutoSize = true;
            this.playfair.Location = new System.Drawing.Point(42, 191);
            this.playfair.Name = "playfair";
            this.playfair.Size = new System.Drawing.Size(123, 21);
            this.playfair.TabIndex = 3;
            this.playfair.TabStop = true;
            this.playfair.Text = "Szyfr Playfair\'a";
            this.playfair.UseVisualStyleBackColor = true;
            // 
            // hill
            // 
            this.hill.AutoSize = true;
            this.hill.Location = new System.Drawing.Point(42, 233);
            this.hill.Name = "hill";
            this.hill.Size = new System.Drawing.Size(93, 21);
            this.hill.TabIndex = 4;
            this.hill.TabStop = true;
            this.hill.Text = "szyfr Hill\'a";
            this.hill.UseVisualStyleBackColor = true;
            // 
            // beaufort
            // 
            this.beaufort.AutoSize = true;
            this.beaufort.Location = new System.Drawing.Point(42, 275);
            this.beaufort.Name = "beaufort";
            this.beaufort.Size = new System.Drawing.Size(125, 21);
            this.beaufort.TabIndex = 5;
            this.beaufort.TabStop = true;
            this.beaufort.Text = "szyfr Beauforta";
            this.beaufort.UseVisualStyleBackColor = true;
            // 
            // selectEncryption
            // 
            this.selectEncryption.Location = new System.Drawing.Point(42, 30);
            this.selectEncryption.Name = "selectEncryption";
            this.selectEncryption.Size = new System.Drawing.Size(85, 23);
            this.selectEncryption.TabIndex = 7;
            this.selectEncryption.Text = "Potwierdź";
            this.selectEncryption.UseVisualStyleBackColor = true;
            this.selectEncryption.Click += new System.EventHandler(this.selectCodeClick);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(324, 76);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(238, 22);
            this.inputText.TabIndex = 8;
            this.inputText.Visible = false;
            // 
            // inputKey
            // 
            this.inputKey.Location = new System.Drawing.Point(324, 126);
            this.inputKey.Name = "inputKey";
            this.inputKey.Size = new System.Drawing.Size(238, 22);
            this.inputKey.TabIndex = 9;
            this.inputKey.Visible = false;
            // 
            // inputMatrix
            // 
            this.inputMatrix.Location = new System.Drawing.Point(267, 257);
            this.inputMatrix.Multiline = true;
            this.inputMatrix.Name = "inputMatrix";
            this.inputMatrix.Size = new System.Drawing.Size(116, 198);
            this.inputMatrix.TabIndex = 10;
            this.inputMatrix.Visible = false;
            // 
            // input
            // 
            this.input.AutoSize = true;
            this.input.Location = new System.Drawing.Point(213, 74);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(61, 17);
            this.input.TabIndex = 11;
            this.input.Text = "Wejście:";
            this.input.Visible = false;
            // 
            // matrix
            // 
            this.matrix.AutoSize = true;
            this.matrix.Location = new System.Drawing.Point(289, 218);
            this.matrix.Name = "matrix";
            this.matrix.Size = new System.Drawing.Size(61, 17);
            this.matrix.TabIndex = 12;
            this.matrix.Text = "Macierz:";
            this.matrix.Visible = false;
            // 
            // key
            // 
            this.key.AutoSize = true;
            this.key.Location = new System.Drawing.Point(213, 126);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(46, 17);
            this.key.TabIndex = 13;
            this.key.Text = "Klucz:";
            this.key.Visible = false;
            // 
            // outputText
            // 
            this.outputText.Location = new System.Drawing.Point(324, 174);
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(238, 22);
            this.outputText.TabIndex = 14;
            this.outputText.Visible = false;
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.Location = new System.Drawing.Point(213, 173);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(60, 17);
            this.output.TabIndex = 15;
            this.output.Text = "Wyjście:";
            this.output.Visible = false;
            // 
            // encode
            // 
            this.encode.Location = new System.Drawing.Point(324, 21);
            this.encode.Name = "encode";
            this.encode.Size = new System.Drawing.Size(82, 32);
            this.encode.TabIndex = 16;
            this.encode.Text = "Zaszyfruj";
            this.encode.UseVisualStyleBackColor = true;
            this.encode.Click += new System.EventHandler(this.encodeClick);
            // 
            // decode
            // 
            this.decode.Location = new System.Drawing.Point(451, 21);
            this.decode.Name = "decode";
            this.decode.Size = new System.Drawing.Size(96, 32);
            this.decode.TabIndex = 17;
            this.decode.Text = "Odszyfruj";
            this.decode.UseVisualStyleBackColor = true;
            this.decode.Click += new System.EventHandler(this.decodeClick);
            // 
            // inputMatrixReverse
            // 
            this.inputMatrixReverse.Location = new System.Drawing.Point(446, 257);
            this.inputMatrixReverse.Multiline = true;
            this.inputMatrixReverse.Name = "inputMatrixReverse";
            this.inputMatrixReverse.Size = new System.Drawing.Size(116, 198);
            this.inputMatrixReverse.TabIndex = 18;
            this.inputMatrixReverse.Visible = false;
            // 
            // matrixReverse
            // 
            this.matrixReverse.AutoSize = true;
            this.matrixReverse.Location = new System.Drawing.Point(439, 218);
            this.matrixReverse.Name = "matrixReverse";
            this.matrixReverse.Size = new System.Drawing.Size(123, 17);
            this.matrixReverse.TabIndex = 19;
            this.matrixReverse.Text = "Macierz odwrotna:";
            this.matrixReverse.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 534);
            this.Controls.Add(this.matrixReverse);
            this.Controls.Add(this.inputMatrixReverse);
            this.Controls.Add(this.decode);
            this.Controls.Add(this.encode);
            this.Controls.Add(this.output);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.key);
            this.Controls.Add(this.matrix);
            this.Controls.Add(this.input);
            this.Controls.Add(this.inputMatrix);
            this.Controls.Add(this.inputKey);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.selectEncryption);
            this.Controls.Add(this.beaufort);
            this.Controls.Add(this.hill);
            this.Controls.Add(this.playfair);
            this.Controls.Add(this.vigenere);
            this.Controls.Add(this.plotkowy);
            this.Controls.Add(this.caesar);
            this.Name = "Form1";
            this.Text = "Kryptografia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton caesar;
        private System.Windows.Forms.RadioButton plotkowy;
        private System.Windows.Forms.RadioButton vigenere;
        private System.Windows.Forms.RadioButton playfair;
        private System.Windows.Forms.RadioButton hill;
        private System.Windows.Forms.RadioButton beaufort;
        private System.Windows.Forms.Button selectEncryption;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.TextBox inputKey;
        private System.Windows.Forms.TextBox inputMatrix;
        private System.Windows.Forms.Label input;
        private System.Windows.Forms.Label matrix;
        private System.Windows.Forms.Label key;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.Button encode;
        private System.Windows.Forms.Button decode;
        private System.Windows.Forms.TextBox inputMatrixReverse;
        private System.Windows.Forms.Label matrixReverse;
    }
}

