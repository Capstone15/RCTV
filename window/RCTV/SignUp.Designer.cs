namespace RCTV
{
    partial class SignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignUp));
            this.pw1 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.pw2 = new System.Windows.Forms.Label();
            this.date_text = new System.Windows.Forms.DateTimePicker();
            this.id_text = new System.Windows.Forms.TextBox();
            this.pw1_text = new System.Windows.Forms.TextBox();
            this.pw2_text = new System.Windows.Forms.TextBox();
            this.name_text = new System.Windows.Forms.TextBox();
            this.serialNo = new System.Windows.Forms.Label();
            this.serialNo_text = new System.Windows.Forms.TextBox();
            this.pwcorrect = new System.Windows.Forms.Label();
            this.repeatPic = new System.Windows.Forms.PictureBox();
            this.serialPic = new System.Windows.Forms.PictureBox();
            this.signupPic = new System.Windows.Forms.PictureBox();
            this.xPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.repeatPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serialPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.signupPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pw1
            // 
            this.pw1.BackColor = System.Drawing.SystemColors.ControlText;
            this.pw1.Font = new System.Drawing.Font("휴먼굵은샘체", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pw1.ForeColor = System.Drawing.Color.White;
            this.pw1.Location = new System.Drawing.Point(8, 45);
            this.pw1.Name = "pw1";
            this.pw1.Size = new System.Drawing.Size(130, 27);
            this.pw1.TabIndex = 9;
            this.pw1.Text = "비밀번호";
            this.pw1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // id
            // 
            this.id.BackColor = System.Drawing.SystemColors.ControlText;
            this.id.Font = new System.Drawing.Font("휴먼굵은샘체", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.id.ForeColor = System.Drawing.Color.White;
            this.id.Location = new System.Drawing.Point(8, 12);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(130, 27);
            this.id.TabIndex = 10;
            this.id.Text = "I    D";
            this.id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // date
            // 
            this.date.BackColor = System.Drawing.SystemColors.ControlText;
            this.date.Font = new System.Drawing.Font("휴먼굵은샘체", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.date.ForeColor = System.Drawing.Color.White;
            this.date.Location = new System.Drawing.Point(8, 144);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(130, 27);
            this.date.TabIndex = 11;
            this.date.Text = "생년월일";
            this.date.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.SystemColors.ControlText;
            this.name.Font = new System.Drawing.Font("휴먼굵은샘체", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.name.ForeColor = System.Drawing.Color.White;
            this.name.Location = new System.Drawing.Point(8, 111);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(130, 27);
            this.name.TabIndex = 12;
            this.name.Text = "이   름";
            this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pw2
            // 
            this.pw2.BackColor = System.Drawing.SystemColors.ControlText;
            this.pw2.Font = new System.Drawing.Font("휴먼굵은샘체", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pw2.ForeColor = System.Drawing.Color.White;
            this.pw2.Location = new System.Drawing.Point(8, 78);
            this.pw2.Name = "pw2";
            this.pw2.Size = new System.Drawing.Size(130, 27);
            this.pw2.TabIndex = 13;
            this.pw2.Text = "비밀번호확인";
            this.pw2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // date_text
            // 
            this.date_text.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.date_text.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date_text.Location = new System.Drawing.Point(144, 144);
            this.date_text.MaxDate = new System.DateTime(2014, 5, 19, 0, 0, 0, 0);
            this.date_text.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.date_text.Name = "date_text";
            this.date_text.Size = new System.Drawing.Size(175, 21);
            this.date_text.TabIndex = 6;
            this.date_text.Value = new System.DateTime(2014, 5, 19, 0, 0, 0, 0);
            // 
            // id_text
            // 
            this.id_text.Location = new System.Drawing.Point(144, 12);
            this.id_text.Name = "id_text";
            this.id_text.Size = new System.Drawing.Size(175, 21);
            this.id_text.TabIndex = 1;
            this.id_text.TextChanged += new System.EventHandler(this.id_text_TextChanged);
            // 
            // pw1_text
            // 
            this.pw1_text.Location = new System.Drawing.Point(144, 45);
            this.pw1_text.Name = "pw1_text";
            this.pw1_text.PasswordChar = '*';
            this.pw1_text.Size = new System.Drawing.Size(175, 21);
            this.pw1_text.TabIndex = 3;
            this.pw1_text.TextChanged += new System.EventHandler(this.pw1_text_TextChanged);
            // 
            // pw2_text
            // 
            this.pw2_text.Location = new System.Drawing.Point(144, 78);
            this.pw2_text.Name = "pw2_text";
            this.pw2_text.PasswordChar = '*';
            this.pw2_text.Size = new System.Drawing.Size(175, 21);
            this.pw2_text.TabIndex = 4;
            this.pw2_text.TextChanged += new System.EventHandler(this.pw2_text_TextChanged);
            // 
            // name_text
            // 
            this.name_text.Location = new System.Drawing.Point(144, 111);
            this.name_text.Name = "name_text";
            this.name_text.Size = new System.Drawing.Size(175, 21);
            this.name_text.TabIndex = 5;
            // 
            // serialNo
            // 
            this.serialNo.BackColor = System.Drawing.SystemColors.ControlText;
            this.serialNo.Font = new System.Drawing.Font("휴먼굵은샘체", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.serialNo.ForeColor = System.Drawing.Color.White;
            this.serialNo.Location = new System.Drawing.Point(8, 177);
            this.serialNo.Name = "serialNo";
            this.serialNo.Size = new System.Drawing.Size(130, 27);
            this.serialNo.TabIndex = 16;
            this.serialNo.Text = "제품번호";
            this.serialNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // serialNo_text
            // 
            this.serialNo_text.Location = new System.Drawing.Point(144, 177);
            this.serialNo_text.Name = "serialNo_text";
            this.serialNo_text.Size = new System.Drawing.Size(175, 21);
            this.serialNo_text.TabIndex = 7;
            this.serialNo_text.TextChanged += new System.EventHandler(this.serialNo_text_TextChanged);
            // 
            // pwcorrect
            // 
            this.pwcorrect.AutoSize = true;
            this.pwcorrect.Font = new System.Drawing.Font("휴먼엑스포", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.pwcorrect.ForeColor = System.Drawing.Color.LimeGreen;
            this.pwcorrect.Location = new System.Drawing.Point(325, 81);
            this.pwcorrect.Name = "pwcorrect";
            this.pwcorrect.Size = new System.Drawing.Size(0, 13);
            this.pwcorrect.TabIndex = 19;
            // 
            // repeatPic
            // 
            this.repeatPic.Image = ((System.Drawing.Image)(resources.GetObject("repeatPic.Image")));
            this.repeatPic.Location = new System.Drawing.Point(325, 12);
            this.repeatPic.Name = "repeatPic";
            this.repeatPic.Size = new System.Drawing.Size(46, 21);
            this.repeatPic.TabIndex = 20;
            this.repeatPic.TabStop = false;
            this.repeatPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.repeatPic_MouseClick);
            this.repeatPic.MouseEnter += new System.EventHandler(this.repeatPic_MouseEnter);
            this.repeatPic.MouseLeave += new System.EventHandler(this.repeatPic_MouseLeave);
            // 
            // serialPic
            // 
            this.serialPic.Image = ((System.Drawing.Image)(resources.GetObject("serialPic.Image")));
            this.serialPic.Location = new System.Drawing.Point(325, 177);
            this.serialPic.Name = "serialPic";
            this.serialPic.Size = new System.Drawing.Size(46, 21);
            this.serialPic.TabIndex = 21;
            this.serialPic.TabStop = false;
            this.serialPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.serialPic_MouseClick);
            this.serialPic.MouseEnter += new System.EventHandler(this.serialPic_MouseEnter);
            this.serialPic.MouseLeave += new System.EventHandler(this.serialPic_MouseLeave);
            // 
            // signupPic
            // 
            this.signupPic.Image = ((System.Drawing.Image)(resources.GetObject("signupPic.Image")));
            this.signupPic.Location = new System.Drawing.Point(195, 204);
            this.signupPic.Name = "signupPic";
            this.signupPic.Size = new System.Drawing.Size(75, 32);
            this.signupPic.TabIndex = 22;
            this.signupPic.TabStop = false;
            this.signupPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.signupPic_MouseClick);
            this.signupPic.MouseEnter += new System.EventHandler(this.signupPic_MouseEnter);
            this.signupPic.MouseLeave += new System.EventHandler(this.signupPic_MouseLeave);
            // 
            // xPic
            // 
            this.xPic.BackColor = System.Drawing.Color.Black;
            this.xPic.Image = ((System.Drawing.Image)(resources.GetObject("xPic.Image")));
            this.xPic.Location = new System.Drawing.Point(395, -6);
            this.xPic.Name = "xPic";
            this.xPic.Size = new System.Drawing.Size(35, 39);
            this.xPic.TabIndex = 23;
            this.xPic.TabStop = false;
            this.xPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.xPic_MouseClick);
            this.xPic.MouseEnter += new System.EventHandler(this.xPic_MouseEnter);
            this.xPic.MouseLeave += new System.EventHandler(this.xPic_MouseLeave);
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(428, 248);
            this.ControlBox = false;
            this.Controls.Add(this.xPic);
            this.Controls.Add(this.signupPic);
            this.Controls.Add(this.serialPic);
            this.Controls.Add(this.repeatPic);
            this.Controls.Add(this.pwcorrect);
            this.Controls.Add(this.serialNo_text);
            this.Controls.Add(this.serialNo);
            this.Controls.Add(this.name_text);
            this.Controls.Add(this.pw2_text);
            this.Controls.Add(this.pw1_text);
            this.Controls.Add(this.id_text);
            this.Controls.Add(this.date_text);
            this.Controls.Add(this.pw2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.date);
            this.Controls.Add(this.id);
            this.Controls.Add(this.pw1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RCTV - 회원가입";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SignUp_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SignUp_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.repeatPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serialPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.signupPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pw1;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label pw2;
        private System.Windows.Forms.DateTimePicker date_text;
        private System.Windows.Forms.TextBox id_text;
        private System.Windows.Forms.TextBox pw1_text;
        private System.Windows.Forms.TextBox pw2_text;
        private System.Windows.Forms.TextBox name_text;
        private System.Windows.Forms.Label serialNo;
        private System.Windows.Forms.TextBox serialNo_text;
        private System.Windows.Forms.Label pwcorrect;
        private System.Windows.Forms.PictureBox repeatPic;
        private System.Windows.Forms.PictureBox serialPic;
        private System.Windows.Forms.PictureBox signupPic;
        private System.Windows.Forms.PictureBox xPic;

    }
}