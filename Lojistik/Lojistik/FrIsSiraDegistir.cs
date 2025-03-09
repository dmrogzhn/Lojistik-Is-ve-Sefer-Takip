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
    public partial class FrIsSiraDegistir : MetroSetForm
    {
        public FrIsSiraDegistir()
        {
            InitializeComponent();
            CustomizeDataGridView();
            load_Grid();
            toolsKonum();

            dataGridView1.AllowDrop = true;
            dataGridView1.MouseDown += dataGridView1_MouseDown;
            dataGridView1.DragOver += dataGridView1_DragOver;
            dataGridView1.DragDrop += dataGridView1_DragDrop;
            dataGridView1.MouseMove += dataGridView1_MouseMove;
            dataGridView1.DragEnter += dataGridView1_DragEnter;


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

        private void toolsKonum()
        {
            txtID.Location = new Point(172, 55);
            txtCikisBirimi.Location = new Point(172, 106);
            txtVarisBirimi.Location = new Point(172, 151);
            txtSiraNo.Location = new Point(172, 197);

            txtID2.Location = new Point(172, 55);
            txtCikisBirimi2.Location = new Point(172, 106);
            txtVarisBirimi2.Location = new Point(172, 151);
            txtSiraNo2.Location = new Point(172, 197);

            btnBreak.Anchor = AnchorStyles.Top | AnchorStyles.Right;

        }

        public void load_Grid()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select b.sira_No as 'Sıra No' , b.is_Cikis_Birimi as 'Çıkış Birimi', b.is_Varis_Birimi as 'Varış Birimi', b.tasinacak_Yuk as 'Taşınacak Yük', b.is_ID as 'İş ID' from Bekleyen_Isler b order by sira_No";

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

        int secim = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Sürükleme işlemi sırasında tıklamayı engelle
            {
                if (secim % 2 == 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    txtSiraNo.Text = row.Cells["Sıra No"].Value.ToString();
                    txtID.Text = row.Cells["İş ID"].Value.ToString();
                    txtCikisBirimi.Text = row.Cells["Çıkış Birimi"].Value.ToString();
                    txtVarisBirimi.Text = row.Cells["Varış Birimi"].Value.ToString();

                    secim++;
                }
                else if (secim % 2 == 1)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                    txtSiraNo2.Text = row.Cells["Sıra No"].Value.ToString();
                    txtID2.Text = row.Cells["İş ID"].Value.ToString();
                    txtCikisBirimi2.Text = row.Cells["Çıkış Birimi"].Value.ToString();
                    txtVarisBirimi2.Text = row.Cells["Varış Birimi"].Value.ToString();

                    secim++;
                }
            }
        }

        private void btnSiraDegistir_Click(object sender, EventArgs e)
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "update tbl_Is_Sirasi set sira_No = @siraNo2 where is_ID = @isID" +
                "" +
                            " update tbl_Is_Sirasi set sira_No = @siraNo where is_ID = @isID2";

            int id1 = int.Parse(txtID.Text);
            int id2 = Convert.ToInt32(txtID2.Text);
            int sira1 = Convert.ToInt32(txtSiraNo.Text);
            int sira2 = Convert.ToInt32(txtSiraNo2.Text);

            if (sira1 != null && sira2 != null)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@siraNo2", sira2);
                            command.Parameters.AddWithValue("@isID", id1);
                            command.Parameters.AddWithValue("@siraNo", sira1);
                            command.Parameters.AddWithValue("@isID2", id2);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Sıra Değiştirme Başarılı");
                            }
                            else
                            {
                                MessageBox.Show("Güncelleme işlemi gerçekleşmedi. Kriterleri kontrol ediniz.");
                            }

                        }
                    }
                    load_Grid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                    Console.WriteLine("HATA!!>>> " + ex.Message);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Lütfen 2 Adet İş Seçiniz");
            }
        }

        private int rowIndexFromMouseDown; // Sürükleme başlatıldığında seçilen satırın indeksi
        private int rowIndexOfItemUnderMouseToDrop; // Bırakılacak alanın indeksi
        private int draggedRowIndex;
        private bool isDragging;

        // İş sırasını değiştirme metodu (Sürükle-bırak için)
        private void UpdateJobOrder(int jobId, int newOrder)
        {
            string connectionString = baglanti.baglantiAdresi;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Eski sırayı öğren
                    string getCurrentOrderQuery = "SELECT sira_No FROM tbl_Is_Sirasi WHERE is_ID = @jobId";
                    int currentOrder;
                    using (SqlCommand cmd = new SqlCommand(getCurrentOrderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@jobId", jobId);
                        currentOrder = (int)cmd.ExecuteScalar();
                    }

                    // İş yukarı mı taşınıyor, aşağı mı kontrol et
                    if (newOrder < currentOrder)
                    {
                        // Yukarı taşıma: Aradaki sıraları bir artır
                        string updateQuery = @"
                    UPDATE tbl_Is_Sirasi 
                    SET sira_No = sira_No + 1 
                    WHERE sira_No >= @newOrder AND sira_No < @currentOrder;
                ";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@newOrder", newOrder);
                            cmd.Parameters.AddWithValue("@currentOrder", currentOrder);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else if (newOrder > currentOrder)
                    {
                        // Aşağı taşıma: Aradaki sıraları bir azalt
                        string updateQuery = @"
                    UPDATE tbl_Is_Sirasi 
                    SET sira_No = sira_No - 1 
                    WHERE sira_No > @currentOrder AND sira_No <= @newOrder;
                ";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@newOrder", newOrder);
                            cmd.Parameters.AddWithValue("@currentOrder", currentOrder);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // İş sırasını yeni sıraya taşı
                    string updateJobQuery = "UPDATE tbl_Is_Sirasi SET sira_No = @newOrder WHERE is_ID = @jobId";
                    using (SqlCommand cmd = new SqlCommand(updateJobQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@newOrder", newOrder);
                        cmd.Parameters.AddWithValue("@jobId", jobId);
                        cmd.ExecuteNonQuery();
                    }
                }

                // DataGridView'i yenile
                load_Grid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
                Console.WriteLine("HATA ==>> " + ex.Message);
                throw;
            }
        }

        // Drag and Drop işlemleri
        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = dataGridView1.PointToClient(new Point(e.X, e.Y));
            int targetRowIndex = dataGridView1.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (draggedRowIndex >= 0 && targetRowIndex >= 0 && draggedRowIndex != targetRowIndex)
            {
                int draggedJobID = (int)dataGridView1.Rows[draggedRowIndex].Cells["İş ID"].Value;

                // Yeni sıra numarasını hesapla
                int newOrder = (int)dataGridView1.Rows[targetRowIndex].Cells["Sıra No"].Value;

                // Sıraları güncelle
                UpdateJobOrder(draggedJobID, newOrder);
            }

            draggedRowIndex = -1;
            isDragging = false; // Sürükleme bitti
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            var hitTest = dataGridView1.HitTest(e.X, e.Y);
            if (hitTest.RowIndex >= 0)
            {
                draggedRowIndex = hitTest.RowIndex;
                isDragging = true; // Sürükleme başlatıldı
            }
        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dataGridView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedRowIndex >= 0)
            {
                if (e.Button == MouseButtons.Left)
                {
                    dataGridView1.DoDragDrop(dataGridView1.Rows[draggedRowIndex], DragDropEffects.Move);
                }
            }
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(DataGridViewRow)))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

    }
}
