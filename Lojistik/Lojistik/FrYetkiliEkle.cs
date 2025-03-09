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
    public partial class FrYetkiliEkle : MetroSetForm
    {
        public FrYetkiliEkle()
        {
            InitializeComponent();
            CustomizeDataGridView();
            load_Grid();
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
            string query = "select y.yetkili_ID as 'ID', y.yetkili_Ad_Soyad as 'Ad Soyad', y.kullaniciAdi as 'Kullanıcı Adı', y.yetkili_Sifre as 'Şifre', y.yetkili_Derecesi as 'Yetki Derecesi' from tbl_Yetkili y where aktif_Mi = 1";

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

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtboxTemizleme()
        {
            txtAdSoyad.Text = "";
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            txtYetkiDerecesi.Text = "";
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "insert into tbl_Yetkili (yetkili_Ad_Soyad,yetkili_Sifre,yetkili_Derecesi,kullaniciAdi,aktif_Mi) values (@adSoyad,@sifre,@yetkiDerecesi,@kullaniciAdi,@aktif_Mi)";

            string adSoyad = txtAdSoyad.Text.Trim();
            string sifre = txtSifre.Text.Trim();
            int yetkiDerecesi = int.Parse(txtYetkiDerecesi.Text.Trim());
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            int aktifMi = 1;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand (query,connection))
                    {
                        command.Parameters.AddWithValue("@adSoyad", adSoyad);
                        command.Parameters.AddWithValue("@sifre", sifre);
                        command.Parameters.AddWithValue("@yetkiDerecesi", yetkiDerecesi);
                        command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        command.Parameters.AddWithValue("@aktif_mi", aktifMi);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Yetkili ekleme işlemi gerçekleşti");
                        txtboxTemizleme();
                        load_Grid();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA ==> " + ex.Message);
                MessageBox.Show("Hata " + ex.Message);
                throw;
            }
        }
    }
}
