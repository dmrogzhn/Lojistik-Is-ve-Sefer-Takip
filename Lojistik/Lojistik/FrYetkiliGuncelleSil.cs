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
    public partial class FrYetkiliGuncelleSil : MetroSetForm
    {
        public FrYetkiliGuncelleSil()
        {
            InitializeComponent();
            CustomizeDataGridView();
            load_Grid();
            butonRengi();
            btnBreak.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }

        private void CustomizeDataGridView()
        {
            // Genel ayarlar
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.GridColor = System.Drawing.Color.FromArgb(210, 210, 210);

            // Sütun başlığı tasarımı
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(0, 174, 219); // Metro mavi
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            // Hücre tasarımı
            dataGridView1.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 20, FontStyle.Italic);
            dataGridView1.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(0, 174, 219);
            dataGridView1.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            // Kenarlık ayarları
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            //dataGridView1.RowTemplate.Height;

            // Gizle veya özelleştir
            dataGridView1.RowHeadersVisible = false; // Satır başlıklarını gizle

            dataGridView1.ClearSelection();

        }//dataGrid nasıl görünecek

        public void load_Grid()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select y.yetkili_ID as 'ID', y.yetkili_Ad_Soyad as 'Ad Soyad', y.kullaniciAdi as 'Kullanıcı Adı' ,y.yetkili_Sifre as 'Şifre', y.yetkili_Derecesi as 'Yetki Dercesi'  from tbl_Yetkili y where aktif_Mi = 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // DataGridView'e veri aktarımı
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }

            }
        }

        private void butonRengi()
        {
            btnSil.NormalColor = Color.Red;

            // Fare Üzerindeyken (Hover) Görünen Renk
            btnSil.HoverColor = Color.DarkRed;

            // Tıklanıldığında (Pressed) Görünen Renk
            btnSil.PressColor = Color.Maroon;

            // Buton Metni Rengi
            btnSil.NormalTextColor = Color.White;
            btnSil.HoverTextColor = Color.White;
            btnSil.PressTextColor = Color.White;
        }// silme butonu proparties de kırmızı olmayınca kod ile müdahale ettik

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtAdSoayd.Text = row.Cells["Ad Soyad"].Value.ToString();
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtKullaniciAdi.Text = row.Cells["Kullanıcı Adı"].Value.ToString();
                txtSifre.Text = row.Cells["Şifre"].Value.ToString();
                txtYetkiDerecesi.Text = row.Cells["Yetki Derecesi"].Value.ToString();

               
            }
        }

        private void txtboxTemizle()
        {
            txtAdSoayd.Text = "";
            txtID.Text = "";
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtYetkiDerecesi.Text = "";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text.Trim());
            string adSoyad = txtAdSoayd.Text.Trim();
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            int yetkiDerecesi = int.Parse(txtYetkiDerecesi.Text.Trim());

            string connectionString = baglanti.baglantiAdresi;
            string query = "update tbl_Yetkili set yetkili_Ad_Soyad = @adSoyad, yetkili_Sifre = @sifre, yetkili_Derecesi = @yetkiDerecesi, kullaniciAdi = @kullaniciAdi where yetkili_ID = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@adSoyad", adSoyad);
                        command.Parameters.AddWithValue("@sifre", sifre);
                        command.Parameters.AddWithValue("@yetkiDerecesi", yetkiDerecesi);
                        command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Güncelleme başarılı!");
                            load_Grid();
                            txtboxTemizle();
                        }
                        else
                        {
                            MessageBox.Show("Güncellenecek kayıt bulunamadı.");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata ==>> " + ex.Message);
                MessageBox.Show("Hata: " + ex.Message);
                throw;
            }
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
