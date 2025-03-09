using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class FirstForm : MetroSetForm
    {
        public FirstForm()
        {
            InitializeComponent();
        }

        

        private void metroSetDefaultButton2_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            this.Hide();
            fr.Show();
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            // X butonuna basınca uygulamayı kapatsın diye
            Application.Exit();
        }

        private void FirstForm_Load(object sender, EventArgs e)
        {

        }

        public static string sayfaKontrol = ""; 
        /*
         BU DEĞİŞKENİMİZ HANGİ AYARLAR BUTONUNDAN YETKİ KONTROL SAYFASINA GEÇTİĞİNİ KONTROL ETMEK İÇİN VAR.
         EĞER İLK FORM DAN GEÇİLİYORSA BURADAKİ STRİNG DEĞERİMİZ ELSE İÇERİSİNDEKİ GİBİ DEĞİŞTİRİLİYOR.
         DAHA SONRASINDA YETKİ KONTROL SAYFASINA ATILIYOR. 
         O SAYFADA STRİNG KONTROLÜ YAPILIYOR. EĞER İLK SAYFADAN GELDİYSE SETTİNG SAYFASINDAKİ KAPATMA BUTONU İLK SAYFAYI AÇIYOR. 
         SEFER İŞLEMLERİNDEKİ AYARLAR BUTONUNDAN TIKLANDIYSA GENE YETKİ KONTROL SAYFASINA ATIYOR AMA BU SEFER STRİNGLER UYUŞMADIĞINDAN SETTİNGS SAYFASINDAKİ KAPATMA BUTONU SEFER İŞLEMLERİ FORMUNU AÇIYOR
         YANİ BURADAKİ KONTROL SAYESİNDE HANGİ AYARLAR BUTONUNA TIKLANILARAK AYARLAR SAYFASINA GİTMEK İSTENİLDİ ONUN KONTROLÜNÜ YAPIYORUZ
         */
        private void btnSettings1_Click(object sender, EventArgs e)
        {
            //yetkiKontrol yetki = new yetkiKontrol();
            //yetki.Show();

            if (!File.Exists("connection.txt"))
            {
                FirstSettings firstSettings = new FirstSettings();
                firstSettings.Show();
                return;
            }
            else
            {
                sayfaKontrol = "İlk Ayar";
                yetkiKontrol yetkiKontrol = new yetkiKontrol();
                yetkiKontrol.Show();
                this.Hide();
            }

            //FirstYetkiKontrol yetkiKontrol = new FirstYetkiKontrol();
            //yetkiKontrol.Show();

            
        }

        private void metroSetDefaultButton1_Click(object sender, EventArgs e)
        {
            FrGidecekSofor frGidecekSofor = new FrGidecekSofor();
            frGidecekSofor.Show();
        }
    }
}
