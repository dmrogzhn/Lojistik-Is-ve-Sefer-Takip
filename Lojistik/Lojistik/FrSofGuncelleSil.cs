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
    public partial class FrSofGuncelleSil : MetroSetForm
    {
        public FrSofGuncelleSil()
        {
            InitializeComponent();
            CustomizeDataGridView();
            load_Grid();
            toolsLocations();
            butonRengi();            
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

        private void toolsLocations()
        {
            lblAdSoyad.Location = new Point(785, 95);
            lblAracPlaka.Location = new Point(120, 186);
            lblDorsePlaka.Location = new Point(120,288);
            lblID.Location = new Point(134,84);
            lblKartID.Location = new Point(790,288);
            lblTelefon.Location = new Point(790,186);
            txtAdSoyad.Location = new Point(935, 87);
            txtAracPlakasi.Location = new Point(270, 178);
            txtDorsePlakasi.Location = new Point(270,280);
            txtID.Location = new Point(270,76);
            txtKartID.Location = new Point(935,280);
            txtTelefon.Location = new Point(935,178);
        }// uygulamayı çalıştırdığımda kaymalar yaşandığı için her bir tools kod ile sabitlendi

        public void load_Grid()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select s.sofor_ID as 'ID' , s.sofor_Ad_Soyad as 'Ad Soyad', s.sofor_Telefon as 'Telefon', s.sofor_Arac_Plaka as 'Araç Plakası', s.sofor_Dorse_Plaka as 'Dorse Plakası', s.sofor_Kart_ID as 'Kart ID' from tbl_Sofor s where aktif_Mi = 1";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtAdSoyad.Text = row.Cells["Ad Soyad"].Value.ToString();
                txtAracPlakasi.Text = row.Cells["Araç Plakası"].Value.ToString();
                txtDorsePlakasi.Text = row.Cells["Dorse Plakası"].Value.ToString();
                txtID.Text = row.Cells["ID"].Value.ToString();
                txtKartID.Text = row.Cells["Kart ID"].Value.ToString();
                txtTelefon.Text = row.Cells["Telefon"].Value.ToString();
            }
        }

        private void txtboxTemizle()
        {
            txtAdSoyad.Text = "";
            txtAracPlakasi.Text = "";
            txtDorsePlakasi.Text = "";
            txtID.Text = "";
            txtKartID.Text = "";
            txtTelefon.Text = "";
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text.Trim());
            string adSoyad = txtAdSoyad.Text.Trim();
            string aracPlaka = txtAracPlakasi.Text.Trim();
            string dorsePlaka = txtDorsePlakasi.Text.Trim();
            string telefon = txtTelefon.Text.Trim();
            string kartID = txtKartID.Text.Trim();

            string connectionString = baglanti.baglantiAdresi;
            string query = "update tbl_Sofor set sofor_Ad_Soyad = @adSoyad, sofor_Telefon = @telefon, sofor_Arac_Plaka = @aracPlaka, sofor_Dorse_Plaka = @dorsePlaka, sofor_Kart_ID = @kartID where sofor_ID = @id";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@id", id);
                        command.Parameters.AddWithValue("@adSoyad", adSoyad);
                        command.Parameters.AddWithValue("@telefon", telefon);
                        command.Parameters.AddWithValue("@aracPlaka", aracPlaka);
                        command.Parameters.AddWithValue("@dorsePlaka", dorsePlaka);
                        command.Parameters.AddWithValue("@kartID", kartID);


                        // Sorguyu çalıştır
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
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text.Trim());
            int inaktif = 0;
            string adSoyad = txtAdSoyad.Text.Trim();

            string connectionString = baglanti.baglantiAdresi;

            // Şoförün seferde olup olmadığını kontrol et
            string checkQuery = "select count(*) from tbl_Sefer where sofor_ID = @id and sefer_Durumu = 'Yolda'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.AddWithValue("@id", id);

                    int seferdekiSoforSayisi = (int)checkCommand.ExecuteScalar();

                    if (seferdekiSoforSayisi > 0)
                    {
                        // Şoför yolda, inaktif edilemez
                        MessageBox.Show("Bu şoför seferde olduğu için silinemez!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // Şoförün silinmesi için onay al
            DialogResult result = MessageBox.Show($"{adSoyad} isimli kişiyi silmek istiyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Şoförü inaktif yap
                    string query = "UPDATE tbl_Sofor SET aktif_Mi = @inaktif WHERE sofor_Id = @id";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.Parameters.AddWithValue("@inaktif", inaktif);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Şoför başarıyla inaktif yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Grid'i yeniden yükle ve text kutularını temizle
                                load_Grid();
                                txtboxTemizle();
                            }
                            else
                            {
                                MessageBox.Show("Güncellenecek kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("İşleme Devam Edilmiyor.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
