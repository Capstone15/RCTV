using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySQLDriverCS;
using System.Data.SqlClient;


namespace RCTV
{
    public partial class SignUp : Form
    {
        Point moustPoint;
        //string strConn = "Data Source=203.246.112.87;Database=rctv;User ID=root;Password=22179215";
        string strConn = "server = 203.246.112.87,49304; uid = sa; pwd = 22179215; database = rctv;";
        bool idFlag = false;
        bool pwFlag = false;
        bool nameFlag = false;
        bool serialFlag = false;

        public SignUp()
        {
            InitializeComponent();
        }
        private void pw2_text_TextChanged(object sender, EventArgs e)
        {
            if (pw1_text.Text.Length > 0 || pw2_text.Text.Length > 0)
            {
                if (pw1_text.Text.CompareTo(pw2_text.Text) == 0)
                {
                    pwcorrect.ForeColor = Color.LimeGreen;
                    pwcorrect.Text = "일치";
                    pwFlag = true;
                }
                else
                {
                    pwcorrect.ForeColor = Color.Red;
                    pwcorrect.Text = "불일치";
                    pwFlag = false;
                }
            }
            else if(pw1_text.Text.Length < 0 || pw2_text.Text.Length < 0)
            {
                pwcorrect.Text = null;
                pwFlag = false;
            }
        }

        private void pw1_text_TextChanged(object sender, EventArgs e)
        {
            if (pw1_text.Text.Length > 0 || pw2_text.Text.Length > 0)
            {
                if (pw1_text.Text.CompareTo(pw2_text.Text) == 0)
                {
                    pwcorrect.ForeColor = Color.LimeGreen;
                    pwcorrect.Text = "일치";
                    pwFlag = true;
                }
                else
                {
                    pwcorrect.ForeColor = Color.Red;
                    pwcorrect.Text = "불일치";
                    pwFlag = false;
                }
            }
            else if (pw1_text.Text.Length < 0 || pw2_text.Text.Length < 0)
            {
                pwcorrect.Text = null;
                pwFlag = false;
            }
        }

        private void id_text_TextChanged(object sender, EventArgs e)
        {
            idFlag = false;
        }

        private void serialNo_text_TextChanged(object sender, EventArgs e)
        {
            serialFlag = false;
        }

        private void signupPic_MouseClick(object sender, MouseEventArgs e)
        {
            if (name_text.Text.Length > 0)
                nameFlag = true;
            else
                nameFlag = false;

            if (idFlag || pwFlag || nameFlag || serialFlag)
            {
                SqlConnection connect = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand("INSERT INTO customer VALUES(@id,@pwd,@name,@birthdate,@serialNo);", connect);
                try
                {
                    connect.Open();
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                cmd.Parameters.AddWithValue("@id", id_text.Text);
                cmd.Parameters.AddWithValue("@pwd", pw1_text.Text);
                cmd.Parameters.AddWithValue("@name", name_text.Text);
                cmd.Parameters.AddWithValue("@birthdate", date_text.Text);
                cmd.Parameters.AddWithValue("@serialNo", serialNo_text.Text);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Error");
                    connect.Close();
                    return;
                }
                connect.Close();
                MessageBox.Show("가입완료");
                id_text.Text = null;
                pw1_text.Text = null;
                pw2_text.Text = null;
                name_text.Text = null;
                serialNo_text.Text = null;
            }
            else if (!idFlag)
            {
                MessageBox.Show("중복확인을 클릭해주세요.");
            }
            else if (!pwFlag)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
            }
            else if (!serialFlag)
            {
                MessageBox.Show("제품번호확인을 클릭해주세요.");
            }
            else
            {
                MessageBox.Show("모든 항목을 입력하세요.");
            }
        }

        private void serialPic_MouseClick(object sender, MouseEventArgs e)
        {
            if (serialNo_text.Text.Length > 0)
            {
                string strQuery = "SELECT COUNT(*) FROM raspberrypi WHERE RaspNumber=\'" + serialNo_text.Text + "\';";
                SqlConnection connect = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand(strQuery, connect);
                try
                {
                    connect.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("사용 가능한 제품번호입니다.");
                        idFlag = true;
                    }
                    else
                    {
                        MessageBox.Show("존재하지 않는 제품번호입니다.");
                        idFlag = false;
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                    connect.Close();
                    return;
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("제품번호를 입력하세요.");
            }
        }

        private void repeatPic_MouseClick(object sender, MouseEventArgs e)
        {
            if (id_text.Text.Length > 0)
            {
                SqlConnection connect = new SqlConnection(strConn);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connect;
                cmd.CommandTimeout = 600;
                cmd.CommandText = "SELECT COUNT(*) FROM rctv.dbo.customer WHERE ID=\'" + id_text.Text + "\';";
                try
                {
                    connect.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("이미 존재하는 아이디입니다.");
                        idFlag = false;
                    }
                    else
                    {
                        MessageBox.Show("사용 가능한 아이디입니다.");
                        idFlag = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                    connect.Close();
                    return;
                }
                connect.Close();
            }
            else
            {
                MessageBox.Show("아이디를 입력하세요.");
            }
        }

        private void xPic_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void xPic_MouseEnter(object sender, EventArgs e)
        {
            xPic.Image = System.Drawing.Image.FromFile("button\\x2.png");
        }

        private void xPic_MouseLeave(object sender, EventArgs e)
        {
            xPic.Image = System.Drawing.Image.FromFile("button\\x.png");
        }

        private void repeatPic_MouseEnter(object sender, EventArgs e)
        {
            repeatPic.Image = System.Drawing.Image.FromFile("button\\repeat2.png");
        }

        private void repeatPic_MouseLeave(object sender, EventArgs e)
        {
            repeatPic.Image = System.Drawing.Image.FromFile("button\\repeat.png");
        }

        private void serialPic_MouseEnter(object sender, EventArgs e)
        {
            serialPic.Image = System.Drawing.Image.FromFile("button\\serial2.png");
        }

        private void serialPic_MouseLeave(object sender, EventArgs e)
        {
            serialPic.Image = System.Drawing.Image.FromFile("button\\serial.png");
        }

        private void signupPic_MouseEnter(object sender, EventArgs e)
        {
            signupPic.Image = System.Drawing.Image.FromFile("button\\signup2.png");
        }

        private void signupPic_MouseLeave(object sender, EventArgs e)
        {
            signupPic.Image = System.Drawing.Image.FromFile("button\\signup.png");
        }

        private void SignUp_MouseDown(object sender, MouseEventArgs e)
        {
            moustPoint = new Point(e.X, e.Y);
        }

        private void SignUp_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (moustPoint.X - e.X), this.Top - (moustPoint.Y - e.Y));
            }
        }
    }
}
