namespace TestTask
{
    partial class Form1
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
            this.RunningButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RunningButton
            // 
            this.RunningButton.BackColor = System.Drawing.Color.Red;
            this.RunningButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RunningButton.ForeColor = System.Drawing.Color.White;
            this.RunningButton.Location = new System.Drawing.Point(0, 1);
            this.RunningButton.Name = "RunningButton";
            this.RunningButton.Size = new System.Drawing.Size(400, 553);
            this.RunningButton.TabIndex = 0;
            this.RunningButton.Text = "Press Me";
            this.RunningButton.UseVisualStyleBackColor = false;
            this.RunningButton.Click += new System.EventHandler(this.RunningButton_Click);
            this.RunningButton.MouseEnter += new System.EventHandler(this.RunningButton_MouseEnter);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.RunningButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RunningButton;
    }
}

