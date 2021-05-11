
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vánMớiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đánhVơiNgườiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đánhVớiMáyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chơiTrongLANIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luậtChơiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label_username = new System.Windows.Forms.Label();
            this.textBox_host = new System.Windows.Forms.TextBox();
            this.label_host = new System.Windows.Forms.Label();
            this.button_connect = new System.Windows.Forms.Button();
            this.textBox_port = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.panel_banco = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.editToolStripMenuItem,
            this.thôngTinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1056, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vánMớiToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.optionToolStripMenuItem.Text = "Option";
            // 
            // vánMớiToolStripMenuItem
            // 
            this.vánMớiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đánhVơiNgườiToolStripMenuItem,
            this.đánhVớiMáyToolStripMenuItem,
            this.chơiTrongLANIPToolStripMenuItem});
            this.vánMớiToolStripMenuItem.Name = "vánMớiToolStripMenuItem";
            this.vánMớiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.vánMớiToolStripMenuItem.Text = "New game";
            // 
            // đánhVơiNgườiToolStripMenuItem
            // 
            this.đánhVơiNgườiToolStripMenuItem.Name = "đánhVơiNgườiToolStripMenuItem";
            this.đánhVơiNgườiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đánhVơiNgườiToolStripMenuItem.Text = "PvP";
            this.đánhVơiNgườiToolStripMenuItem.Click += new System.EventHandler(this.đánhVơiNgườiToolStripMenuItem_Click);
            // 
            // đánhVớiMáyToolStripMenuItem
            // 
            this.đánhVớiMáyToolStripMenuItem.Name = "đánhVớiMáyToolStripMenuItem";
            this.đánhVớiMáyToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đánhVớiMáyToolStripMenuItem.Text = "Play with computer";
            this.đánhVớiMáyToolStripMenuItem.Click += new System.EventHandler(this.đánhVớiMáyToolStripMenuItem_Click);
            // 
            // chơiTrongLANIPToolStripMenuItem
            // 
            this.chơiTrongLANIPToolStripMenuItem.Name = "chơiTrongLANIPToolStripMenuItem";
            this.chơiTrongLANIPToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.chơiTrongLANIPToolStripMenuItem.Text = "Chơi trong LAN IP";
            this.chơiTrongLANIPToolStripMenuItem.Click += new System.EventHandler(this.chơiTrongLANIPToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.thoátToolStripMenuItem.Text = "Exit";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.luậtChơiToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.thôngTinToolStripMenuItem.Text = "Info";
            // 
            // luậtChơiToolStripMenuItem
            // 
            this.luậtChơiToolStripMenuItem.Name = "luậtChơiToolStripMenuItem";
            this.luậtChơiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.luậtChơiToolStripMenuItem.Text = "How to play?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CSharp_CaroGame.Properties.Resources.Caro;
            this.pictureBox1.Location = new System.Drawing.Point(23, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 342);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(23, 443);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 22);
            this.textBox1.TabIndex = 2;
            // 
            // label_username
            // 
            this.label_username.Location = new System.Drawing.Point(20, 417);
            this.label_username.Name = "label_username";
            this.label_username.Size = new System.Drawing.Size(100, 23);
            this.label_username.TabIndex = 3;
            this.label_username.Text = "username :";
            // 
            // textBox_host
            // 
            this.textBox_host.Enabled = false;
            this.textBox_host.Location = new System.Drawing.Point(23, 505);
            this.textBox_host.Name = "textBox_host";
            this.textBox_host.Size = new System.Drawing.Size(278, 22);
            this.textBox_host.TabIndex = 4;
            // 
            // label_host
            // 
            this.label_host.Location = new System.Drawing.Point(20, 479);
            this.label_host.Name = "label_host";
            this.label_host.Size = new System.Drawing.Size(100, 23);
            this.label_host.TabIndex = 5;
            this.label_host.Text = "LAN IP:";
            // 
            // button_connect
            // 
            this.button_connect.Enabled = false;
            this.button_connect.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_connect.Location = new System.Drawing.Point(23, 616);
            this.button_connect.Name = "button_connect";
            this.button_connect.Size = new System.Drawing.Size(198, 49);
            this.button_connect.TabIndex = 6;
            this.button_connect.Text = "Conncet";
            this.button_connect.UseVisualStyleBackColor = true;
            // 
            // textBox_port
            // 
            this.textBox_port.Enabled = false;
            this.textBox_port.Location = new System.Drawing.Point(23, 568);
            this.textBox_port.Name = "textBox_port";
            this.textBox_port.Size = new System.Drawing.Size(144, 22);
            this.textBox_port.TabIndex = 7;
            // 
            // label_port
            // 
            this.label_port.Location = new System.Drawing.Point(20, 542);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(100, 23);
            this.label_port.TabIndex = 8;
            this.label_port.Text = "Port :";
            // 
            // panel_banco
            // 
            this.panel_banco.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel_banco.Location = new System.Drawing.Point(369, 44);
            this.panel_banco.Name = "panel_banco";
            this.panel_banco.Size = new System.Drawing.Size(675, 621);
            this.panel_banco.TabIndex = 9;
            // 
            // Form_CoCaRo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 677);
            this.Controls.Add(this.panel_banco);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.textBox_port);
            this.Controls.Add(this.button_connect);
            this.Controls.Add(this.label_host);
            this.Controls.Add(this.textBox_host);
            this.Controls.Add(this.label_username);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_CoCaRo";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_CoCaRo_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Draw_Panel_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem vánMớiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đánhVơiNgườiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đánhVớiMáyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem luậtChơiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_username;
        private System.Windows.Forms.TextBox textBox_host;
        private System.Windows.Forms.Label label_host;
        private System.Windows.Forms.Button button_connect;
        private System.Windows.Forms.TextBox textBox_port;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.ToolStripMenuItem chơiTrongLANIPToolStripMenuItem;
        private System.Windows.Forms.Panel panel_banco;
    }
}

