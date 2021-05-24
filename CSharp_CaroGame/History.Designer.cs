
namespace CSharp_CaroGame
{
    partial class History
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
            this.panel_history = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_win = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_lose = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // panel_history
            // 
            this.panel_history.AutoScroll = true;
            this.panel_history.Location = new System.Drawing.Point(1, 53);
            this.panel_history.Name = "panel_history";
            this.panel_history.Size = new System.Drawing.Size(799, 385);
            this.panel_history.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Số trận thắng";
            // 
            // textBox_win
            // 
            this.textBox_win.Location = new System.Drawing.Point(12, 29);
            this.textBox_win.Name = "textBox_win";
            this.textBox_win.Size = new System.Drawing.Size(100, 22);
            this.textBox_win.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số trận thua";
            // 
            // textBox_lose
            // 
            this.textBox_lose.Location = new System.Drawing.Point(132, 29);
            this.textBox_lose.Name = "textBox_lose";
            this.textBox_lose.Size = new System.Drawing.Size(100, 22);
            this.textBox_lose.TabIndex = 4;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_lose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_win);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_history);
            this.Name = "History";
            this.Text = "History";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel_history;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBox_win;
        public System.Windows.Forms.TextBox textBox_lose;
    }
}