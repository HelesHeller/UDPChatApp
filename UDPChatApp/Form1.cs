using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UDPChatApp
{
    public partial class MainForm : Form
    {
        // Параметры сервера
        private const int serverPort = 12345;
        private const string serverIP = "26.129.29.176";
        // UDP клиент и конечная точка сервера
        private UdpClient client;
        private IPEndPoint serverEndPoint;

        public MainForm()
        {
            InitializeComponent();
            client = new UdpClient();
            serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            client.Client.Bind(new IPEndPoint(IPAddress.Any, 12345)); // Привязка клиента к любому доступному порту на всех сетевых интерфейсах
            Thread receiveThread = new Thread(ReceiveMessages);// Создание потока для приема сообщений
            receiveThread.Start();// Запуск потока приема сообщений
        }

        // Метод для приема сообщений от сервера
        private void ReceiveMessages()
        {
            try
            {
                while (true)
                {
                    byte[] data = client.Receive(ref serverEndPoint);
                    string message = Encoding.Unicode.GetString(data);
                    Invoke(new Action(() => listBoxChat.Items.Add(message)));
                }
            }
            catch (SocketException ex)
            {
                // Обработка исключения
                Console.WriteLine($"Ошибка при приеме сообщения: {ex.Message}");
            }
        }

        // Метод для отправки сообщения на сервер
        private void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, serverEndPoint);
        }
        // Обработчик события нажатия на кнопку отправки сообщения
        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxMessage.Text))
            {
                string userName = textBoxName.Text;
                string message = $"{userName}: {textBoxMessage.Text}";
                SendMessage(message);
                textBoxMessage.Clear();
            }
        }
    }
}
