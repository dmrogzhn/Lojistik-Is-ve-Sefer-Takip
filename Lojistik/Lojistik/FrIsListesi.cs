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
    public partial class FrIsListesi : MetroSetForm
    {
        public FrIsListesi()
        {
            InitializeComponent();
            CustomizeDataGridView();
            load_Grid();
            btnBreak.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;
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

        

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYoldakiIs_Click(object sender, EventArgs e)
        {
            load_Grid_Seferdeki_Isler();
        }

        private void btnBekleyenIs_Click(object sender, EventArgs e)
        {
            load_Grid_Bekleyen_Isler();
        }

        private void btnTamamlananIs_Click(object sender, EventArgs e)
        {
            load_Grid_Tamamlanan_Isler();
        }

        
    }
}
