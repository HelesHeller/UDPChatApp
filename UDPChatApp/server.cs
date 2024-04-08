using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

//namespace UDPChatApp
//{
//    class Server
//    {
//        private const int ServerPort = 1W2345; // Порт сервера

//        static void Main(string[] args)
//        {
//            UdpClient server = new UdpClient(ServerPort);
//            Console.WriteLine("Сервер запущен...");

//            while (true)
//            {
//                IPEndPoint clientEndPoint = null;
//                byte[] data = server.Receive(ref clientEndPoint);
//                string message = Encoding.UTF8.GetString(data);

//                // Обработка сообщения
//                ProcessMessage(message, clientEndPoint);
//            }
//        }

//        static void ProcessMessage(string message, IPEndPoint clientEndPoint)
//        {
//            // Парсим сообщение
//            string[] parts = message.Split('|');
//            if (parts.Length >= 3 && parts[0] == "REGISTER")
//            {
//                string username = parts[1];
//                string password = parts[2];

//                // Здесь можно добавить логику для регистрации пользователя в базе данных или её имитацию

//                Console.WriteLine($"Пользователь {username} зарегистрирован.");
//                SendResponse("SUCCESS", clientEndPoint); // Отправляем подтверждение о регистрации
//            }
//            else
//            {
//                Console.WriteLine("Некорректное сообщение: " + message);
//            }
//        }

//        static void SendResponse(string response, IPEndPoint clientEndPoint)
//        {
//            UdpClient udpClient = new UdpClient();
//            byte[] data = Encoding.UTF8.GetBytes(response);
//            udpClient.Send(data, data.Length, clientEndPoint);
//            udpClient.Close();
//        }
//    }
//}
