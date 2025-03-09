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
    public partial class yetkiKontrol : MetroSetForm
    {
        public yetkiKontrol()
        {
            InitializeComponent();
            
        }

        private void metroSetTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroSetTextBox1_Click(object sender, EventArgs e)
        {

        }

        public static string yetkiDerecesi;
        public static int yetkiliID;

        private void button1_Click(object sender, EventArgs e)
        {
            // Bağlantı dizesi
            string connectionString = baglanti.baglantiAdresi;

            // SQL sorgusu (parametreli)
            string query = "SELECT yetkili_Derecesi, yetkili_Ad_Soyad, aktif_Mi, yetkili_ID FROM tbl_Yetkili WHERE kullaniciAdi = @kullaniciAdi AND yetkili_Sifre = @yetkiliSifre";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Bağlantıyı aç
                    connection.Open();

                    // Komut oluştur ve parametreleri ata
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kullaniciAdi", txtKullaniciAdi.Text);
                        command.Parameters.AddWithValue("@yetkiliSifre", txtSifre.Text);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Veri var mı kontrol et
                            if (reader.Read())
                            {
                                bool aktifMi = Convert.ToBoolean(reader["aktif_Mi"]);

                                if (!aktifMi)
                                {
                                    // Kullanıcı aktif değilse
                                    MessageBox.Show("Yetkili bulunamadı. Lütfen yetkili durumunu kontrol edin.");
                                    txtKullaniciAdi.Text = "";
                                    txtSifre.Text = "";
                                    return;
                                }

                                // Kullanıcı aktif ve bilgiler doğru
                                string isim = reader["yetkili_Ad_Soyad"].ToString();
                                yetkiDerecesi = reader["yetkili_Derecesi"].ToString();
                                yetkiliID = Convert.ToInt32(reader["yetkili_ID"]);
                                MessageBox.Show($"Hoş geldiniz, {isim}");

                                this.Close();
                                SettingsForm settingsForm = new SettingsForm();
                                settingsForm.Show();
                            }
                            else
                            {
                                // Kullanıcı adı veya şifre yanlış
                                MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                            }
                        }
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

        string sayfaKontrol = "İlk Ayar";
        /*BU KONTROL EĞER İLK AÇILAN SAYFADAKİ AYARLAR BUTONUNA TIKLANDIYSA KAPATMA BUTONU İLK SAYFAYI AÇSIN DİYE VAR. 
         * YANİ İLK SAYFADAKİ AYARLAR BUTONUNA TIKLANINCA ORADAKİ BİR STRİNG DEĞİŞKEN "İlk Ayar" OLARAK OLUŞTURULUYOR. 
         * DOĞAL OLARAK BİZ DE BURADA KONTROLU YAPIYORUZ EĞER İLK AYAR DİYE OLUŞTURULMADIYSA İLK AÇILAN SAYFADA BURADA DA İLK İF İÇERİSİNE GİRMEYECEĞİNDEN
         * DEMEK Kİ SEFER KONTROL SAYFASINDAKİ AYARLAR BUTONUNDA YETKİ KONTROL SAYFASINA GELİNMİŞ DEMEKTİR */
        private void btnBreak_Click(object sender, EventArgs e)
        {
            if (sayfaKontrol == FirstForm.sayfaKontrol)
            {
                FirstForm firstForm = new FirstForm();
                this.Close();
                firstForm.Show();
            }
            else
            {
                Form1 form = new Form1();
                form.Show();
                this.Close();
            }
            
        }

        

        private void txtSifre_Enter(object sender, EventArgs e)
        {
            txtSifre.Text = "";
            txtSifre.UseSystemPasswordChar = true;
        }
    }
}
