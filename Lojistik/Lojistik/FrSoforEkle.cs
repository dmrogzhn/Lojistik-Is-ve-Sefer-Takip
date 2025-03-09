using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class FrSoforEkle : MetroSetForm
    {
        private kartOkuma kartOkuyucu;

        public FrSoforEkle()
        {
            InitializeComponent();
            //kartOkuyucu = new kartOkuma();
            //kartOkuyucu.KartOkutuldu += KartOkutulduHandler; // Olayı dinle
            //kartOkuyucu.Baslat(); // Kart okuyucuyu başlat

            Task.Run(() =>
            {
                try
                {
                    kartOkuyucu = new kartOkuma();
                    kartOkuyucu.KartOkutuldu += KartOkutulduHandler; // Olayı dinle
                    kartOkuyucu.Baslat(); // Kart okuyucuyu başlat
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show($"Kart okuyucu başlatılamadı: {ex.Message}");
                    }));
                }
            });
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KartOkutulduHandler(object sender, string kartID)
        {
            // Kart okutulduğunda tetiklenen işlem
            if (!string.IsNullOrEmpty(kartID))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    txtKartID.Text = kartID; // Kart ID'sini TextBox'a yazdır
                    
                });
            }
        }


        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            kaydet();
            kartOkuyucu.Durdur();
        }

        private void kaydet()
        {
            string connectionString = baglanti.baglantiAdresi;           

            string adSoyad = txtAdSoyad.Text.Trim();
            string telefon = txtTelefon.Text.Trim();
            string aracPlaka = txtAracPlakasi.Text.Trim();
            string dorsePlakasi = txtDorsePlakasi.Text.Trim();
            string kartID = txtKartID.Text.Trim();
            int aktifMi = 1;

            string query = "insert into tbl_Sofor (sofor_Ad_Soyad,sofor_Telefon,sofor_Arac_Plaka,sofor_Dorse_Plaka,sofor_Kart_ID,aktif_Mi) values(@adSoyad, @telefon, @aracPlaka, @dorsePlakasi, @kartID, @aktifMi)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Bağlantıyı aç
                    connection.Open();

                    // Komut oluştur ve parametreleri ata
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@adSoyad", adSoyad);
                        command.Parameters.AddWithValue("@telefon", telefon);
                        command.Parameters.AddWithValue("@aracPlaka", aracPlaka);
                        command.Parameters.AddWithValue("@dorsePlakasi", dorsePlakasi);
                        command.Parameters.AddWithValue("@kartID", kartID);
                        command.Parameters.AddWithValue("@aktifMi", aktifMi);

                        // Sorguyu çalıştır
                        command.ExecuteNonQuery();

                        MessageBox.Show("Şoför Başarıyla kaydedildi");

                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine("Hata: " + ex.Message);
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }

        }
    }
}
