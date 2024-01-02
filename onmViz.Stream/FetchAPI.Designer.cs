namespace onmViz.Stream
{
    partial class FetchAPI
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
            textBox1 = new TextBox();
            button1 = new Button();
            CloseBtn = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            TxtBoxJustificativa = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(209, 9);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(182, 27);
            textBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(778, 9);
            button1.Name = "button1";
            button1.Size = new Size(119, 29);
            button1.TabIndex = 1;
            button1.Text = "Confirmar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CloseBtn
            // 
            CloseBtn.Location = new Point(903, 9);
            CloseBtn.Name = "CloseBtn";
            CloseBtn.Size = new Size(119, 29);
            CloseBtn.TabIndex = 2;
            CloseBtn.Text = "Fechar";
            CloseBtn.UseVisualStyleBackColor = true;
            CloseBtn.Click += CloseBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 47);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1878, 974);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.Location = new Point(1602, 5);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 6;
            button2.Text = "Teste";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(1175, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(91, 27);
            textBox2.TabIndex = 7;
            textBox2.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(400, 9);
            label2.Name = "label2";
            label2.Size = new Size(105, 22);
            label2.TabIndex = 8;
            label2.Text = "Justificativa: ";
            // 
            // TxtBoxJustificativa
            // 
            TxtBoxJustificativa.Location = new Point(511, 9);
            TxtBoxJustificativa.Name = "TxtBoxJustificativa";
            TxtBoxJustificativa.Size = new Size(224, 27);
            TxtBoxJustificativa.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(193, 22);
            label1.TabIndex = 10;
            label1.Text = "Digite a Placa do Veículo:";
            // 
            // FetchAPI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1902, 1033);
            Controls.Add(label1);
            Controls.Add(TxtBoxJustificativa);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(CloseBtn);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "FetchAPI";
            ShowIcon = false;
            Text = "Operação Manual";
            WindowState = FormWindowState.Maximized;
            Load += FetchAPI_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button CloseBtn;
        public TextBox textBox1;
        public PictureBox pictureBox1;
        private Button button2;
        public TextBox textBox2;
        private Label label2;
        private TextBox TxtBoxJustificativa;
        private Label label1;
    }
}