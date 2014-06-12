using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

public delegate void EventHandler(object sender, EventArgs e);
namespace RCTV
{
    
    public partial class Login : Form
    {

        public event EventHandler enterEvent;
        Point moustPoint;
        public static bool loginSuccess = false;
        string strConn = "server = 203.246.112.87,49304; uid = sa; pwd = 22179215; database = rctv;";
        
        public Login()
        {
            InitializeComponent();
            enterEvent += new EventHandler(loginPic_MouseClick);
        }
        private void joinPic_MouseClick(object sender, MouseEventArgs e)
        {
            SignUp signup = new SignUp();
            signup.ShowDialog();
        }

        private void loginPic_MouseClick(object sender, EventArgs e)
        {
            Program.user_id = id_text.Text;
            string strQuery = "SELECT COUNT(*) FROM customer WHERE ID=\'" + Program.user_id + "\' AND Password = \'" + password_text.Text + "\';";
            SqlConnection connect = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            try
            {
                connect.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {

                    //RCTVmain rctv = new RCTVmain();
                    //rctv.Show();
                    loginSuccess = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("아이디 또는 비밀번호를 확인하세요.");
                    loginSuccess = false;
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void loginPic_MouseEnter(object sender, EventArgs e)
        {
            loginPic.Image = System.Drawing.Image.FromFile("button\\login2.png");
        }

        private void loginPic_MouseLeave(object sender, EventArgs e)
        {
            loginPic.Image = System.Drawing.Image.FromFile("button\\login.png");
        }

        private void joinPic_MouseEnter(object sender, EventArgs e)
        {
            joinPic.Image = System.Drawing.Image.FromFile("button\\join2.png");
        }

        private void joinPic_MouseLeave(object sender, EventArgs e)
        {
            joinPic.Image = System.Drawing.Image.FromFile("button\\join.png");
        }

        private void xxPic_MouseEnter(object sender, EventArgs e)
        {
            xxPic.Image = System.Drawing.Image.FromFile("button\\x2.png");
        }

        private void xxPic_MouseLeave(object sender, EventArgs e)
        {
            xxPic.Image = System.Drawing.Image.FromFile("button\\x.png");
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            moustPoint = new Point(e.X, e.Y);
        }

        private void Login_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (moustPoint.X - e.X), this.Top - (moustPoint.Y - e.Y));
            }
        }


        private void password_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enterEvent(sender, e);
            }
        }

        private void id_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                enterEvent(sender, e);
            }
        }

    }
}
