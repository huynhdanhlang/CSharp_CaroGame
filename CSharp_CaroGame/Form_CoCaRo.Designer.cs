
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CoCaRo));
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.panel_banco = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Computer = new System.Windows.Forms.Button();
            this.btn_Friend = new System.Windows.Forms.Button();
            this.btn_LAN = new System.Windows.Forms.Button();
            this.btn_Replay = new System.Windows.Forms.Button();
            this.btn_History = new System.Windows.Forms.Button();
            this.pgb_Time = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Undo = new System.Windows.Forms.Button();
            this.btn_Redo = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitLANToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_username
            // 
            this.textBox_username.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox_username.Location = new System.Drawing.Point(82, 186);
            this.textBox_username.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(168, 30);
            this.textBox_username.TabIndex = 2;
            // 
            // label_username
            // 
            this.label_username.Location = new System.Drawing.Point(16, 194);
            this.label_username.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(62, 19);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "Username :";
            // 
            // panel_banco
            // 
            this.panel_banco.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel_banco.Location = new System.Drawing.Point(272, 23);
            this.panel_banco.Margin = new System.Windows.Forms.Padding(2);
            this.panel_banco.Name = "panel_banco";
            this.panel_banco.Size = new System.Drawing.Size(501, 501);
            this.panel_banco.TabIndex = 9;
            this.panel_banco.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw_Panel_Paint);
            this.panel_banco.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel_banco_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSharp_CaroGame.Properties.Resources.Caro;
            this.pictureBox1.Location = new System.Drawing.Point(18, 23);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 275);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Time remaining";
            this.label1.Visible = false;
            // 
            // btn_Computer
            // 
            this.btn_Computer.Location = new System.Drawing.Point(19, 443);
            this.btn_Computer.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Computer.Name = "btn_Computer";
            this.btn_Computer.Size = new System.Drawing.Size(116, 27);
            this.btn_Computer.TabIndex = 11;
            this.btn_Computer.Text = "Play with computer";
            this.btn_Computer.UseVisualStyleBackColor = true;
            this.btn_Computer.Click += new System.EventHandler(this.btn_Computer_Click);
            // 
            // btn_Friend
            // 
            this.btn_Friend.Location = new System.Drawing.Point(19, 474);
            this.btn_Friend.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Friend.Name = "btn_Friend";
            this.btn_Friend.Size = new System.Drawing.Size(116, 27);
            this.btn_Friend.TabIndex = 12;
            this.btn_Friend.Text = "Play with friend";
            this.btn_Friend.UseVisualStyleBackColor = true;
            this.btn_Friend.Click += new System.EventHandler(this.btn_Frient_Click);
            // 
            // btn_LAN
            // 
            this.btn_LAN.Location = new System.Drawing.Point(19, 505);
            this.btn_LAN.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LAN.Name = "btn_LAN";
            this.btn_LAN.Size = new System.Drawing.Size(75, 32);
            this.btn_LAN.TabIndex = 13;
            this.btn_LAN.Text = "Play in LAN";
            this.btn_LAN.UseVisualStyleBackColor = true;
            this.btn_LAN.Click += new System.EventHandler(this.btn_LAN_Click);
            // 
            // btn_Replay
            // 
            this.btn_Replay.ForeColor = System.Drawing.Color.MediumBlue;
            this.btn_Replay.Location = new System.Drawing.Point(139, 443);
            this.btn_Replay.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Replay.Name = "btn_Replay";
            this.btn_Replay.Size = new System.Drawing.Size(111, 58);
            this.btn_Replay.TabIndex = 14;
            this.btn_Replay.Text = "New Game";
            this.btn_Replay.UseVisualStyleBackColor = true;
            this.btn_Replay.Click += new System.EventHandler(this.btn_Replay_Click);
            // 
            // btn_History
            // 
            this.btn_History.Location = new System.Drawing.Point(193, 217);
            this.btn_History.Margin = new System.Windows.Forms.Padding(2);
            this.btn_History.Name = "btn_History";
            this.btn_History.Size = new System.Drawing.Size(56, 24);
            this.btn_History.TabIndex = 15;
            this.btn_History.Text = "History";
            this.btn_History.UseVisualStyleBackColor = true;
            this.btn_History.Click += new System.EventHandler(this.btn_History_Click);
            // 
            // pgb_Time
            // 
            this.pgb_Time.Location = new System.Drawing.Point(18, 293);
            this.pgb_Time.Margin = new System.Windows.Forms.Padding(2);
            this.pgb_Time.Name = "pgb_Time";
            this.pgb_Time.Size = new System.Drawing.Size(231, 19);
            this.pgb_Time.TabIndex = 16;
            this.pgb_Time.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(18, 333);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(231, 96);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rule";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBox1.Location = new System.Drawing.Point(4, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 92);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Be the first player to get 5 points in a row.\r\nDo not block 2 ends.\r\nIf the board" +
    " is full, it\'s a draw.";
            // 
            // btn_Undo
            // 
            this.btn_Undo.Location = new System.Drawing.Point(132, 266);
            this.btn_Undo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Undo.Name = "btn_Undo";
            this.btn_Undo.Size = new System.Drawing.Size(56, 23);
            this.btn_Undo.TabIndex = 18;
            this.btn_Undo.Text = "Undo";
            this.btn_Undo.UseVisualStyleBackColor = true;
            this.btn_Undo.Visible = false;
            this.btn_Undo.Click += new System.EventHandler(this.btn_Undo_Click);
            // 
            // btn_Redo
            // 
            this.btn_Redo.Location = new System.Drawing.Point(193, 266);
            this.btn_Redo.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Redo.Name = "btn_Redo";
            this.btn_Redo.Size = new System.Drawing.Size(56, 23);
            this.btn_Redo.TabIndex = 19;
            this.btn_Redo.Text = "Redo";
            this.btn_Redo.UseVisualStyleBackColor = true;
            this.btn_Redo.Visible = false;
            this.btn_Redo.Click += new System.EventHandler(this.btn_Redo_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(99, 506);
            this.textBox_IP.Multiline = true;
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(151, 30);
            this.textBox_IP.TabIndex = 20;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(796, 27);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitLANToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(50, 23);
            this.newToolStripMenuItem.Text = "New";
            // 
            // exitLANToolStripMenuItem
            // 
            this.exitLANToolStripMenuItem.Name = "exitLANToolStripMenuItem";
            this.exitLANToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.exitLANToolStripMenuItem.Text = "Exit LAN";
            // 
            // Form_CoCaRo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 548);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.btn_Redo);
            this.Controls.Add(this.btn_Undo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pgb_Time);
            this.Controls.Add(this.btn_History);
            this.Controls.Add(this.btn_Replay);
            this.Controls.Add(this.btn_LAN);
            this.Controls.Add(this.btn_Friend);
            this.Controls.Add(this.btn_Computer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_banco);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_CoCaRo";
            this.Text = "Caro Game";
            this.Load += new System.EventHandler(this.Form_CoCaRo_Load);
            this.Shown += new System.EventHandler(this.Form_CoCaRo_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw_Panel_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Button btn_Friend;
        private System.Windows.Forms.Button btn_LAN;
        private System.Windows.Forms.Button btn_Replay;
        private System.Windows.Forms.Button btn_History;
        private System.Windows.Forms.ProgressBar pgb_Time;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Undo;
        private System.Windows.Forms.Button btn_Redo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitLANToolStripMenuItem;
    }
}

