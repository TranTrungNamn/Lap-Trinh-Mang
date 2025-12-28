using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace csharpgui
{
    public partial class Form1 : Form
    {
        TcpListener? server;
        TcpClient? client;
        StreamReader? STR;
        StreamWriter? STW;
        string? textToSend;
        string? textReceive;
        Thread? listenThread;
        bool isServer = false;

        public Form1()
        {
            InitializeComponent();
            if (cboIP != null) cboIP.Text = "127.0.0.1";
            this.MyImage1.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                isServer = true;
                server = new TcpListener(IPAddress.Any, (int)numPortServer.Value);
                server.Start();

                UpdateStatus("Server started. Waiting for connection...");
                rtbChatLog.AppendText("[Server] Started listening on port " + numPortServer.Value + "\n");

                btnStart.Enabled = false;
                btnStop.Enabled = true;

                listenThread = new Thread(StartListening);
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở Server: " + ex.Message);
            }
        }

        private void StartListening()
        {
            try
            {
                client = server.AcceptTcpClient();
                UpdateStatus("Client Connected!");

                // Hiển thị thông tin
                this.Invoke(new MethodInvoker(delegate ()
                {
                    rtbChatLog.AppendText("[Server] Local: " + client.Client.LocalEndPoint.ToString() + "\n");
                    rtbChatLog.AppendText("[Server] Remote: " + client.Client.RemoteEndPoint.ToString() + "\n");
                }));

                NetworkStream stream = client.GetStream();
                STR = new StreamReader(stream);
                STW = new StreamWriter(stream);
                STW.AutoFlush = true;
                this.Invoke(new MethodInvoker(delegate ()
                {
                    rtbChatLog.AppendText(DateTime.Now.ToShortTimeString() + ": [Server] " + "\n");
                }));

                ReceiveMessages();
            }
            catch { }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                if (server != null) server.Stop();
                if (client != null) client.Close();
                UpdateStatus("Server Stopped");
                rtbChatLog.AppendText("[Server] Service stopped.\n");

                btnStart.Enabled = true;
                btnStop.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            isServer = false;
            try
            {
                client = new TcpClient();
                IPEndPoint IP_End = new IPEndPoint(IPAddress.Parse(cboIP.Text), (int)numPortClient.Value);
                client.Connect(IP_End);

                if (client.Connected)
                {
                    UpdateStatus("Connected to Server!");

                    // Hiển thị thông tin
                    rtbChatLog.AppendText("[Client] Local: " + client.Client.LocalEndPoint.ToString() + "\n");
                    rtbChatLog.AppendText("[Client] Remote: " + client.Client.RemoteEndPoint.ToString() + "\n");
                    NetworkStream stream = client.GetStream();
                    STR = new StreamReader(stream);
                    STW = new StreamWriter(stream);
                    STW.AutoFlush = true;

                    listenThread = new Thread(ReceiveMessages);
                    listenThread.IsBackground = true;
                    listenThread.Start();

                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (client != null) client.Close();
                UpdateStatus("Disconnected");
                rtbChatLog.AppendText("[Client] Disconnected.\n");

                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
            }
            catch { }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "")
            {
                textToSend = txtMessage.Text;

                if (STW != null)
                {
                    STW.WriteLine(textToSend);
                }

                string who = isServer ? "[Server]" : "[Client]";
                rtbChatLog.AppendText(DateTime.Now.ToShortTimeString() + " " + who + ": " + textToSend + "\n");
                txtMessage.Clear();
            }
        }

        private void ReceiveMessages()
        {
            while (client.Connected)
            {
                try
                {
                    textReceive = STR.ReadLine();
                    if (textReceive != "")
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            string who = isServer ? "[Client]" : "[Server]";
                            rtbChatLog.AppendText(DateTime.Now.ToShortTimeString() + " " + who + ": " + textReceive + "\n");
                        }));
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, rtbChatLog.Text);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rtbChatLog.Text = File.ReadAllText(ofd.FileName);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbChatLog.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (client != null) client.Close();
                if (server != null) server.Stop();
            }
            catch { }
            Application.Exit();
        }

        private void UpdateStatus(string status)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate { lblStatus.Text = "Status: " + status; }));
            }
            else
            {
                lblStatus.Text = "Status: " + status;
            }
        }

        private void cboIP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}