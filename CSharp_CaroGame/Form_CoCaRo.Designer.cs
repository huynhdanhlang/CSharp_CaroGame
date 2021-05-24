
namespace CSharp_CaroGame
{
    partial class Form_CoCaRo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CoCaRo));
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.panel_banco = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Computer = new System.Windows.Forms.Button();
            this.btn_Frient = new System.Windows.Forms.Button();
            this.btn_LAN = new System.Windows.Forms.Button();
            this.btn_Replay = new System.Windows.Forms.Button();
            this.btn_History = new System.Windows.Forms.Button();
            this.pgb_Time = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Undo = new System.Windows.Forms.Button();
            this.btn_Redo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_username.Location = new System.Drawing.Point(109, 229);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(223, 32);
            this.textBox_username.TabIndex = 2;
            // 
            // label_username
            // 
            this.label_username.Location = new System.Drawing.Point(21, 239);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(82, 23);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Username :";
            // 
            // panel_banco
            // 
            this.panel_banco.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel_banco.Location = new System.Drawing.Point(363, 28);
            this.panel_banco.Name = "panel_banco";
            this.panel_banco.Size = new System.Drawing.Size(668, 617);
            this.panel_banco.TabIndex = 9;
            this.panel_banco.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw_Panel_Paint);
            this.panel_banco.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_banco_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSharp_CaroGame.Properties.Resources.Caro;
            this.pictureBox1.Location = new System.Drawing.Point(24, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Time remaining";
            this.label1.Visible = false;
            // 
            // btn_Computer
            // 
            this.btn_Computer.Location = new System.Drawing.Point(24, 574);
            this.btn_Computer.Name = "btn_Computer";
            this.btn_Computer.Size = new System.Drawing.Size(172, 33);
            this.btn_Computer.TabIndex = 11;
            this.btn_Computer.Text = "Play with computer";
            this.btn_Computer.UseVisualStyleBackColor = true;
            this.btn_Computer.Click += new System.EventHandler(this.btn_Computer_Click);
            // 
            // btn_Frient
            // 
            this.btn_Frient.Location = new System.Drawing.Point(202, 574);
            this.btn_Frient.Name = "btn_Frient";
            this.btn_Frient.Size = new System.Drawing.Size(130, 33);
            this.btn_Frient.TabIndex = 12;
            this.btn_Frient.Text = "Play with frient";
            this.btn_Frient.UseVisualStyleBackColor = true;
            this.btn_Frient.Click += new System.EventHandler(this.btn_Frient_Click);
            // 
            // btn_LAN
            // 
            this.btn_LAN.Location = new System.Drawing.Point(24, 613);
            this.btn_LAN.Name = "btn_LAN";
            this.btn_LAN.Size = new System.Drawing.Size(227, 33);
            this.btn_LAN.TabIndex = 13;
            this.btn_LAN.Text = "Play with other people in LAN";
            this.btn_LAN.UseVisualStyleBackColor = true;
            this.btn_LAN.Click += new System.EventHandler(this.btn_LAN_Click);
            // 
            // btn_Replay
            // 
            this.btn_Replay.Enabled = false;
            this.btn_Replay.ForeColor = System.Drawing.Color.MediumBlue;
            this.btn_Replay.Location = new System.Drawing.Point(257, 613);
            this.btn_Replay.Name = "btn_Replay";
            this.btn_Replay.Size = new System.Drawing.Size(75, 33);
            this.btn_Replay.TabIndex = 14;
            this.btn_Replay.Text = "Replay";
            this.btn_Replay.UseVisualStyleBackColor = true;
            this.btn_Replay.Click += new System.EventHandler(this.btn_Replay_Click);
            // 
            // btn_History
            // 
            this.btn_History.Location = new System.Drawing.Point(257, 267);
            this.btn_History.Name = "btn_History";
            this.btn_History.Size = new System.Drawing.Size(75, 30);
            this.btn_History.TabIndex = 15;
            this.btn_History.Text = "History";
            this.btn_History.UseVisualStyleBackColor = true;
            this.btn_History.Click += new System.EventHandler(this.btn_History_Click);
            // 
            // pgb_Time
            // 
            this.pgb_Time.Location = new System.Drawing.Point(24, 361);
            this.pgb_Time.Name = "pgb_Time";
            this.pgb_Time.Size = new System.Drawing.Size(308, 23);
            this.pgb_Time.TabIndex = 16;
            this.pgb_Time.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(24, 420);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 128);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rule";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox1.Location = new System.Drawing.Point(6, 21);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(296, 99);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Be the first player to get 5 points in a row.\r\nDo not block 2 ends.\r\nIf the board" +
    " is full, it\'s a draw.";
            // 
            // btn_Undo
            // 
            this.btn_Undo.Location = new System.Drawing.Point(176, 327);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(75, 28);
            this.btn_Undo.TabIndex = 18;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.UseVisualStyleBackColor = true;
            this.btn_Undo.Visible = false;
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // btn_Redo
            // 
            this.btn_Redo.Location = new System.Drawing.Point(257, 327);
            this.btn_Redo.Name = "btn_Redo";
            this.btn_Redo.Size = new System.Drawing.Size(75, 28);
            this.btn_Redo.TabIndex = 19;
            this.btn_Redo.Text = "Redo";
            this.btn_Redo.UseVisualStyleBackColor = true;
            this.btn_Redo.Visible = false;
            this.btn_Redo.Click += new System.EventHandler(this.btn_Redo_Click);
            // 
            // Form_CoCaRo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 674);
            this.Controls.Add(this.btn_Redo);
            this.Controls.Add(this.btn_Undo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pgb_Time);
            this.Controls.Add(this.btn_History);
            this.Controls.Add(this.btn_Replay);
            this.Controls.Add(this.btn_LAN);
            this.Controls.Add(this.btn_Frient);
            this.Controls.Add(this.btn_Computer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_banco);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_CoCaRo";
            this.Text = "Caro Game";
            this.Load += new System.EventHandler(this.Form_CoCaRo_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw_Panel_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.Panel panel_banco;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Computer;
        private System.Windows.Forms.Button btn_Frient;
        private System.Windows.Forms.Button btn_LAN;
        private System.Windows.Forms.Button btn_Replay;
        private System.Windows.Forms.Button btn_History;
        private System.Windows.Forms.ProgressBar pgb_Time;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Undo;
        private System.Windows.Forms.Button btn_Redo;
    }
}

