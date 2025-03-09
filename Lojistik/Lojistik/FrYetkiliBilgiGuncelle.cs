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
    public partial class FrYetkiliBilgiGuncelle : MetroSetForm
    {
        // BU FORM SAYFASI YETKİLİNİN KULLANICI ADI VE ŞİFRESİNİ GÜNCELLEMESİ İÇİN OLUŞTURULMUŞTUR

        public FrYetkiliBilgiGuncelle()
        {
            InitializeComponent();
            btnBreak.Anchor = AnchorStyles.Right | AnchorStyles.Top;
        }

        private void btnBreak_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrYetkiliBilgiGuncelle_Load(object sender, EventArgs e)
        {

        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {            
            int yetkiliID = yetkiKontrol.yetkiliID;

            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            string connectionString = baglanti.baglantiAdresi;
            string query1 = "update tbl_Yetkili set kullaniciAdi = @kullaniciAdi where yetkili_ID = @yetkiliID ";
            string query2 = "update tbl_Yetkili set yetkili_Sifre = @sifre  where yetkili_ID = @yetkiliID ";
            string query3 = "update tbl_Yetkili set kullaniciAdi = @kullaniciAdi, yetkili_Sifre = @sifre  where yetkili_ID = @yetkiliID ";

            try
            {
                using (SqlConnection connection =  new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (!string.IsNullOrEmpty(kullaniciAdi) && !string.IsNullOrEmpty(sifre))
                    {
                        using (SqlCommand command = new SqlCommand(query3,connection))
                        {
                            command.Parameters.AddWithValue("@yetkiliID", yetkiliID);
                            command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                            command.Parameters.AddWithValue("@sifre", sifre);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Güncelleme başarılı!");
                                txtKullaniciAdi.Text = "";
                                txtSifre.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Güncellenecek kayıt bulunamadı.");
                            }
                        }
                    }
                    else if (string.IsNullOrEmpty(kullaniciAdi) && !string.IsNullOrEmpty(sifre))
                    {
                        using (SqlCommand command = new SqlCommand(query2,connection))
                        {
                            command.Parameters.AddWithValue("@yetkiliID", yetkiliID);
                            command.Parameters.AddWithValue("@sifre", sifre);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Güncelleme başarılı!");
                                txtKullaniciAdi.Text = "";
                                txtSifre.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Güncellenecek kayıt bulunamadı.");
                            }
                        }
                    }
                    else if (string.IsNullOrEmpty(sifre) && !string.IsNullOrEmpty(kullaniciAdi))
                    {
                        using (SqlCommand command = new SqlCommand(query1,connection))
                        {
                            command.Parameters.AddWithValue("@yetkiliID", yetkiliID);
                            command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Güncelleme başarılı!");
                                txtKullaniciAdi.Text = "";
                                txtSifre.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Güncellenecek kayıt bulunamadı.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lütfen Gerekli Alanları Doldurunuz!");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HATA ==>> " + ex.Message);
                MessageBox.Show("Hata: " + ex.Message);
                throw;
            }


        }
    }
}
