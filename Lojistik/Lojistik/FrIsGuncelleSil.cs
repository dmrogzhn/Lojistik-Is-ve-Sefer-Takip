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
    public partial class FrIsGuncelleSil : MetroSetForm
    {
        public FrIsGuncelleSil()
        {
            InitializeComponent();
            CustomizeDataGridView();
            load_Grid();
            butonRengi();

            btnBreak.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCikisBirimi.Focus();
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
            string query = "select i.is_ID as 'ID', i.is_Cikis_Birimi as 'Çıkış Birimi', i.is_Varis_Birimi as 'Varış Birimi', i.tasinacak_Yuk as 'Taşınacak Yük', i.is_Alindi_Mi as 'İş Alınma' ,i.is_Olusturan_Yetkili_ID as 'Oluşturan Yetkili', i.guncelleyen_ID as 'Güncelleyen ID', i.guncellenme_Tarihi as 'Güncellenme Tarihi' from tbl_Is i where is_Alindi_Mi = 'Alındı' or is_Alindi_Mi = 'Hayır'";

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

        private string isDurum; // bu değişkeni iş durumunu kontrol edebilmek için global oluşturduk dgw ye tıklanınca iş durumunu bu değişkene atayarak silme işleminde kontrol edebildik
        private void btnSil_Click(object sender, EventArgs e)
        {// Kontrol: "İş Alınma" sütunu "Alındı" ise silme işlemi yapılmasın
            if (isDurum == "Alındı")
            {
                MessageBox.Show("Seferdeki iş silinemez");
                return; // Silme işlemlerini atla
            }

            int yetkiliID = int.Parse(yetkiKontrol.yetkiDerecesi);
            int isID = string.IsNullOrWhiteSpace(txtIsID.Text.Trim()) ? 0 : Convert.ToInt32(txtIsID.Text.Trim());
            string cikisBirimi = txtCikisBirimi.Text.Trim();
            string varisBirimi = txtVarisBirimi.Text.Trim();
            string tasinacakYuk = txtTasinacakYuk.Text.Trim();

            string connectionString = baglanti.baglantiAdresi;
            string query = "delete from tbl_Is where is_ID = @isID";
            string query2 = "delete from tbl_Is_Sirasi where is_ID = @isID2";

            try
            {
                if (isID != 0)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query2, connection))
                        {
                            command.Parameters.AddWithValue("@isID2", isID);

                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected <= 0)
                            {
                                MessageBox.Show("İş Sırası Silme İşleminde Hata");
                            }
                        }

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@isID", isID);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected <= 0)
                            {
                                MessageBox.Show("İş Silme İşleminde Başarılı");
                            }

                            MessageBox.Show("Silme İşlemi Başarılı");
                            load_Grid();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen iş seçin");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA ==>> " + ex.Message);
                MessageBox.Show("Hata: " + ex.Message);
                throw;
            }


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "update tbl_Is set is_Cikis_Birimi = @cikisBirimi, is_Varis_Birimi = @varisBirimi, tasinacak_Yuk = @tasinacakYuk, guncelleyen_ID = @yetkiliID, guncellenme_Tarihi = @date where is_ID = @isID ";

            int yetkiliID = int.Parse(yetkiKontrol.yetkiDerecesi);
            int isID = string.IsNullOrWhiteSpace(txtIsID.Text.Trim()) ? 0 : Convert.ToInt32(txtIsID.Text.Trim());
            string cikisBirimi = txtCikisBirimi.Text.Trim();
            string varisBirimi = txtVarisBirimi.Text.Trim();
            string tasinacakYuk = txtTasinacakYuk.Text.Trim();
            DateTime date = DateTime.Today;

            try
            {
                if (isID != 0)
                {

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("isID", isID);
                            command.Parameters.AddWithValue("@cikisBirimi", cikisBirimi);
                            command.Parameters.AddWithValue("@varisBirimi", varisBirimi);
                            command.Parameters.AddWithValue("@tasinacakYuk", tasinacakYuk);
                            command.Parameters.AddWithValue("@yetkiliID", yetkiliID);
                            command.Parameters.AddWithValue("@date", date);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected <= 0)
                            {
                                MessageBox.Show("Güncelleme Başarılı");
                            }
                            else
                            {
                                MessageBox.Show("Güncelleme işlemi gerçekleşmedi. Kriterleri kontrol ediniz.");
                            }

                            load_Grid();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen bir iş seçiniz");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA ==>> " + ex.Message);
                MessageBox.Show("Hata: " + ex.Message);
                throw;
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtCikisBirimi.Text = row.Cells["Çıkış Birimi"].Value.ToString();
                txtIsID.Text = row.Cells["ID"].Value.ToString();
                txtTasinacakYuk.Text = row.Cells["Taşınacak Yük"].Value.ToString();
                txtVarisBirimi.Text = row.Cells["Varış Birimi"].Value.ToString();
                isDurum = row.Cells["İş Alınma"].Value.ToString().Trim();
            }
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
