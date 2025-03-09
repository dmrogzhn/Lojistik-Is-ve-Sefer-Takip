using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lojistik
{
    class sofor_Getir
    {
        Form1 fr;

        public sofor_Getir(Form1 form)
        {
            this.fr = form;
        }
        

        public void load_Grid()
        {
            string connectionString = baglanti.baglantiAdresi;
            string query = "select sofor_Ad_Soyad as 'Şoförler',sofor_ID from bekleyen_Sofor order by sira_No";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // DataGridView'e veri aktarımı
                    fr.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    fr.dataGridView1.DataSource = dataTable;

                    fr.dataGridView1.Columns["sofor_ID"].Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
                
            }
        }

        
    }
    
}
