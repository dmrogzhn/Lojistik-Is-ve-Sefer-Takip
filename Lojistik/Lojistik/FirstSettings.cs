using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Lojistik
{
    public partial class FirstSettings : MetroSetForm
    {
        public FirstSettings()
        {
            InitializeComponent();
        }

        private void btnVTKaydet_Click(object sender, EventArgs e)
        {
            string serverName = txtServerName.Text;
            string databaseName = txtDatabaseName.Text;
            string userID = txtUserID.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(serverName) || string.IsNullOrWhiteSpace(databaseName) || string.IsNullOrWhiteSpace(userID) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Bilgileri eksiksiz ve boşluksuz giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string connectionString = $"Server={serverName};Database={databaseName};User Id={userID};Password={password};";

                File.WriteAllText("connection.txt", connectionString);


                MessageBox.Show("SQL bağlantısı kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
        }

        private void btnCihazKaydet_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            string port = txtPort.Text.Trim();

            if (string.IsNullOrWhiteSpace(ip) || string.IsNullOrWhiteSpace(port))
            {
                MessageBox.Show("IP ve Port bilgilerini eksiksiz giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var serverInfo = new
            {
                IP = ip,
                Port = port
            };

            // JSON formatına dönüştür
            string json = JsonConvert.SerializeObject(serverInfo, Formatting.Indented);

            // JSON dosyasını kaydet
            try
            {
                File.WriteAllText("server_config.json", json);
                MessageBox.Show("IP ve Port bilgileri başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Dosya kaydedilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            string connectionString = File.ReadAllText("connection.txt");

            MessageBox.Show(connectionString);

            // Bağlantıyı test et
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Bağlantı başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"SQL Hatası: {sqlEx.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bağlantı başarısız: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
