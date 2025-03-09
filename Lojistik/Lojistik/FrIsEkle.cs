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
    public partial class FrIsEkle : MetroSetForm
    {
        public FrIsEkle()
        {
            InitializeComponent();
            CustomizeDataGridView();
            load_Grid();
            btnBreak.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dataGridView1.ClearSelection();
            txtIsCikisBirimi.Focus();
        }

        private void FrIsEkle_Load(object sender, EventArgs e)
        {

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

        private void textBoxTemizleme()
        {
            txtIsCikisBirimi.Text = "";
            txtIsVarisBirimi.Text = "";
            txtTasinacakYuk.Text = "";
        }

        private void btnIsOlustur_Click(object sender, EventArgs e)
        {
            string cikisBirimi = txtIsCikisBirimi.Text.Trim();
            string varisBirimi = txtIsVarisBirimi.Text.Trim();
            string tasinacakYuk = txtTasinacakYuk.Text.Trim();
            int yetkili = Convert.ToInt32(yetkiKontrol.yetkiDerecesi);
            string isAlinma = "Hayır";

            DateTime time = DateTime.Today;

            string connectionString = baglanti.baglantiAdresi;
            string query = "insert into tbl_Is (is_Cikis_Birimi,is_Varis_Birimi,tasinacak_Yuk,is_Olusturma_Tarihi,is_Alindi_Mi,is_Olusturan_Yetkili_ID) values (@cikisBirimi, @varisBirimi, @tasinacakYuk, @time, @isAlinma, @yetkili)";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query,connection))
                    {
                        if (!string.IsNullOrEmpty(cikisBirimi) && !string.IsNullOrEmpty(varisBirimi) && !string.IsNullOrEmpty(tasinacakYuk))
                        {
                            command.Parameters.AddWithValue("@cikisBirimi", cikisBirimi);
                            command.Parameters.AddWithValue("@varisBirimi", varisBirimi);
                            command.Parameters.AddWithValue("@tasinacakYuk", tasinacakYuk);
                            command.Parameters.AddWithValue("@time", time);
                            command.Parameters.AddWithValue("@isAlinma", isAlinma);
                            command.Parameters.AddWithValue("@yetkili", yetkili);

                            command.ExecuteNonQuery();

                            MessageBox.Show("İş Başarıyla eklendi");
                            load_Grid();
                            textBoxTemizleme();
                        }
                        else
                        {
                            MessageBox.Show("Boş hücre olamaz.");
                        }

                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                throw;
            }

        }

        public void load_Grid()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select i.is_ID as 'İş ID', i.is_Cikis_Birimi as 'Çıkış Birimi', i.is_Varis_Birimi as 'Varış Birimi', i.tasinacak_Yuk as 'Taşınacak Yük' ,i.is_Alindi_Mi as 'İş Alınma Durumu', i.is_Olusturma_Tarihi as 'Oluşturulma Tarihi', i.is_Olusturan_Yetkili_ID as 'Oluşturan Yetkili ID'  from tbl_Is i";

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

                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }

            }
        }

        public void load_Grid_Bekleyen_Isler()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select i.is_ID as 'İş ID', i.is_Cikis_Birimi as 'Çıkış Birimi', i.is_Varis_Birimi as 'Varış Birimi', i.tasinacak_Yuk as 'Taşınacak Yük' ,i.is_Alindi_Mi as 'İş Alınma Durumu', i.is_Olusturma_Tarihi as 'Oluşturulma Tarihi', i.is_Olusturan_Yetkili_ID as 'Oluşturan Yetkili ID'  from tbl_Is i where is_Alindi_Mi = 'Hayır'";

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

        public void load_Grid_Seferdeki_Isler()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select i.is_ID as 'İş ID', i.is_Cikis_Birimi as 'Çıkış Birimi', i.is_Varis_Birimi as 'Varış Birimi', i.tasinacak_Yuk as 'Taşınacak Yük' ,i.is_Alindi_Mi as 'İş Alınma Durumu', i.is_Olusturma_Tarihi as 'Oluşturulma Tarihi', i.is_Olusturan_Yetkili_ID as 'Oluşturan Yetkili ID'  from tbl_Is i where is_Alindi_Mi = 'Alındı'";

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

        public void load_Grid_Tamamlanan_Isler()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select i.is_ID as 'İş ID', i.is_Cikis_Birimi as 'Çıkış Birimi', i.is_Varis_Birimi as 'Varış Birimi', i.tasinacak_Yuk as 'Taşınacak Yük' ,i.is_Alindi_Mi as 'İş Alınma Durumu', i.is_Olusturma_Tarihi as 'Oluşturulma Tarihi', i.is_Olusturan_Yetkili_ID as 'Oluşturan Yetkili ID'  from tbl_Is i where is_Alindi_Mi = 'Tamamlandı'";

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

        private void txtYoldakiIs_Click(object sender, EventArgs e)
        {
            load_Grid_Seferdeki_Isler();
        }

        private void btnTamamlananIs_Click(object sender, EventArgs e)
        {
            load_Grid_Tamamlanan_Isler();
        }

        private void btnBekleyenIs_Click(object sender, EventArgs e)
        {
            load_Grid_Bekleyen_Isler();
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
