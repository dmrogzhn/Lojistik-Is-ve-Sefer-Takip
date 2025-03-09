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
    public partial class FrSoforListesi : MetroSetForm
    {
        public FrSoforListesi()
        {
            InitializeComponent();
            CustomizeDataGridView();
            kapatmaButonuKonum();
            load_Grid();
        }

        private void kapatmaButonuKonum()
        {
            btnBreak.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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

        public void load_Grid_SeferdekiSofor()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select ss.sofor_Ad_Soyad as 'Ad Soyad', ss.sofor_Telefon as 'Telefon' ,ss.is_Cikis_Birimi as 'Çıkış Birimi', ss.is_Varis_Birimi as 'Varış Birimi', ss.tasinacak_Yuk as 'Taşınacak Yük', ss.sefer_Cikis_Tarihi as 'Çıkış Tarihi' from seferdeki_Sofor ss";

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

        public void load_Grid()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select s.sofor_ID as 'ID', s.sofor_Ad_Soyad as 'Ad Soyad', s.sofor_Telefon 'Telefon', s.sofor_Arac_Plaka as 'Araç Plakası', s.sofor_Dorse_Plaka as 'Dorse Plakası', s.sofor_Kart_ID as 'Kart ID' from tbl_Sofor s where aktif_Mi = 1";

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

        public void load_Grid_BekleyenSofor()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select bs.sofor_Ad_Soyad as 'Ad Soyad', bs.sofor_Telefon as 'Telefon', bs.sira_No as 'Sıra No' from bekleyen_Sofor bs";

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

        private void btnBekleyenSofor_Click(object sender, EventArgs e)
        {
            load_Grid_BekleyenSofor();
        }

        private void btnSeferdekiSofor_Click(object sender, EventArgs e)
        {
            load_Grid_SeferdekiSofor();
        }

        private void btnButunSoforler_Click(object sender, EventArgs e)
        {
            load_Grid();
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
