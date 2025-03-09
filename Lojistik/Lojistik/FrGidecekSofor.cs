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
    public partial class FrGidecekSofor : MetroSetForm
    {
        public FrGidecekSofor()
        {
            InitializeComponent();
            btnBreak.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_MinMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;            
            load_Grid();
            CustomizeDataGridView();
            dataGridView1.ClearSelection();
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Left;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void CustomizeDataGridView()
        {
            // Genel ayarlar
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.GridColor = System.Drawing.Color.FromArgb(210, 210, 210);

            // Sütun başlığı tasarımı
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(176, 196, 222); // Metro mavi 0, 174, 219 orijinal kodları
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 30, FontStyle.Bold);
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

            // Satır başlıklarını gizle
            dataGridView1.RowHeadersVisible = false;

            //fazladan satır eklemeyi kaldırdık
            dataGridView1.AllowUserToAddRows = false;

            // Verilerin seçimini temizle
            dataGridView1.ClearSelection();
        }

        public void load_Grid()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select sofor_Ad_Soyad as 'Ad Soyad', sira_Statu from tbl_Sira inner join tbl_Sofor on tbl_Sira.sofor_ID = tbl_Sofor.sofor_ID where sira_Statu = 'Waiting' or sira_Statu = 'onTrip' order by sira_No";

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



                    // sira_Statu sütununu gizle
                    dataGridView1.Columns["sira_Statu"].Visible = false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine("HATA ==>> " + ex.Message);
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btn_MinMax_Click(object sender, EventArgs e)
        {
            // Eğer form zaten tam ekran modundaysa, normal modda aç
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;  // Normal mod
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;  // Tam ekran moduna geçir
                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 30, FontStyle.Italic);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 40, FontStyle.Bold);

            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Satır renklerini ayarlayın
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // 'sira_Statu' hücresinin değerini kontrol et
                if (row.Cells["sira_Statu"].Value != null)
                {
                    string siraStatu = row.Cells["sira_Statu"].Value.ToString().Trim(); // Değerin başındaki ve sonundaki boşlukları temizle
                    if (!string.IsNullOrEmpty(siraStatu))
                    {
                        if (siraStatu == "Waiting")
                        {
                            row.DefaultCellStyle.BackColor = Color.DeepSkyBlue;

                        }
                        else if (siraStatu == "onTrip")
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGreen;;
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.LightGray;  // Belirtilmeyen durumlar için
                        }
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;  // Boş olanlar için gri renk
                    }
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;  // Null olanlar için gri renk
                }
            }

            // İlk satırın seçili olmaması için tüm seçimleri temizleyin
            dataGridView1.ClearSelection();
        }
    }
}
