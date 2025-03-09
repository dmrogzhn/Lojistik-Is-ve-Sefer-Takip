using MetroSet_UI.Controls;
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
    public partial class SettingsForm : MetroSetForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            //yetkiDereceKontrol();
        }    
        
        
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            toolsSettings();
        }

       private void yetkiDereceKontrol()
        {
            int yetkiDerecesi = Convert.ToInt32(yetkiKontrol.yetkiDerecesi);

            if (yetkiDerecesi == 1)
            {
                btnIsSira.Visible = false;
                btnIsEkle.Visible = false;
            }
        }


        public void toolsSettings()
        {
            btnBreak.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        }

        string sayfaKontrol = "İlk Ayar";
        private void btnBreak_Click(object sender, EventArgs e)
        {
            if (sayfaKontrol == FirstForm.sayfaKontrol)
            {
                FirstForm firstForm = new FirstForm();
                firstForm.Show();
                this.Close();
            }
            else
            {
                this.Close();
                Form1 fr = new Form1();
                fr.Show();
            }
            
        }

        private void btnBaglanti_Click(object sender, EventArgs e)
        {
            FirstSettings firstSettings = new FirstSettings();
            firstSettings.Show();
        }

        private void btnSofEkle_Click(object sender, EventArgs e)
        {
            
            try
            {
                FrSoforEkle ekle = new FrSoforEkle();
                ekle.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnSofGuncelleSil_Click(object sender, EventArgs e)
        {
            FrSofGuncelleSil frSofGuncelleSil = new FrSofGuncelleSil();
            frSofGuncelleSil.Show();
        }

        private void btnIsEkle_Click(object sender, EventArgs e)
        {
            FrIsEkle frIsEkle = new FrIsEkle();
            frIsEkle.Show();
        }

        private void btnSofTumListe_Click(object sender, EventArgs e)
        {
            FrSoforListesi soforListesi = new FrSoforListesi();
            soforListesi.Show();
        }

        private void btnIsTumListe_Click(object sender, EventArgs e)
        {
            FrIsListesi ısListesi = new FrIsListesi();
            ısListesi.Show();
        }

        private void btnIsSil_Click(object sender, EventArgs e)
        {
            FrIsGuncelleSil frIsGuncelle = new FrIsGuncelleSil();
            frIsGuncelle.Show();
        }

        private void btnBaglanti_Click_1(object sender, EventArgs e)
        {
            FirstSettings firstSettings = new FirstSettings();
            firstSettings.Show();
        }

        private void btnYetkiliEkle_Click(object sender, EventArgs e)
        {
            FrYetkiliEkle frYetkiliEkle = new FrYetkiliEkle();
            frYetkiliEkle.Show();
        }

        private void btnYekiliGuncelleSil_Click(object sender, EventArgs e)
        {
            FrYetkiliGuncelleSil frYetkiliGuncelleSil = new FrYetkiliGuncelleSil();
            frYetkiliGuncelleSil.Show();
        }

        private void btnYetkiliBilgiGuncelle_Click(object sender, EventArgs e)
        {
            FrYetkiliBilgiGuncelle frYetkiliBilgiGuncelle = new FrYetkiliBilgiGuncelle();
            frYetkiliBilgiGuncelle.Show();
        }

        private void btnIsSira_Click(object sender, EventArgs e)
        {
            FrIsSiraDegistir frIsSiraDegistir = new FrIsSiraDegistir();
            frIsSiraDegistir.Show();
        }

        private void btnSofSira_Click(object sender, EventArgs e)
        {
            FrSoforSiraDegistir siraDegistir = new FrSoforSiraDegistir();
            siraDegistir.Show();
        }
    }
}
