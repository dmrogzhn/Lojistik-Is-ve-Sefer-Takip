using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    class sefer_Olustur
    {
        Form1 fr;

        public sefer_Olustur(Form1 form)
        {
            fr = form;
        }      
        

        string connectionString = baglanti.baglantiAdresi;

        private int kartOkuma(string kartID)// burası kartı okuma işleminin gerçekleştiği ve okuma sonrasında gelen kart id sinin hangi soföre ait olduğunu bulduğumuz fonksiyon
        {
            string kartID_ = kartID;
            int sofor_ID = 1;       

            
            string query = "select * from bekleyen_Sofor with sofor_ID = @karrtan_Gelen_id";

            return sofor_ID;
                      
        }

        private void gelen_ID_Kontrol(int kart_sonucundaki_ID)// bu parametre kartOkuma fonksiyonundan dönen id yi alacak
        {
            // aşağıdaki kodu daha sonrasında kart sonucunda elde ettiğimiz soforun id si geleceek
            int kart_sonucundaki_ID_ = kart_sonucundaki_ID; // daha sonrasında parametreden gelen değeri buna eşitleyeceğiz
            
            
            string query = "select * from bekleyen_Sofor where sofor_ID = @id";            
            int gidecek_Sofor_ID = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", kart_sonucundaki_ID_);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            gidecek_Sofor_ID = reader.GetInt32(reader.GetOrdinal("sofor_ID")); ; // 0. sütun: ID                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // BURADAKİ HATA BLOĞUNA DÜŞÜYOR
                Console.WriteLine("HATA GELEN ID KONTROL ==>>" + ex.Message);
                MessageBox.Show("Hata: " + ex.Message);
                throw;
            }

            if (Convert.ToInt32(fr.secilen_Sofor_ID) == gidecek_Sofor_ID)// eğer listeden seçilen şoför ile kart okutulan şoför aynı ise ne iş yapacağı yazıyor
            {
                // buraya hem gidecek şoförün sıra numarasını alacağız hem de işin sırasını alacağız eğer ikisi de en küçükse ok olacak
                // yani gidecek şoför tablosundan sıra sütunundaki en küçük veriyi al ve gidecek şoförün de sıra numarasını al eğer gidecek oln şoförün sıra no su ile en küçük sıra eşleşiyorsa kontrolü yap 
                // seçilen işin sıra numarasını al sonrasında bekleyen işler tablosundaki en küçük sıra numarasını al bunlar bir birine eşitse kontrolu yap eğer yukarıdaki ve bu koşul sağlanıyorsa sefer eklemsi yap
                string gidecekSoforSiraNo = $"select sira_No from bekleyen_Sofor where sofor_ID = {gidecek_Sofor_ID}";
                string gidecekIsSirasi = $"select sira_No from Bekleyen_Isler where is_ID ={secilen_Is_ID}";
                string querySiradakiSofor = "select MIN(sira_No) from bekleyen_Sofor";
                string querySiradakiIs = "select MIN(sira_No) from Bekleyen_Isler";

                int siradakiSofor = 0;
                int siradakiIs = 0;
                int secilenSoforSirasi = 0;
                int secilenIsSirasi = 0;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // İlk sorgu
                    using (SqlCommand command1 = new SqlCommand(querySiradakiSofor, connection))
                    {
                        object value1 = command1.ExecuteScalar();
                        siradakiSofor = value1 != null ? Convert.ToInt32(value1) : 0; // Null kontrolü yaparak int'e dönüştürme
                    }

                    // İkinci sorgu
                    using (SqlCommand command2 = new SqlCommand(querySiradakiIs, connection))
                    {
                        object value2 = command2.ExecuteScalar();
                        siradakiIs = value2 != null ? Convert.ToInt32(value2) : 0; // Null kontrolü yaparak int'e dönüştürme
                    }

                    using (SqlCommand command2 = new SqlCommand(gidecekSoforSiraNo, connection))
                    {
                        object value2 = command2.ExecuteScalar();
                        secilenSoforSirasi = value2 != null ? Convert.ToInt32(value2) : 0; // Null kontrolü yaparak int'e dönüştürme
                    }

                    using (SqlCommand command2 = new SqlCommand(gidecekIsSirasi, connection))
                    {
                        object value2 = command2.ExecuteScalar();
                        secilenIsSirasi = value2 != null ? Convert.ToInt32(value2) : 0; // Null kontrolü yaparak int'e dönüştürme
                    }
                }

                if (siradakiSofor == secilenSoforSirasi && secilenIsSirasi == siradakiIs)// şoförü sırası ve işin sırası önemli yani sıradaki şoför sıradaki işi mi aldı kontrol ediyoruz
                {
                    seferOlustur(secilen_Is_ID, gidecek_Sofor_ID);
                    MessageBox.Show("Sefer Ekleme İşlemi Başarıyla Gerçekleşti");
                }
                else
                {
                    MessageBox.Show("Lütfen iş ve Şoför sırasının doğruluğunu kontrol ediniz");
                }
                
            }
            else
            {
                MessageBox.Show("seçilen şoför ile kart sahibi uyuşmamaktadır");
            }           

        }

        public void seferOlustur(int isID,int soforID)// karttan gelen bilgi kontrol edildikten sonra yani yukarıdaki fonksiyonda çağırılıyor
        {
            int isID_ = isID;
            int soforID_ = soforID;
            DateTime sefer_Cikis_Tarihi = DateTime.Today;            
            string sefer_Durumu = "Yolda";

            string query = "insert into tbl_Sefer (ıs_ID,sofor_ID,sefer_Cikis_Tarihi,sefer_Durumu) VALUES (@isID,@soforID,@seferCikisTarihi,@seferDurumu)";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Bağlantıyı aç
                    connection.Open();

                    // Komut oluştur
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreleri tanımla ve değerlerini ata
                        command.Parameters.AddWithValue("@isID", isID_);
                        command.Parameters.AddWithValue("@soforID", soforID_);
                        command.Parameters.AddWithValue("@seferCikisTarihi", sefer_Cikis_Tarihi);
                        command.Parameters.AddWithValue("@seferDurumu", sefer_Durumu);

                        // Sorguyu çalıştır
                        int rowsAffected = command.ExecuteNonQuery();

                        // Sonuç bilgisi
                        Console.WriteLine($"{rowsAffected} satır eklendi.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                Console.WriteLine("Hata: " + ex.Message);
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        int secilen_Is_ID;

        public void AddressTile_Click(object sender, EventArgs e)
        {
            MetroFramework.Controls.MetroTile clickedTile = sender as MetroFramework.Controls.MetroTile;

            // dgv den aldığımız isimle id ile aldığımız isim aynı ise kontrolünü yaptğımız satır
            string soforAdi = fr.soforAdi;//dgv den gelen sofor adını aldık
            
            try
            {
                if (clickedTile != null)
                {
                    string selectedAddress = clickedTile.Text;
                    secilen_Is_ID = (int)clickedTile.Tag;
                    // Seçilen adresin işlemleri
                    MessageBox.Show("Kartınızı okutunuz", "Kart Okuma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gelen_ID_Kontrol(1);  // KART OKUMA İŞLEMİ HENÜZ GERÇEKLEŞMEDİĞİ İÇİN EL İLE BİR ID BİLGİSİ GİRDİK. ŞOFÖR LİSTESİNDEKİ SEÇİLEN ŞOFÖR İLE BURADAKİ ŞOFÖR UYUŞMAZ İSE HATA MESAJI ALINIR. BURADAKİ PARAMETRE KART OKUMA MODÜLÜ YAZILDIKTAN SONRA KARTTAN GELEN ID OLACAK
                    MessageBox.Show("sefer ekleme işlemi başarıyle gerçekleşti");

                    fr.formReset();

                }
            }
            catch (Exception ex)
            {
                // BURADAKİ HATA BLOĞUNA DÜŞÜYOR
                Console.WriteLine("HATA ==!!!===>> " + ex.Message);
                MessageBox.Show($"hata: {ex.Message}");
            }
        }
    }
}
