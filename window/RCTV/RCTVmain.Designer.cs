namespace RCTV
{
    partial class RCTVmain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RCTVmain));
            this.monitor = new System.Windows.Forms.PictureBox();
            this.onOffPic = new System.Windows.Forms.PictureBox();
            this.logoutPic = new System.Windows.Forms.PictureBox();
            this.exitPic = new System.Windows.Forms.PictureBox();
            this.recordPic = new System.Windows.Forms.PictureBox();
            this.takePhotoPic = new System.Windows.Forms.PictureBox();
            this.chatPrinter = new System.Windows.Forms.RichTextBox();
            this.chatText = new System.Windows.Forms.TextBox();
            this.left = new System.Windows.Forms.PictureBox();
            this.right = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.monitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.onOffPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoutPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takePhotoPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right)).BeginInit();
            this.SuspendLayout();
            // 
            // monitor
            // 
            this.monitor.BackColor = System.Drawing.Color.White;
            this.monitor.Location = new System.Drawing.Point(12, 12);
            this.monitor.Name = "monitor";
            this.monitor.Size = new System.Drawing.Size(314, 251);
            this.monitor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.monitor.TabIndex = 0;
            this.monitor.TabStop = false;
            // 
            // onOffPic
            // 
            this.onOffPic.Image = ((System.Drawing.Image)(resources.GetObject("onOffPic.Image")));
            this.onOffPic.Location = new System.Drawing.Point(336, 13);
            this.onOffPic.Name = "onOffPic";
            this.onOffPic.Size = new System.Drawing.Size(116, 53);
            this.onOffPic.TabIndex = 3;
            this.onOffPic.TabStop = false;
            this.onOffPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.onOffPic_MouseClick);
            this.onOffPic.MouseEnter += new System.EventHandler(this.onOffPic_MouseEnter);
            this.onOffPic.MouseLeave += new System.EventHandler(this.onOffPic_MouseLeave);
            // 
            // logoutPic
            // 
            this.logoutPic.Image = ((System.Drawing.Image)(resources.GetObject("logoutPic.Image")));
            this.logoutPic.Location = new System.Drawing.Point(336, 210);
            this.logoutPic.Name = "logoutPic";
            this.logoutPic.Size = new System.Drawing.Size(116, 53);
            this.logoutPic.TabIndex = 5;
            this.logoutPic.TabStop = false;
            this.logoutPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.logoutPic_MouseClick);
            this.logoutPic.MouseEnter += new System.EventHandler(this.logoutPic_MouseEnter);
            this.logoutPic.MouseLeave += new System.EventHandler(this.logoutPic_MouseLeave);
            // 
            // exitPic
            // 
            this.exitPic.Image = ((System.Drawing.Image)(resources.GetObject("exitPic.Image")));
            this.exitPic.Location = new System.Drawing.Point(336, 277);
            this.exitPic.Name = "exitPic";
            this.exitPic.Size = new System.Drawing.Size(116, 53);
            this.exitPic.TabIndex = 6;
            this.exitPic.TabStop = false;
            this.exitPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.exitPic_MouseClick);
            this.exitPic.MouseEnter += new System.EventHandler(this.exitPic_MouseEnter);
            this.exitPic.MouseLeave += new System.EventHandler(this.exitPic_MouseLeave);
            // 
            // recordPic
            // 
            this.recordPic.Image = ((System.Drawing.Image)(resources.GetObject("recordPic.Image")));
            this.recordPic.Location = new System.Drawing.Point(336, 145);
            this.recordPic.Name = "recordPic";
            this.recordPic.Size = new System.Drawing.Size(117, 53);
            this.recordPic.TabIndex = 7;
            this.recordPic.TabStop = false;
            this.recordPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.recordPic_MouseClick);
            this.recordPic.MouseEnter += new System.EventHandler(this.recordPic_MouseEnter);
            this.recordPic.MouseLeave += new System.EventHandler(this.recordPic_MouseLeave);
            // 
            // takePhotoPic
            // 
            this.takePhotoPic.Image = ((System.Drawing.Image)(resources.GetObject("takePhotoPic.Image")));
            this.takePhotoPic.Location = new System.Drawing.Point(336, 79);
            this.takePhotoPic.Name = "takePhotoPic";
            this.takePhotoPic.Size = new System.Drawing.Size(118, 53);
            this.takePhotoPic.TabIndex = 8;
            this.takePhotoPic.TabStop = false;
            this.takePhotoPic.Click += new System.EventHandler(this.takePhotoPic_Click);
            this.takePhotoPic.MouseEnter += new System.EventHandler(this.takePhotoPic_MouseEnter);
            this.takePhotoPic.MouseLeave += new System.EventHandler(this.takePhotoPic_MouseLeave);
            // 
            // chatPrinter
            // 
            this.chatPrinter.Location = new System.Drawing.Point(460, 13);
            this.chatPrinter.Name = "chatPrinter";
            this.chatPrinter.Size = new System.Drawing.Size(219, 290);
            this.chatPrinter.TabIndex = 17;
            this.chatPrinter.Text = "";
            // 
            // chatText
            // 
            this.chatText.Location = new System.Drawing.Point(460, 309);
            this.chatText.Name = "chatText";
            this.chatText.Size = new System.Drawing.Size(219, 21);
            this.chatText.TabIndex = 18;
            this.chatText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.chatText_KeyDown);
            // 
            // left
            // 
            this.left.Enabled = false;
            this.left.Image = ((System.Drawing.Image)(resources.GetObject("left.Image")));
            this.left.Location = new System.Drawing.Point(12, 269);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(154, 62);
            this.left.TabIndex = 19;
            this.left.TabStop = false;
            this.left.Click += new System.EventHandler(this.left_Click);
            this.left.MouseEnter += new System.EventHandler(this.left_MouseEnter);
            this.left.MouseLeave += new System.EventHandler(this.left_MouseLeave);
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.Tomato;
            this.right.Enabled = false;
            this.right.Image = ((System.Drawing.Image)(resources.GetObject("right.Image")));
            this.right.Location = new System.Drawing.Point(172, 268);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(154, 62);
            this.right.TabIndex = 19;
            this.right.TabStop = false;
            this.right.Click += new System.EventHandler(this.right_Click);
            this.right.MouseEnter += new System.EventHandler(this.right_MouseEnter);
            this.right.MouseLeave += new System.EventHandler(this.right_MouseLeave);
            // 
            // RCTVmain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(695, 343);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.chatText);
            this.Controls.Add(this.chatPrinter);
            this.Controls.Add(this.takePhotoPic);
            this.Controls.Add(this.recordPic);
            this.Controls.Add(this.exitPic);
            this.Controls.Add(this.logoutPic);
            this.Controls.Add(this.onOffPic);
            this.Controls.Add(this.monitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RCTVmain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RCTVmain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RCTVmain_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RCTVmain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RCTVmain_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.monitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.onOffPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoutPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recordPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takePhotoPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox monitor;
        private System.Windows.Forms.PictureBox onOffPic;
        private System.Windows.Forms.PictureBox logoutPic;
        private System.Windows.Forms.PictureBox exitPic;
        private System.Windows.Forms.PictureBox recordPic;
        private System.Windows.Forms.PictureBox takePhotoPic;
        private System.Windows.Forms.RichTextBox chatPrinter;
        private System.Windows.Forms.TextBox chatText;
        private System.Windows.Forms.PictureBox left;
        public System.Windows.Forms.PictureBox right;
    }
}