namespace Laba1_MCT
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
            this.buttonAnalysis = new System.Windows.Forms.Button();
            this.textBoxMainText = new System.Windows.Forms.TextBox();
            this.textBoxLeksem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewIdentificators = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProverka = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPolis = new System.Windows.Forms.TextBox();
            this.buttonTest = new System.Windows.Forms.Button();
            this.richTextBoxStack = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIdentificators)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAnalysis
            // 
            this.buttonAnalysis.AutoSize = true;
            this.buttonAnalysis.Location = new System.Drawing.Point(16, 187);
            this.buttonAnalysis.Name = "buttonAnalysis";
            this.buttonAnalysis.Size = new System.Drawing.Size(108, 43);
            this.buttonAnalysis.TabIndex = 0;
            this.buttonAnalysis.Text = "Анализ";
            this.buttonAnalysis.UseVisualStyleBackColor = true;
            this.buttonAnalysis.Click += new System.EventHandler(this.buttonAnalysis_Click);
            // 
            // textBoxMainText
            // 
            this.textBoxMainText.Location = new System.Drawing.Point(12, 38);
            this.textBoxMainText.Name = "textBoxMainText";
            this.textBoxMainText.Size = new System.Drawing.Size(1530, 26);
            this.textBoxMainText.TabIndex = 1;
            this.textBoxMainText.Text = "if x < 5 then x = s + 1 ; s = x + 2 ; elseif x < 6 then y = s + 1 ; elseif x < 7 " +
    "then z = x + 1 + 5 ; y = z - 4 ; x = z ; else s = x ; x = y + 1 + 3 ; z = s ;  ";
            // 
            // textBoxLeksem
            // 
            this.textBoxLeksem.Location = new System.Drawing.Point(12, 92);
            this.textBoxLeksem.Name = "textBoxLeksem";
            this.textBoxLeksem.Size = new System.Drawing.Size(1530, 26);
            this.textBoxLeksem.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Исходный текст";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Последовательность лексем";
            // 
            // dataGridViewIdentificators
            // 
            this.dataGridViewIdentificators.AllowUserToAddRows = false;
            this.dataGridViewIdentificators.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIdentificators.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnName,
            this.ColumnType});
            this.dataGridViewIdentificators.Location = new System.Drawing.Point(12, 262);
            this.dataGridViewIdentificators.Name = "dataGridViewIdentificators";
            this.dataGridViewIdentificators.RowTemplate.Height = 28;
            this.dataGridViewIdentificators.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewIdentificators.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIdentificators.Size = new System.Drawing.Size(504, 410);
            this.dataGridViewIdentificators.TabIndex = 9;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Name";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Type";
            this.ColumnType.Name = "ColumnType";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(306, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Таблица идентификаторов и констант";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Проверка:";
            // 
            // textBoxProverka
            // 
            this.textBoxProverka.Location = new System.Drawing.Point(130, 147);
            this.textBoxProverka.Name = "textBoxProverka";
            this.textBoxProverka.Size = new System.Drawing.Size(1412, 26);
            this.textBoxProverka.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Полис:";
            // 
            // textBoxPolis
            // 
            this.textBoxPolis.Location = new System.Drawing.Point(130, 204);
            this.textBoxPolis.Name = "textBoxPolis";
            this.textBoxPolis.Size = new System.Drawing.Size(1412, 26);
            this.textBoxPolis.TabIndex = 15;
            // 
            // buttonTest
            // 
            this.buttonTest.AutoSize = true;
            this.buttonTest.Location = new System.Drawing.Point(16, 130);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(108, 43);
            this.buttonTest.TabIndex = 17;
            this.buttonTest.Text = "Тест";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // richTextBoxStack
            // 
            this.richTextBoxStack.Location = new System.Drawing.Point(549, 262);
            this.richTextBoxStack.Name = "richTextBoxStack";
            this.richTextBoxStack.Size = new System.Drawing.Size(359, 410);
            this.richTextBoxStack.TabIndex = 18;
            this.richTextBoxStack.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(545, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Значения переменных:";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.AutoSize = true;
            this.buttonCalculate.Location = new System.Drawing.Point(929, 262);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(108, 43);
            this.buttonCalculate.TabIndex = 20;
            this.buttonCalculate.Text = "Вычислить";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1578, 684);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBoxStack);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPolis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxProverka);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewIdentificators);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxLeksem);
            this.Controls.Add(this.textBoxMainText);
            this.Controls.Add(this.buttonAnalysis);
            this.MinimumSize = new System.Drawing.Size(1600, 700);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ЛР №4 Создание интерпретатора Хисматуллин А. И.";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIdentificators)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAnalysis;
        private System.Windows.Forms.TextBox textBoxMainText;
        private System.Windows.Forms.TextBox textBoxLeksem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridViewIdentificators;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProverka;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPolis;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.RichTextBox richTextBoxStack;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonCalculate;
    }
}

