using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    class kartOkuma
    {
        private TcpClient tcpClient;
        private NetworkStream stream;
        private Thread dinlemeThread;

        // Son okunan Kart ID
        private string kartID;

        // Kart okutulduğunda tetiklenecek olay
        public event EventHandler<string> KartOkutuldu;

        private class KartConfig
        {
            public string IP { get; set; }
            public int Port { get; set; }
        }

        private KartConfig config;

        public kartOkuma()
        {
            YükleConfig();
        }

        private void YükleConfig()
        {
            try
            {
                string configPath = "server_Config.json";
                if (File.Exists(configPath))
                {
                    string json = File.ReadAllText(configPath);
                    config = JsonConvert.DeserializeObject<KartConfig>(json);

                    if (string.IsNullOrEmpty(config.IP) || config.Port == 0)
                    {
                        throw new Exception("IP veya Port bilgisi eksik.");
                    }
                }
                else
                {
                    throw new FileNotFoundException("server_Config.json dosyası bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Config yükleme hatası: {ex.Message}");
                throw;
            }
        }

        public void Baslat()
        {
            try
            {
                tcpClient = new TcpClient(config.IP, config.Port);
                stream = tcpClient.GetStream();

                dinlemeThread = new Thread(KartDinle);
                dinlemeThread.IsBackground = true;
                dinlemeThread.Start();
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Hata: {ex.Message}\nHata Kodu: {ex.ErrorCode}");
                Console.WriteLine("HATA!!:::",ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine($"Bağlantı hatası: {ex.Message}");
            }
        }

        public void Durdur()
        {
            try
            {
                stream?.Close();
                tcpClient?.Close();
                dinlemeThread?.Abort();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Durdurma hatası: {ex.Message}");
            }
        }

        private void KartDinle()
        {
            try
            {
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        kartID = Encoding.UTF8.GetString(buffer, 0, bytesRead).Trim();
                        Console.WriteLine($"Kart ID okundu: {kartID}");

                        // Kart Okutuldu olayını tetikle
                        KartOkutuldu?.Invoke(this, kartID);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata:", ex.Message);
                Console.WriteLine($"Dinleme hatası: {ex.Message}");
            }
        }

        // Son okunan Kart ID'sini döndür
        public string KartIDGetir()
        {
            return kartID;
        }
    }
}