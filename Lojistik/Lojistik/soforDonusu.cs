using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    class soforDonusu
    {
        private kartOkuma kartOkuyucu;
        


        public soforDonusu()
        {
            kartOkuyucu = new kartOkuma();
            kartOkuyucu.KartOkutuldu += KartOkutulduHandler;
            //MessageBox.Show("İşlem tamam");
        }

        private void KartOkutulduHandler(object sender, string kartID)
        {
            // Kart okutulduğunda tetiklenen işlem
            seferGuncelle(kartID);
        }

        int soforID = -1;
        string sofor_isim;

        private void seferGuncelle(string kartID)
        {
            string connectionString = baglanti.baglantiAdresi;

            string kartID_ = kartID;            

            string query1 = "select sofor_ID, sofor_Ad_Soyad from tbl_Sofor where sofor_Kart_ID = @kartID_";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query1, connection))
                {
                    // Parametreyi ekle
                    command.Parameters.AddWithValue("@kartID", kartID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Eğer veri varsa
                        {
                            soforID = reader.GetInt32(0); // sofor_ID'yi al (ilk kolon)
                            sofor_isim = reader.GetString(1); // sofor_Ad_Soyad'ı al (ikinci kolon)
                            Console.WriteLine($"Soför ID: {soforID}, Soför Ad Soyad: {sofor_isim}");
                        }
                        else
                        {
                            MessageBox.Show("Soför ID bulunamadı.");
                        }
                    }
                }
            }

            if (soforID == -1)
            {
                MessageBox.Show("Geçersiz Şoför ID");
            }
            else
            {
                DateTime date = DateTime.Today;
                string query2 = "update tbl_Sefer set sefer_Donus_Tarihi = @date, sefer_Durumu = 'Tamamlandı' where sofor_ID = @soforID and sefer_Durumu = 'Yolda'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query2, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@soforID", soforID);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Başarıyla güncellenen satır sayısı: {rowsAffected}");
                        MessageBox.Show($"HOŞGELDİNİZ: {sofor_isim}");
                        
                    }
                }
            }         


        }
    }
}
