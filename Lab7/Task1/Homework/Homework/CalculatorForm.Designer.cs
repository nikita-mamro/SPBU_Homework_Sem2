namespace Homework
{
    partial class CalculatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonRightBracket = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.buttonComma = new System.Windows.Forms.Button();
            this.buttonEquals = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.buttonMinus = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.buttonLeftBracket = new System.Windows.Forms.Button();
            this.buttonMultiply = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.buttonDivide = new System.Windows.Forms.Button();
            this.buttonEraseSymbol = new System.Windows.Forms.Button();
            this.buttonErase = new System.Windows.Forms.Button();
            this.textBoxCurrentInput = new System.Windows.Forms.TextBox();
            this.labelExpression = new System.Windows.Forms.Label();
            this.labelCurrentExpression = new System.Windows.Forms.Label();
            this.lastResultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(50, 244);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(500, 400);
            this.dataGridView1.TabIndex = 0;
            // 
            // buttonRightBracket
            // 
            this.buttonRightBracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRightBracket.Location = new System.Drawing.Point(150, 544);
            this.buttonRightBracket.Name = "buttonRightBracket";
            this.buttonRightBracket.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonRightBracket.Size = new System.Drawing.Size(100, 100);
            this.buttonRightBracket.TabIndex = 6;
            this.buttonRightBracket.Text = ")";
            this.buttonRightBracket.UseVisualStyleBackColor = true;
            this.buttonRightBracket.Click += new System.EventHandler(this.ButtonRightBracket_Click);
            // 
            // button0
            // 
            this.button0.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button0.Location = new System.Drawing.Point(250, 544);
            this.button0.Name = "button0";
            this.button0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button0.Size = new System.Drawing.Size(100, 100);
            this.button0.TabIndex = 8;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.Button0_Click);
            // 
            // buttonComma
            // 
            this.buttonComma.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonComma.Location = new System.Drawing.Point(50, 444);
            this.buttonComma.Name = "buttonComma";
            this.buttonComma.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonComma.Size = new System.Drawing.Size(100, 100);
            this.buttonComma.TabIndex = 9;
            this.buttonComma.Text = ",";
            this.buttonComma.UseVisualStyleBackColor = true;
            this.buttonComma.Click += new System.EventHandler(this.ButtonComma_Click);
            // 
            // buttonEquals
            // 
            this.buttonEquals.BackColor = System.Drawing.Color.PaleGreen;
            this.buttonEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEquals.Location = new System.Drawing.Point(350, 544);
            this.buttonEquals.Name = "buttonEquals";
            this.buttonEquals.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonEquals.Size = new System.Drawing.Size(100, 100);
            this.buttonEquals.TabIndex = 10;
            this.buttonEquals.Text = "=";
            this.buttonEquals.UseVisualStyleBackColor = false;
            this.buttonEquals.Click += new System.EventHandler(this.ButtonEquals_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(350, 444);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(100, 100);
            this.button1.TabIndex = 12;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(250, 444);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(100, 100);
            this.button2.TabIndex = 13;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(150, 444);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(100, 100);
            this.button3.TabIndex = 14;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // buttonPlus
            // 
            this.buttonPlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPlus.Location = new System.Drawing.Point(450, 544);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonPlus.Size = new System.Drawing.Size(100, 100);
            this.buttonPlus.TabIndex = 15;
            this.buttonPlus.Text = "+";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.ButtonPlus_Click);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMinus.Location = new System.Drawing.Point(450, 444);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonMinus.Size = new System.Drawing.Size(100, 100);
            this.buttonMinus.TabIndex = 16;
            this.buttonMinus.Text = "-";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.ButtonMinus_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(350, 344);
            this.button6.Name = "button6";
            this.button6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button6.Size = new System.Drawing.Size(100, 100);
            this.button6.TabIndex = 17;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Button6_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(250, 344);
            this.button5.Name = "button5";
            this.button5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button5.Size = new System.Drawing.Size(100, 100);
            this.button5.TabIndex = 18;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(150, 344);
            this.button4.Name = "button4";
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button4.Size = new System.Drawing.Size(100, 100);
            this.button4.TabIndex = 19;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // buttonLeftBracket
            // 
            this.buttonLeftBracket.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLeftBracket.Location = new System.Drawing.Point(50, 544);
            this.buttonLeftBracket.Name = "buttonLeftBracket";
            this.buttonLeftBracket.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonLeftBracket.Size = new System.Drawing.Size(100, 100);
            this.buttonLeftBracket.TabIndex = 20;
            this.buttonLeftBracket.Text = "(";
            this.buttonLeftBracket.UseVisualStyleBackColor = true;
            this.buttonLeftBracket.Click += new System.EventHandler(this.ButtonLeftBracket_Click);
            // 
            // buttonMultiply
            // 
            this.buttonMultiply.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonMultiply.Location = new System.Drawing.Point(450, 344);
            this.buttonMultiply.Name = "buttonMultiply";
            this.buttonMultiply.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonMultiply.Size = new System.Drawing.Size(100, 100);
            this.buttonMultiply.TabIndex = 21;
            this.buttonMultiply.Text = "×";
            this.buttonMultiply.UseVisualStyleBackColor = true;
            this.buttonMultiply.Click += new System.EventHandler(this.ButtonMultiply_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(350, 244);
            this.button9.Name = "button9";
            this.button9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button9.Size = new System.Drawing.Size(100, 100);
            this.button9.TabIndex = 22;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Button9_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(250, 244);
            this.button8.Name = "button8";
            this.button8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button8.Size = new System.Drawing.Size(100, 100);
            this.button8.TabIndex = 23;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Button8_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(150, 244);
            this.button7.Name = "button7";
            this.button7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button7.Size = new System.Drawing.Size(100, 100);
            this.button7.TabIndex = 24;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Button7_Click);
            // 
            // buttonDivide
            // 
            this.buttonDivide.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDivide.Location = new System.Drawing.Point(450, 244);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonDivide.Size = new System.Drawing.Size(100, 100);
            this.buttonDivide.TabIndex = 26;
            this.buttonDivide.Text = "÷";
            this.buttonDivide.UseVisualStyleBackColor = true;
            this.buttonDivide.Click += new System.EventHandler(this.ButtonDivide_Click);
            // 
            // buttonEraseSymbol
            // 
            this.buttonEraseSymbol.BackColor = System.Drawing.Color.LightCoral;
            this.buttonEraseSymbol.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEraseSymbol.Location = new System.Drawing.Point(50, 244);
            this.buttonEraseSymbol.Name = "buttonEraseSymbol";
            this.buttonEraseSymbol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonEraseSymbol.Size = new System.Drawing.Size(100, 100);
            this.buttonEraseSymbol.TabIndex = 27;
            this.buttonEraseSymbol.Text = "⌫";
            this.buttonEraseSymbol.UseVisualStyleBackColor = false;
            this.buttonEraseSymbol.Click += new System.EventHandler(this.ButtonEraseSymbol_Click);
            // 
            // buttonErase
            // 
            this.buttonErase.BackColor = System.Drawing.Color.LightCoral;
            this.buttonErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonErase.Location = new System.Drawing.Point(50, 344);
            this.buttonErase.Name = "buttonErase";
            this.buttonErase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonErase.Size = new System.Drawing.Size(100, 100);
            this.buttonErase.TabIndex = 28;
            this.buttonErase.Text = "C";
            this.buttonErase.UseVisualStyleBackColor = false;
            this.buttonErase.Click += new System.EventHandler(this.ButtonEraseAll_Click);
            // 
            // textBoxCurrentInput
            // 
            this.textBoxCurrentInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxCurrentInput.Location = new System.Drawing.Point(50, 78);
            this.textBoxCurrentInput.Name = "textBoxCurrentInput";
            this.textBoxCurrentInput.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxCurrentInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCurrentInput.Size = new System.Drawing.Size(500, 75);
            this.textBoxCurrentInput.TabIndex = 31;
            this.textBoxCurrentInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxCurrentInput_KeyPress);
            // 
            // labelExpression
            // 
            this.labelExpression.Location = new System.Drawing.Point(0, 0);
            this.labelExpression.Name = "labelExpression";
            this.labelExpression.Size = new System.Drawing.Size(100, 23);
            this.labelExpression.TabIndex = 35;
            // 
            // labelCurrentExpression
            // 
            this.labelCurrentExpression.Location = new System.Drawing.Point(0, 0);
            this.labelCurrentExpression.Name = "labelCurrentExpression";
            this.labelCurrentExpression.Size = new System.Drawing.Size(100, 23);
            this.labelCurrentExpression.TabIndex = 34;
            // 
            // lastResultLabel
            // 
            this.lastResultLabel.AutoSize = true;
            this.lastResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lastResultLabel.Location = new System.Drawing.Point(45, 184);
            this.lastResultLabel.Name = "lastResultLabel";
            this.lastResultLabel.Size = new System.Drawing.Size(0, 24);
            this.lastResultLabel.TabIndex = 33;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 683);
            this.Controls.Add(this.lastResultLabel);
            this.Controls.Add(this.labelCurrentExpression);
            this.Controls.Add(this.labelExpression);
            this.Controls.Add(this.textBoxCurrentInput);
            this.Controls.Add(this.buttonErase);
            this.Controls.Add(this.buttonEraseSymbol);
            this.Controls.Add(this.buttonDivide);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.buttonMultiply);
            this.Controls.Add(this.buttonLeftBracket);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonEquals);
            this.Controls.Add(this.buttonComma);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.buttonRightBracket);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalculatorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonRightBracket;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button buttonComma;
        private System.Windows.Forms.Button buttonEquals;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonLeftBracket;
        private System.Windows.Forms.Button buttonMultiply;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button buttonDivide;
        private System.Windows.Forms.Button buttonEraseSymbol;
        private System.Windows.Forms.Button buttonErase;
        private System.Windows.Forms.TextBox textBoxCurrentInput;
        private System.Windows.Forms.Label labelExpression;
        private System.Windows.Forms.Label labelCurrentExpression;
        private System.Windows.Forms.Label lastResultLabel;
    }
}

