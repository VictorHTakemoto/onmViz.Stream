namespace GetStream
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cam1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.OpenRecording = new System.Windows.Forms.ToolStripMenuItem();
            this.pararGravaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Cam1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cam1
            // 
            this.Cam1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cam1.Location = new System.Drawing.Point(0, 28);
            this.Cam1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cam1.Name = "Cam1";
            this.Cam1.Size = new System.Drawing.Size(800, 422);
            this.Cam1.TabIndex = 0;
            this.Cam1.TabStop = false;
            this.Cam1.Click += new System.EventHandler(this.Cam1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenRecording,
            this.pararGravaçãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // OpenRecording
            // 
            this.OpenRecording.Name = "OpenRecording";
            this.OpenRecording.Size = new System.Drawing.Size(118, 24);
            this.OpenRecording.Text = "Iniciar Camera";
            this.OpenRecording.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // pararGravaçãoToolStripMenuItem
            // 
            this.pararGravaçãoToolStripMenuItem.Name = "pararGravaçãoToolStripMenuItem";
            this.pararGravaçãoToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.pararGravaçãoToolStripMenuItem.Text = "Parar Camera";
            this.pararGravaçãoToolStripMenuItem.Click += new System.EventHandler(this.pararGravaçãoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Cam1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Cam1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Cam1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenRecording;
        private System.Windows.Forms.ToolStripMenuItem pararGravaçãoToolStripMenuItem;
    }
}

