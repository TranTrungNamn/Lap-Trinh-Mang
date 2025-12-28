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
            // Vòng lặp để liên tục chấp nhận Client mới sau khi Client cũ ngắt kết nối
            while (isServer)
            {
                try
                {
                    // Server chờ kết nối (Code sẽ dừng tại đây cho đến khi có Client kết nối)
                    client = server.AcceptTcpClient();
                    UpdateStatus("Client Connected!");

                    // Hiển thị thông tin Client kết nối
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        rtbChatLog.AppendText("[Server] New connection accepted from: " + client.Client.RemoteEndPoint.ToString() + "\n");
                    }));

                    // Thiết lập luồng đọc/ghi
                    NetworkStream stream = client.GetStream();
                    STR = new StreamReader(stream);
                    STW = new StreamWriter(stream);
                    STW.AutoFlush = true;

                    // Bắt đầu nhận tin nhắn (Hàm này sẽ chạy cho đến khi Client ngắt kết nối)
                    ReceiveMessages();

                    // Khi ReceiveMessages kết thúc (Client đã ngắt kết nối), đóng socket Client để dọn dẹp
                    client.Close();
                }
                catch (SocketException)
                {
                    // Lỗi này thường xảy ra khi Server bị Stop (listener đóng) -> Thoát vòng lặp
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Server: " + ex.Message);
                    break;
                }
            }
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
    // Kiểm tra tin nhắn rỗng
    if (string.IsNullOrWhiteSpace(txtMessage.Text)) return;

    // 1. Kiểm tra xem đã kết nối chưa
    if (client == null || !client.Connected || STW == null)
    {
        MessageBox.Show("Chưa kết nối! Vui lòng kết nối trước khi gửi tin.", 
                        "Lỗi gửi tin", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
        return;
    }

    try
    {
        textToSend = txtMessage.Text;

        // 2. Cố gắng gửi dữ liệu qua mạng
        STW.WriteLine(textToSend);
        
        // 3. Chỉ cập nhật giao diện nến gửi thành công
        string who = isServer ? "[Server]" : "[Client]";
        rtbChatLog.AppendText(DateTime.Now.ToShortTimeString() + " " + who + ": " + textToSend + "\n");
        
        // Xóa ô nhập liệu
        txtMessage.Clear();
    }
    catch (Exception ex)
    {
        // 4. Báo lỗi nếu có vấn đề trong quá trình truyền tin (ngắt kết nối đột ngột)
        MessageBox.Show("Không thể gửi tin nhắn. Lỗi: " + ex.Message, 
                        "Lỗi kết nối", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
    }
}

        private void ReceiveMessages()
        {
            try
            {
                while (client != null && client.Connected)
                {
                    textReceive = STR.ReadLine(); // Khi đóng Form, dòng này sẽ gây lỗi nếu không có try-catch

                    if (textReceive == null) break; // Client ngắt kết nối

                    if (textReceive != "")
                    {
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            string who = isServer ? "[Client]" : "[Server]";
                            if (!rtbChatLog.IsDisposed) // Kiểm tra Form còn tồn tại không trước khi update UI
                            {
                                rtbChatLog.AppendText(DateTime.Now.ToShortTimeString() + " " + who + ": " + textReceive + "\n");
                            }
                        }));
                    }
                }
            }
            catch (IOException)
            {
                // Bỏ qua lỗi IO khi đóng kết nối
            }
            catch (ObjectDisposedException)
            {
                // Bỏ qua lỗi khi đối tượng đã bị hủy (do đóng Form)
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
            // Đặt cờ báo hiệu không còn là Server nữa để vòng lặp StartListening thoát
            isServer = false;

            // Đóng kết nối Client nếu đang mở
            if (client != null)
            {
                try
                {
                    // Đóng stream trước để ngừng việc đọc/ghi
                    if (STW != null) STW.Close();
                    if (STR != null) STR.Close();
                    client.Close();
                }
                catch { }
            }

            // Dừng Server Listener
            if (server != null)
            {
                try
                {
                    server.Stop();
                }
                catch { }
            }

            // Đảm bảo đóng ứng dụng hoàn toàn
            Application.Exit();
            Environment.Exit(0); // Bắt buộc dừng toàn bộ tiến trình (bao gồm background threads)
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