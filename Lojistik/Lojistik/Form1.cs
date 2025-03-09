using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    public partial class Form1 : MetroSetForm
    {
        private soforDonusu soforDonusu; // burada tanımlama yaptık ki form açık olduğu sürece soforDonusu sınıfının construstor ı aktif kalsın ve kart okuma işlemi sürekli çalışsın

        public Form1()
        {
            InitializeComponent();
            Tarih();
            timer1.Start();
            tools_Settings();
            //flowLayoutPanel1.Visible = true;
            txtSaat.IsDerivedStyle = false;
            soforDonusu = new soforDonusu();
        }

        public void tools_Settings()
        {
            // table paneli her kaöşeye yerleştirmiş olduk
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right;

            //butonu sol üst köşeye yerleştirdik form ne kadar büyürse büyüsün hep sol üst köşede kalacak
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // saat ve tarih de hep sağ üst köşede kalacak
            txtSaat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtTarih.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // kapatma ve gizleme butonları için
            btnBreak.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            metroSetButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right; 

            btn_MinMax.Anchor = AnchorStyles.Top | AnchorStyles.Right;


        }// ekran büyüdükçe araçlar yerlerinden şaşmasın boyutlarda değişim olmasın diye

        private void Tarih()
        {
            DateTime dateTime = DateTime.Today;
            txtTarih.Text = dateTime.ToString("d");// içine koyduğumuz d harfi sadece tarih olarak almamızı sağlar yoksa saat saniye vs de işin içine giriyor
        }  // tarihi aldığımız yer


        

        public void formReset()//formu en baştaki orijinal haline getirir
        {
            dataGridView1.Visible = false;
            pictureBox1.Visible = true;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Visible = false; // Gerekirse görünürlüğünü kapat
            button2.Visible = false;

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

        private void Form1_Load(object sender, EventArgs e)
        {        

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            pictureBox1.Visible = false;
            button2.Visible = true;

            is_Getir is_Getir = new is_Getir(this);
            sofor_Getir sofor_Getir = new sofor_Getir(this);            
            is_Getir.LoadAddressTiles();
            sofor_Getir.load_Grid();

            CustomizeDataGridView();
        }
        
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            txtSaat.Text = dateTime.ToString("T"); // buradaki T de saati saniye ile alır. eğer küçük t olsaydı sadece saati gösterirdi
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            // X butonuna basınca uygulamayı kapatsın diye
            Application.Exit();
        }

        private void metroSetButton1_Click(object sender, EventArgs e)// formu aşağı indirme
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public string soforAdi;
        public string secilen_Sofor_ID;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            soforAdi = dataGridView1.SelectedCells[0].Value.ToString();
            secilen_Sofor_ID = dataGridView1.Rows[e.RowIndex].Cells["sofor_ID"].Value.ToString();            
            // Eğer tıklama geçerli bir satıra yapıldıysa
            if (e.RowIndex >= 0)
            {
                flowLayoutPanel1.Visible = true; // FlowLayoutPanel görünür hale getir
            }
        }// şoför ismine tıkladıktan sonra ne olacak 

        private void btn_MinMax_Click(object sender, EventArgs e)
        {
            // Eğer form zaten tam ekran modundaysa, normal modda aç
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;  // Normal mod
                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 20, FontStyle.Italic);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;  // Tam ekran moduna geçir
                dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 22, FontStyle.Italic);
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formReset();
        }// geri tuşuna basınca olacak olay

        private void btnSettings2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            yetkiKontrol yetkiKontrol = new yetkiKontrol();
            yetkiKontrol.Show();

        }// ayarlar butonu
    }
}
