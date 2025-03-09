namespace Lojistik
{
    partial class yetkiKontrol
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtKullaniciAdi = new MetroSet_UI.Controls.MetroSetTextBox();
            this.txtSifre = new MetroSet_UI.Controls.MetroSetTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBreak = new MetroSet_UI.Controls.MetroSetButton();
            this.SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.AutoCompleteCustomSource = null;
            this.txtKullaniciAdi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtKullaniciAdi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtKullaniciAdi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtKullaniciAdi.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtKullaniciAdi.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtKullaniciAdi.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtKullaniciAdi.Image = null;
            this.txtKullaniciAdi.IsDerivedStyle = true;
            this.txtKullaniciAdi.Lines = null;
            this.txtKullaniciAdi.Location = new System.Drawing.Point(62, 116);
            this.txtKullaniciAdi.MaxLength = 32767;
            this.txtKullaniciAdi.Multiline = false;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.ReadOnly = false;
            this.txtKullaniciAdi.Size = new System.Drawing.Size(135, 39);
            this.txtKullaniciAdi.Style = MetroSet_UI.Enums.Style.Light;
            this.txtKullaniciAdi.StyleManager = null;
            this.txtKullaniciAdi.TabIndex = 2;
            this.txtKullaniciAdi.Text = "Adınız";
            this.txtKullaniciAdi.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtKullaniciAdi.ThemeAuthor = "Narwin";
            this.txtKullaniciAdi.ThemeName = "MetroLite";
            this.txtKullaniciAdi.UseSystemPasswordChar = false;
            this.txtKullaniciAdi.WatermarkText = "";
            this.txtKullaniciAdi.Click += new System.EventHandler(this.metroSetTextBox1_Click);
            // 
            // txtSifre
            // 
            this.txtSifre.AutoCompleteCustomSource = null;
            this.txtSifre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSifre.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSifre.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSifre.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSifre.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSifre.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txtSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSifre.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtSifre.Image = null;
            this.txtSifre.IsDerivedStyle = true;
            this.txtSifre.Lines = null;
            this.txtSifre.Location = new System.Drawing.Point(62, 178);
            this.txtSifre.MaxLength = 32767;
            this.txtSifre.Multiline = false;
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.ReadOnly = false;
            this.txtSifre.Size = new System.Drawing.Size(135, 35);
            this.txtSifre.Style = MetroSet_UI.Enums.Style.Light;
            this.txtSifre.StyleManager = null;
            this.txtSifre.TabIndex = 3;
            this.txtSifre.Text = "Şifreniz";
            this.txtSifre.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSifre.ThemeAuthor = "Narwin";
            this.txtSifre.ThemeName = "MetroLite";
            this.txtSifre.UseSystemPasswordChar = false;
            this.txtSifre.WatermarkText = "";
            this.txtSifre.Click += new System.EventHandler(this.metroSetTextBox2_Click);
            this.txtSifre.Enter += new System.EventHandler(this.txtSifre_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(107, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 39);
            this.button1.TabIndex = 4;
            this.button1.Text = "Giriş";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBreak
            // 
            this.btnBreak.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBreak.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBreak.DisabledForeColor = System.Drawing.Color.Gray;
            this.btnBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBreak.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnBreak.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btnBreak.HoverTextColor = System.Drawing.Color.White;
            this.btnBreak.IsDerivedStyle = true;
            this.btnBreak.Location = new System.Drawing.Point(186, 8);
            this.btnBreak.Name = "btnBreak";
            this.btnBreak.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBreak.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btnBreak.NormalTextColor = System.Drawing.Color.White;
            this.btnBreak.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnBreak.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btnBreak.PressTextColor = System.Drawing.Color.White;
            this.btnBreak.Size = new System.Drawing.Size(75, 23);
            this.btnBreak.Style = MetroSet_UI.Enums.Style.Light;
            this.btnBreak.StyleManager = null;
            this.btnBreak.TabIndex = 22;
            this.btnBreak.Text = "X";
            this.btnBreak.ThemeAuthor = "Narwin";
            this.btnBreak.ThemeName = "MetroLite";
            this.btnBreak.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // yetkiKontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 374);
            this.Controls.Add(this.btnBreak);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Name = "yetkiKontrol";
            this.Padding = new System.Windows.Forms.Padding(2, 70, 2, 2);
            this.ShowBorder = true;
            this.ShowHeader = true;
            this.ShowLeftRect = false;
            this.Text = "YETKİLİ GİRİŞ";
            this.TextColor = System.Drawing.Color.White;
            this.ResumeLayout(false);

        }

        #endregion
        private MetroSet_UI.Controls.MetroSetTextBox txtKullaniciAdi;
        private MetroSet_UI.Controls.MetroSetTextBox txtSifre;
        private System.Windows.Forms.Button button1;
        private MetroSet_UI.Controls.MetroSetButton btnBreak;
    }
}