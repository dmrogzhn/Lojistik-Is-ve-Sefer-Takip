using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    class is_Getir
    {
        private Form1 fr;
        sefer_Olustur sefer;
        // burada listeleri işleri içine atmak için tuttuk class yaparken private yerine public yapmayı deneriz
        private List<string> cikisBirimleri = new List<string>();
        private List<string> varisBirimleri = new List<string>();
        private List<string> yukler = new List<string>();
        private List<int> isIDs = new List<int>();

        public is_Getir(Form1 form)
        {
            this.fr = form;
            sefer = new sefer_Olustur(fr);
        }

        

        public void getIs()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select is_ID,is_Cikis_Birimi, is_Varis_Birimi,tasinacak_Yuk from Bekleyen_Isler order by sira_No";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        isIDs.Add(Convert.ToInt32(reader["is_ID"])); // ID'leri listeye ekle
                        cikisBirimleri.Add(reader["is_Cikis_Birimi"].ToString());
                        varisBirimleri.Add(reader["is_Varis_Birimi"].ToString());
                        yukler.Add(reader["tasinacak_Yuk"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }

        }

        public void LoadAddressTiles()// iş seçimi yapıldığında ne yapması gerektiği yani tile a tıklandığında ne yapması gerektiği defer_Olustur.cs de
        {
            //fr.flowLayoutPanel1.Visible = true;
            fr.flowLayoutPanel1.Controls.Clear();
            fr.flowLayoutPanel1.Padding = new Padding(20, 0, 20, 0); // Başlangıç padding'i

            getIs(); // işleri aldığımız bir fonksiyon

            for (int i = 0; i < cikisBirimleri.Count; i++)
            {
                MetroFramework.Controls.MetroTile tile = new MetroFramework.Controls.MetroTile();                
                //tile.Text = $"Çıkış: {cikisBirimleri[i]}\nVarış: {varisBirimleri[i]}\nYük: {yukler[i]}";
                tile.Width = 300;
                tile.Height = 150;
                tile.Style = MetroFramework.MetroColorStyle.Blue; // Renk seçimi
                tile.Tag = isIDs[i];

                //tile ın kendi yazıları çok küçüktü ve büyütme işlemlerini yapamadık ben de üzerine biz label ekledim ve textini ayarladım. tıklanma özelliğini de tile tıklanma özelliğine eşitledim

                Label label = new Label();
                label.Text = $"Çıkış: {cikisBirimleri[i]}\nVarış: {varisBirimleri[i]}\nYük: {yukler[i]}";
                label.Dock = DockStyle.Fill;  // Label'ın tüm alanı kaplamasını sağla
                label.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold | FontStyle.Italic);  // Font büyütme
                label.TextAlign = ContentAlignment.BottomLeft;  // Yazıyı ortalamak için
                label.ForeColor = Color.White;
                
                //Label'ı tile'a ekle
                tile.Controls.Add(label);

                label.Click += (sender, e) => tile.PerformClick();  // Label tıklanırsa tile'ın tıklama olayını tetikle

                tile.Click += sefer.AddressTile_Click;// burada sefer oluştur sınıfındaki işleri yapıyor



                fr.flowLayoutPanel1.Controls.Add(tile);
            }
            AdjustPanelPadding(); // Panel padding'ini ayarla
            fr.Resize += (sender, e) => AdjustPanelPadding(); // Form boyutu değiştiğinde çağır
        }

        public void AdjustPanelPadding()
        {
            int formWidth = fr.Width;
            int panelWidth = fr.flowLayoutPanel1.PreferredSize.Width; // İçeriğin gerçek genişliği
            int leftPadding = (formWidth - panelWidth) / 2;

            fr.flowLayoutPanel1.Padding = new Padding(Math.Max(leftPadding, 20), 0, 20, 0);
        }
       
    }
}
