namespace RCTV
{
    partial class Login
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.id_text = new System.Windows.Forms.TextBox();
            this.password_text = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.loginPic = new System.Windows.Forms.PictureBox();
            this.joinPic = new System.Windows.Forms.PictureBox();
            this.xxPic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loginPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.joinPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xxPic)).BeginInit();
            this.SuspendLayout();
            // 
            // id_text
            // 
            this.id_text.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.id_text.Location = new System.Drawing.Point(113, 31);
            this.id_text.MaxLength = 20;
            this.id_text.Name = "id_text";
            this.id_text.Size = new System.Drawing.Size(171, 29);
            this.id_text.TabIndex = 1;
            this.id_text.Text = "suwon";
            this.id_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.id_text_KeyDown);
            // 
            // password_text
            // 
            this.password_text.Font = new System.Drawing.Font("휴먼엑스포", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.password_text.Location = new System.Drawing.Point(113, 67);
            this.password_text.MaxLength = 20;
            this.password_text.Name = "password_text";
            this.password_text.PasswordChar = '*';
            this.password_text.Size = new System.Drawing.Size(171, 29);
            this.password_text.TabIndex = 2;
            this.password_text.Text = "sss";
            this.password_text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_text_KeyDown);
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.BackColor = System.Drawing.SystemColors.ControlText;
            this.id.Font = new System.Drawing.Font("휴먼굵은샘체", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.id.ForeColor = System.Drawing.Color.White;
            this.id.Location = new System.Drawing.Point(21, 33);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(83, 27);
            this.id.TabIndex = 6;
            this.id.Text = "I    D";
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.SystemColors.ControlText;
            this.password.Font = new System.Drawing.Font("휴먼굵은샘체", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.password.ForeColor = System.Drawing.Color.White;
            this.password.Location = new System.Drawing.Point(21, 69);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(83, 27);
            this.password.TabIndex = 7;
            this.password.Text = "비밀번호";
            // 
            // loginPic
            // 
            this.loginPic.Image = ((System.Drawing.Image)(resources.GetObject("loginPic.Image")));
            this.loginPic.Location = new System.Drawing.Point(290, 30);
            this.loginPic.Name = "loginPic";
            this.loginPic.Size = new System.Drawing.Size(71, 66);
            this.loginPic.TabIndex = 8;
            this.loginPic.TabStop = false;
            this.loginPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.loginPic_MouseClick);
            this.loginPic.MouseEnter += new System.EventHandler(this.loginPic_MouseEnter);
            this.loginPic.MouseLeave += new System.EventHandler(this.loginPic_MouseLeave);
            // 
            // joinPic
            // 
            this.joinPic.Image = ((System.Drawing.Image)(resources.GetObject("joinPic.Image")));
            this.joinPic.Location = new System.Drawing.Point(367, 30);
            this.joinPic.Name = "joinPic";
            this.joinPic.Size = new System.Drawing.Size(103, 66);
            this.joinPic.TabIndex = 9;
            this.joinPic.TabStop = false;
            this.joinPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.joinPic_MouseClick);
            this.joinPic.MouseEnter += new System.EventHandler(this.joinPic_MouseEnter);
            this.joinPic.MouseLeave += new System.EventHandler(this.joinPic_MouseLeave);
            // 
            // xxPic
            // 
            this.xxPic.Image = ((System.Drawing.Image)(resources.GetObject("xxPic.Image")));
            this.xxPic.Location = new System.Drawing.Point(499, -5);
            this.xxPic.Name = "xxPic";
            this.xxPic.Size = new System.Drawing.Size(34, 41);
            this.xxPic.TabIndex = 10;
            this.xxPic.TabStop = false;
            this.xxPic.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.xxPic.MouseEnter += new System.EventHandler(this.xxPic_MouseEnter);
            this.xxPic.MouseLeave += new System.EventHandler(this.xxPic_MouseLeave);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(532, 136);
            this.Controls.Add(this.xxPic);
            this.Controls.Add(this.joinPic);
            this.Controls.Add(this.loginPic);
            this.Controls.Add(this.password);
            this.Controls.Add(this.id);
            this.Controls.Add(this.password_text);
            this.Controls.Add(this.id_text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RCTV - 로그인";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.loginPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.joinPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xxPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox id_text;
        private System.Windows.Forms.TextBox password_text;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.PictureBox loginPic;
        private System.Windows.Forms.PictureBox joinPic;
        private System.Windows.Forms.PictureBox xxPic;
    }
}

