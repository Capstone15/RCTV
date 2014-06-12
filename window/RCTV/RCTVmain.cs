using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using AForge.Video.FFMPEG;
using System.Data.SqlClient;


namespace RCTV
{
    public partial class RCTVmain : Form
    {
        public const int OFF = 0;
        public const int COMPLETE = 1;
        public const int ON =  2;
        Point moustPoint;
        string strConn = "server = 203.246.112.87,49304; uid = sa; pwd = 22179215; database = rctv;";
        public static bool logoutClicked = true;
        private bool imgRun=false;
        private Socket imgSocket;
        private Socket chatSocket;
        Thread imgThread;
        Thread chatThread;
        MemoryStream imgStream;
        Bitmap image;
        string ip=null;
        int imgPort=0;
        int chatPort = 0;
        int recordStatus = OFF;
        int onOffStatus = OFF;
        VideoFileWriter writer;
        String ct;
        bool takePicture = false;
        string photoPath = "C:\\RCTV\\Photo";
        string videoPath = "C:\\RCTV\\Video";
        byte[] msgBuf = new byte[1024];


        public RCTVmain()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            
        }

        public void imageReceiver()
        {

            imgSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string strQuery = "SELECT RaspIP,imgPort FROM raspberrypi JOIN (SELECT RCTVNumber FROM customer WHERE ID=\'"+Program.user_id+"\') c ON c.RCTVNumber = raspberrypi.RaspNumber;" ;
            SqlConnection connect = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ip = reader.GetString(0);
                    imgPort = reader.GetInt32(1);
                }
            }
            catch
            {
                MessageBox.Show("Error");
                connect.Close();
                return;
            }
            connect.Close();


            try
            {
                imgSocket.Connect(ip, imgPort);
            }
            catch
            {
                MessageBox.Show("접속실패");

                UpdateChatMsg("연결종료\r\n");
                initAll();
                return;
            }
            int totalLength = 0;
            int receiveLength = 0;
            imgRun = true;
            onOffPic.Image = System.Drawing.Image.FromFile("button\\off.png");
            onOffStatus = ON;
            chatSocket.Send(Encoding.UTF8.GetBytes(Program.user_id + " 입장."));
            UpdateChatMsg("연결성공\r\n");
            while (imgRun)
            {
                try
                {
                    //bool networkUp = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                    //if (!imgSocket.Connected)
                    //{
                    //    imgSocket.Close();
                    //    imgRun = false;
                    //    
                    //    return;
                    //}
                    byte[] buffer = new byte[4];
                    int len = imgSocket.Receive(buffer);
                    if (len < 1)
                    {
                        UpdateChatMsg("연결중단\r\n");
                        initAll();
                    }
                    int fileLength;

                    fileLength = BitConverter.ToInt32(buffer, 0);

                    if (fileLength > 0)
                    {
                        byte[] imgData = new byte[fileLength + 1];


                        // 현재까지 받은 파일 크기 변수 

                        // 파일 수신 작업 
                        totalLength = 0;
                        while (fileLength > totalLength)
                        {
                            // 클라이언트가 보낸 파일 데이터를 받음 

                            byte[] readData = new byte[4096];
                            byte[] endData = new byte[3];
                            if (fileLength - totalLength < 4096)
                            {
                                endData = new byte[fileLength - totalLength];
                                receiveLength = imgSocket.Receive(endData);
                                if (receiveLength < 1)
                                {
                                    UpdateChatMsg("연결중단\r\n");
                                    initAll();
                                }
                                System.Buffer.BlockCopy(endData, 0, imgData, totalLength, receiveLength);
                            }
                            else
                            {
                                receiveLength = imgSocket.Receive(readData);
                                //MessageBox.Show("while 안");
                                if (receiveLength < 1)
                                {
                                    UpdateChatMsg("연결중단\r\n");
                                    initAll();
                                    break;
                                }
                                System.Buffer.BlockCopy(readData, 0, imgData, totalLength, receiveLength);
                                // 받은 데이터를 파일에 씀 
                                // 현재까지 받은 파일 크기를 더함 
                            }
                            totalLength += receiveLength;
                        }
                        imgStream = new MemoryStream(imgData);

                        if (recordStatus==ON)
                        {
                            image = new Bitmap(imgStream);
                            writer.WriteVideoFrame(image);
                        }
                        else if (recordStatus==COMPLETE)
                        {
                            try
                            {
                                writer.Close();
                                UpdateChatMsg("녹화완료\r\n");
                                recordStatus =OFF;
                            }
                            catch { }
                        }

                        if (takePicture)
                        {
                            if (!Directory.Exists(photoPath))
                            {
                                Directory.CreateDirectory(photoPath);

                            }
                            try
                            {
                                image = new Bitmap(imgStream);
                                image.Save(photoPath + "\\" + Path.GetRandomFileName()+".jpeg",System.Drawing.Imaging.ImageFormat.Jpeg);
                                takePicture = false;
                                UpdateChatMsg("사진 저장 완료("+photoPath+")\r\n");
                            }
                            catch
                            {
                                MessageBox.Show("Error");
                            }
                        }

                        monitor.Image = Image.FromStream(imgStream);
                        Invalidate();
                        System.Array.Clear(imgData, 0, imgData.Length);
                    }
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.ToString());       
                }
            }

        }
        public void chatReceiver()
        {
            chatSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string strQuery = "SELECT RaspIP,chatPORT FROM raspberrypi JOIN (SELECT RCTVNumber FROM customer WHERE ID=\'" + Program.user_id + "\') c ON c.RCTVNumber = raspberrypi.RaspNumber;";
            SqlConnection connect = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(strQuery, connect);
            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ip = reader.GetString(0);
                    
                    chatPort = reader.GetInt32(1);
                }
            }
            catch
            {
                MessageBox.Show("Error");
                connect.Close();
                return;
            }
            connect.Close();
            try
            {
                chatSocket.Connect(ip, chatPort);
                if (chatSocket.Connected)
                {
                    this.chatReceive();
                }

            }
            catch
            {
                MessageBox.Show("접속실패");
                chatSocket.Close();
                return;
            }

        }


        private void RCTVmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (imgRun)
                {

                    imgRun = false;

                    chatSocket.Send(Encoding.UTF8.GetBytes("__quit"));
                    imgSocket.Close();
                    chatSocket.Close();
                    chatThread.Abort();
                    imgThread.Abort();
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

 
        private void onOffPic_MouseClick(object sender, MouseEventArgs e)
        {
            if (onOffStatus==OFF)
            {
                UpdateChatMsg("연결중...\r\n");
                imgThread = new Thread(new ThreadStart(imageReceiver));
                imgThread.IsBackground = true;
                imgThread.Start();
                chatThread = new Thread(new ThreadStart(chatReceiver));
                chatThread.IsBackground = true;
                chatThread.Start();
                //System.Threading.Thread.Sleep(1);
                onOffPic.Image = System.Drawing.Image.FromFile("button\\off.png");
                monitor.Image = null;
                onOffStatus = ON;
            }
            else if (onOffStatus==ON)
            {
                try
                {
                    chatSocket.Send(Encoding.UTF8.GetBytes("__quit"));
                    initAll();
                    UpdateChatMsg("연결종료\r\n");
                    chatThread.Abort();
                    imgThread.Abort();
                    onOffPic.Image = System.Drawing.Image.FromFile("button\\on.png");
                    monitor.Image = null;

                    if (recordStatus == ON)
                    {
                        onOffStatus = OFF;
                        writer.Close();
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }
        }

        private void recordPic_MouseClick(object sender, MouseEventArgs e)
        {
            if (imgRun)
            {
                if (recordStatus==ON)
                {
                    recordStatus = COMPLETE;
                    recordPic.Image = System.Drawing.Image.FromFile("button\\recordon.png");
                }
                else if (recordStatus==OFF)
                {
                    recordStatus = ON;
                    if (!Directory.Exists(videoPath))
                    {
                        Directory.CreateDirectory(videoPath);

                    }
                    writer = new VideoFileWriter();
                    ct = System.DateTime.Now.ToString("yyyy-MM-dd hh_mm_ss.avi");
                    writer.Open(videoPath+"\\"+ct, 320, 240, 10, VideoCodec.MPEG4, 10000000);
                    recordPic.Image = System.Drawing.Image.FromFile("button\\recordoff.png");
                    UpdateChatMsg("녹화시작\r\n");
                }
            }
            else
                MessageBox.Show("Error");
        }

        private void logoutPic_MouseClick(object sender, MouseEventArgs e)
        {
            logoutClicked = true;
            this.Close();
        }

        private void exitPic_MouseClick(object sender, MouseEventArgs e)
        {
            logoutClicked = false;
            this.Close();
        }

        private void onOffPic_MouseEnter(object sender, EventArgs e)
        {
            if (onOffStatus==ON)
                onOffPic.Image = System.Drawing.Image.FromFile("button\\off2.png");
            else if (onOffStatus==OFF)
                onOffPic.Image = System.Drawing.Image.FromFile("button\\on2.png");
        }

        private void onOffPic_MouseLeave(object sender, EventArgs e)
        {
            if (onOffStatus==ON)
                onOffPic.Image = System.Drawing.Image.FromFile("button\\off.png");
            if (onOffStatus==OFF)
                onOffPic.Image = System.Drawing.Image.FromFile("button\\on.png");
        }

        private void recordPic_MouseEnter(object sender, EventArgs e)
        {
            if (recordStatus==ON)
                recordPic.Image = System.Drawing.Image.FromFile("button\\recordoff2.png");
            else if (recordStatus==OFF)
                recordPic.Image = System.Drawing.Image.FromFile("button\\recordon2.png");
        }

        private void recordPic_MouseLeave(object sender, EventArgs e)
        {
            if (recordStatus==ON)
                recordPic.Image = System.Drawing.Image.FromFile("button\\recordoff.png");
            else if (recordStatus==OFF)
                recordPic.Image = System.Drawing.Image.FromFile("button\\recordon.png");
                
        }

        private void takePhotoPic_MouseEnter(object sender, EventArgs e)
        {
            takePhotoPic.Image = System.Drawing.Image.FromFile("button\\picture2.png");
        }

        private void takePhotoPic_MouseLeave(object sender, EventArgs e)
        {
            takePhotoPic.Image = System.Drawing.Image.FromFile("button\\picture.png");
        }

        private void logoutPic_MouseEnter(object sender, EventArgs e)
        {
            logoutPic.Image = System.Drawing.Image.FromFile("button\\logout2.png");
        }

        private void logoutPic_MouseLeave(object sender, EventArgs e)
        {
            logoutPic.Image = System.Drawing.Image.FromFile("button\\logout.png");
        }

        private void exitPic_MouseEnter(object sender, EventArgs e)
        {
            exitPic.Image = System.Drawing.Image.FromFile("button\\exit2.png");
        }

        private void exitPic_MouseLeave(object sender, EventArgs e)
        {
            exitPic.Image = System.Drawing.Image.FromFile("button\\exit.png");
        }

        private void RCTVmain_MouseDown(object sender, MouseEventArgs e)
        {
            moustPoint = new Point(e.X, e.Y);
        }

        private void RCTVmain_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (moustPoint.X - e.X), this.Top - (moustPoint.Y - e.Y));
            }
        }

        private void takePhotoPic_Click(object sender, EventArgs e)
        {
            if (imgRun)
                takePicture = true;
            else
                MessageBox.Show("연결을 해주세요");
        }

        public void chatReceive()
        {
            chatSocket.BeginReceive(msgBuf, 0, msgBuf.Length, SocketFlags.None, new AsyncCallback(chatReceiveCallback), chatSocket);
        }

        private void chatReceiveCallback(IAsyncResult IAR)
        {
            try
            {
                Socket tempSock = (Socket)IAR.AsyncState;
                int nReadSize = tempSock.EndReceive(IAR);
                if (nReadSize != 0)
                {
                    string message = new UTF8Encoding().GetString(msgBuf, 0, nReadSize);
                    if (message.Contains("__mc"))
                    {
                        right.Enabled = true;
                        left.Enabled = true;
                        this.Refresh();
                        
                    }
                    else
                        UpdateChatMsg(message);
                }
                this.chatReceive();
            }
            catch (SocketException se)
            {
            }

        }

        private void ReloadForm()
        {
            throw new NotImplementedException();
        }

        private void chatText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (chatSocket.Connected)
                    {
                        chatSocket.Send(Encoding.UTF8.GetBytes(Program.user_id + " : " + chatText.Text));
                        chatText.Text = null;
                    }
                    else
                    {
                        MessageBox.Show("연결을 해주세요");
                        chatText.Text = null;
                    }
                }
                catch
                {
                    MessageBox.Show("연결을 해주세요");
                }
            }
        }
        private void UpdateChatMsg(string data)
        {
            if (chatPrinter.InvokeRequired)
            {
                // 작업쓰레드인 경우
                chatPrinter.BeginInvoke(new Action(() => chatPrinter.AppendText(data)));
                chatPrinter.BeginInvoke(new Action(() => chatPrinter.ScrollToCaret()));
            }
            else
            {
                // UI 쓰레드인 경우
                chatPrinter.AppendText(data);
                chatPrinter.ScrollToCaret();
            }
        }
        private void initAll()
        {
            recordPic.Image = System.Drawing.Image.FromFile("button\\recordon.png");
            onOffPic.Image = System.Drawing.Image.FromFile("button\\on.png");
            if (recordStatus == ON)
            {
                writer.Close();
                recordStatus = OFF;
            }
            try
            {
                imgSocket.Close();
            }
            catch { }
            logoutClicked = true;
            imgRun=false;
            recordStatus = OFF;
            onOffStatus = OFF;
            takePicture = false;
            monitor.Image = null;
        }

        private void left_MouseEnter(object sender, EventArgs e)
        {
            left.Image = System.Drawing.Image.FromFile("button\\left2.png");
        }

        private void left_MouseLeave(object sender, EventArgs e)
        {
            left.Image = System.Drawing.Image.FromFile("button\\left.png");
        }

        private void right_MouseEnter(object sender, EventArgs e)
        {
            right.Image = System.Drawing.Image.FromFile("button\\right2.png");
        }

        private void right_MouseLeave(object sender, EventArgs e)
        {
            right.Image = System.Drawing.Image.FromFile("button\\right.png");
        }

        private void left_Click(object sender, EventArgs e)
        {
            if (chatSocket.Connected)
            {
                chatSocket.Send(Encoding.UTF8.GetBytes("__L"));
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (chatSocket.Connected)
            {
                chatSocket.Send(Encoding.UTF8.GetBytes("__R"));
            }
        }


    }
}
