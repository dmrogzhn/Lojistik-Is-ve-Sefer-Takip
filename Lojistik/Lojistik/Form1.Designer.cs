namespace Lojistik
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSaat = new MetroSet_UI.Controls.MetroSetTextBox();
            this.txtTarih = new MetroSet_UI.Controls.MetroSetTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSettings2 = new MetroFramework.Controls.MetroButton();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.metroSetButton1 = new MetroSet_UI.Controls.MetroSetButton();
            this.btnBreak = new MetroSet_UI.Controls.MetroSetButton();
            this.btn_MinMax = new MetroSet_UI.Controls.MetroSetButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.ForeColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 43);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.950249F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.04975F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1196, 536);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSaat);
            this.panel2.Controls.Add(this.txtTarih);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(317, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(876, 47);
            this.panel2.TabIndex = 20;
            // 
            // txtSaat
            // 
            this.txtSaat.AutoCompleteCustomSource = null;
            this.txtSaat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSaat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSaat.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSaat.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtSaat.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtSaat.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txtSaat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSaat.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtSaat.Image = null;
            this.txtSaat.IsDerivedStyle = true;
            this.txtSaat.Lines = null;
            this.txtSaat.Location = new System.Drawing.Point(698, 3);
            this.txtSaat.MaxLength = 32767;
            this.txtSaat.Multiline = false;
            this.txtSaat.Name = "txtSaat";
            this.txtSaat.ReadOnly = false;
            this.txtSaat.Size = new System.Drawing.Size(175, 32);
            this.txtSaat.Style = MetroSet_UI.Enums.Style.Light;
            this.txtSaat.StyleManager = null;
            this.txtSaat.TabIndex = 13;
            this.txtSaat.Text = "saat";
            this.txtSaat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSaat.ThemeAuthor = "Narwin";
            this.txtSaat.ThemeName = "MetroLite";
            this.txtSaat.UseSystemPasswordChar = false;
            this.txtSaat.WatermarkText = "";
            // 
            // txtTarih
            // 
            this.txtTarih.AutoCompleteCustomSource = null;
            this.txtTarih.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTarih.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTarih.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtTarih.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtTarih.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(155)))), ((int)(((byte)(155)))));
            this.txtTarih.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.txtTarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTarih.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtTarih.Image = null;
            this.txtTarih.IsDerivedStyle = true;
            this.txtTarih.Lines = null;
            this.txtTarih.Location = new System.Drawing.Point(522, 3);
            this.txtTarih.MaxLength = 32767;
            this.txtTarih.Multiline = false;
            this.txtTarih.Name = "txtTarih";
            this.txtTarih.ReadOnly = false;
            this.txtTarih.Size = new System.Drawing.Size(170, 32);
            this.txtTarih.Style = MetroSet_UI.Enums.Style.Light;
            this.txtTarih.StyleManager = null;
            this.txtTarih.TabIndex = 12;
            this.txtTarih.Text = "tarih";
            this.txtTarih.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTarih.ThemeAuthor = "Narwin";
            this.txtTarih.ThemeName = "MetroLite";
            this.txtTarih.UseSystemPasswordChar = false;
            this.txtTarih.WatermarkText = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(317, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(876, 477);
            this.panel3.TabIndex = 22;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(876, 477);
            this.flowLayoutPanel1.TabIndex = 17;
            this.flowLayoutPanel1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(876, 477);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnSettings2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 47);
            this.panel1.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(225, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 41);
            this.button2.TabIndex = 19;
            this.button2.Text = "Geri";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSettings2
            // 
            this.btnSettings2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSettings2.BackgroundImage")));
            this.btnSettings2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings2.Location = new System.Drawing.Point(163, 3);
            this.btnSettings2.Name = "btnSettings2";
            this.btnSettings2.Size = new System.Drawing.Size(48, 41);
            this.btnSettings2.TabIndex = 18;
            this.btnSettings2.UseSelectable = true;
            this.btnSettings2.Click += new System.EventHandler(this.btnSettings2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 41);
            this.button1.TabIndex = 15;
            this.button1.Text = "Menü";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MediumTurquoise;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(3, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(308, 477);
            this.dataGridView1.TabIndex = 21;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // metroSetButton1
            // 
            this.metroSetButton1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.DisabledForeColor = System.Drawing.Color.Gray;
            this.metroSetButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.metroSetButton1.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.metroSetButton1.HoverTextColor = System.Drawing.Color.White;
            this.metroSetButton1.IsDerivedStyle = true;
            this.metroSetButton1.Location = new System.Drawing.Point(955, 5);
            this.metroSetButton1.Name = "metroSetButton1";
            this.metroSetButton1.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.metroSetButton1.NormalTextColor = System.Drawing.Color.White;
            this.metroSetButton1.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton1.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.metroSetButton1.PressTextColor = System.Drawing.Color.White;
            this.metroSetButton1.Size = new System.Drawing.Size(75, 23);
            this.metroSetButton1.Style = MetroSet_UI.Enums.Style.Light;
            this.metroSetButton1.StyleManager = null;
            this.metroSetButton1.TabIndex = 21;
            this.metroSetButton1.Text = "-";
            this.metroSetButton1.ThemeAuthor = "Narwin";
            this.metroSetButton1.ThemeName = "MetroLite";
            this.metroSetButton1.Click += new System.EventHandler(this.metroSetButton1_Click);
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
            this.btnBreak.Location = new System.Drawing.Point(1109, 5);
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
            this.btnBreak.TabIndex = 20;
            this.btnBreak.Text = "X";
            this.btnBreak.ThemeAuthor = "Narwin";
            this.btnBreak.ThemeName = "MetroLite";
            this.btnBreak.Click += new System.EventHandler(this.btnBreak_Click);
            // 
            // btn_MinMax
            // 
            this.btn_MinMax.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_MinMax.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_MinMax.DisabledForeColor = System.Drawing.Color.Gray;
            this.btn_MinMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_MinMax.HoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_MinMax.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            this.btn_MinMax.HoverTextColor = System.Drawing.Color.White;
            this.btn_MinMax.IsDerivedStyle = true;
            this.btn_MinMax.Location = new System.Drawing.Point(1036, 5);
            this.btn_MinMax.Name = "btn_MinMax";
            this.btn_MinMax.NormalBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_MinMax.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(177)))), ((int)(((byte)(225)))));
            this.btn_MinMax.NormalTextColor = System.Drawing.Color.White;
            this.btn_MinMax.PressBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_MinMax.PressColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(147)))), ((int)(((byte)(195)))));
            this.btn_MinMax.PressTextColor = System.Drawing.Color.White;
            this.btn_MinMax.Size = new System.Drawing.Size(75, 23);
            this.btn_MinMax.Style = MetroSet_UI.Enums.Style.Light;
            this.btn_MinMax.StyleManager = null;
            this.btn_MinMax.TabIndex = 22;
            this.btn_MinMax.Text = "[ ]";
            this.btn_MinMax.ThemeAuthor = "Narwin";
            this.btn_MinMax.ThemeName = "MetroLite";
            this.btn_MinMax.Click += new System.EventHandler(this.btn_MinMax_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1206, 584);
            this.Controls.Add(this.btn_MinMax);
            this.Controls.Add(this.metroSetButton1);
            this.Controls.Add(this.btnBreak);
            this.Controls.Add(this.tableLayoutPanel1);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(2, 70, 2, 2);
            this.ShowBorder = true;
            this.ShowHeader = true;
            this.ShowLeftRect = false;
            this.Text = "LOJİSTİK";
            this.TextColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private MetroFramework.Controls.MetroButton btnSettings2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private MetroSet_UI.Controls.MetroSetTextBox txtSaat;
        private MetroSet_UI.Controls.MetroSetTextBox txtTarih;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.DataGridView dataGridView1;
        private MetroSet_UI.Controls.MetroSetButton metroSetButton1;
        private MetroSet_UI.Controls.MetroSetButton btnBreak;
        private MetroSet_UI.Controls.MetroSetButton btn_MinMax;
        private System.Windows.Forms.Button button2;
    }
}

