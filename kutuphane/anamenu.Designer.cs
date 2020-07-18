namespace kutuphane
{
    partial class anamenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(anamenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.anaMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapEklemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapEklemeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapÖdünçVermeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.raporlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kitapListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.üyeListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ödünçtekiKitaplarınListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kullaniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yeniKullanıcıEklemeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hakkindaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cikis = new System.Windows.Forms.ToolStripMenuItem();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.iadesiYaklaşanlarVeGeçenlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaMenuToolStripMenuItem,
            this.raporlarToolStripMenuItem,
            this.kullaniciToolStripMenuItem,
            this.hakkindaToolStripMenuItem1,
            this.cikis});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1924, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // anaMenuToolStripMenuItem
            // 
            this.anaMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kitapEklemeToolStripMenuItem,
            this.kitapEklemeToolStripMenuItem1,
            this.kitapÖdünçVermeToolStripMenuItem,
            this.çıkışToolStripMenuItem,
            this.çıkışToolStripMenuItem2});
            this.anaMenuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.anaMenuToolStripMenuItem.Name = "anaMenuToolStripMenuItem";
            this.anaMenuToolStripMenuItem.Size = new System.Drawing.Size(101, 27);
            this.anaMenuToolStripMenuItem.Text = "Ana Menu";
            // 
            // kitapEklemeToolStripMenuItem
            // 
            this.kitapEklemeToolStripMenuItem.Image = global::kutuphane.Properties.Resources.people;
            this.kitapEklemeToolStripMenuItem.Name = "kitapEklemeToolStripMenuItem";
            this.kitapEklemeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.kitapEklemeToolStripMenuItem.Size = new System.Drawing.Size(252, 28);
            this.kitapEklemeToolStripMenuItem.Text = "Yeni Üye Kaydı";
            this.kitapEklemeToolStripMenuItem.Click += new System.EventHandler(this.kitapEklemeToolStripMenuItem_Click);
            // 
            // kitapEklemeToolStripMenuItem1
            // 
            this.kitapEklemeToolStripMenuItem1.Image = global::kutuphane.Properties.Resources.kitapekle;
            this.kitapEklemeToolStripMenuItem1.Name = "kitapEklemeToolStripMenuItem1";
            this.kitapEklemeToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.kitapEklemeToolStripMenuItem1.Size = new System.Drawing.Size(252, 28);
            this.kitapEklemeToolStripMenuItem1.Text = "Kitap Ekleme";
            this.kitapEklemeToolStripMenuItem1.Click += new System.EventHandler(this.kitapEklemeToolStripMenuItem1_Click);
            // 
            // kitapÖdünçVermeToolStripMenuItem
            // 
            this.kitapÖdünçVermeToolStripMenuItem.Image = global::kutuphane.Properties.Resources.kitapteslim;
            this.kitapÖdünçVermeToolStripMenuItem.Name = "kitapÖdünçVermeToolStripMenuItem";
            this.kitapÖdünçVermeToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.kitapÖdünçVermeToolStripMenuItem.Size = new System.Drawing.Size(252, 28);
            this.kitapÖdünçVermeToolStripMenuItem.Text = "Kitap Teslim Al/Ver";
            this.kitapÖdünçVermeToolStripMenuItem.Click += new System.EventHandler(this.kitapÖdünçVermeToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Image = global::kutuphane.Properties.Resources.kitapara;
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(252, 28);
            this.çıkışToolStripMenuItem.Text = "Kitap Arama";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // çıkışToolStripMenuItem2
            // 
            this.çıkışToolStripMenuItem2.Name = "çıkışToolStripMenuItem2";
            this.çıkışToolStripMenuItem2.Size = new System.Drawing.Size(252, 28);
            this.çıkışToolStripMenuItem2.Text = "Çıkış";
            // 
            // raporlarToolStripMenuItem
            // 
            this.raporlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kitapListesiToolStripMenuItem,
            this.üyeListesiToolStripMenuItem,
            this.ödünçtekiKitaplarınListesiToolStripMenuItem,
            this.iadesiYaklaşanlarVeGeçenlerToolStripMenuItem});
            this.raporlarToolStripMenuItem.Name = "raporlarToolStripMenuItem";
            this.raporlarToolStripMenuItem.Size = new System.Drawing.Size(86, 27);
            this.raporlarToolStripMenuItem.Text = "Raporlar";
            // 
            // kitapListesiToolStripMenuItem
            // 
            this.kitapListesiToolStripMenuItem.Name = "kitapListesiToolStripMenuItem";
            this.kitapListesiToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.kitapListesiToolStripMenuItem.Size = new System.Drawing.Size(334, 28);
            this.kitapListesiToolStripMenuItem.Text = "Kitap Listesi";
            this.kitapListesiToolStripMenuItem.Click += new System.EventHandler(this.kitapListesiToolStripMenuItem_Click);
            // 
            // üyeListesiToolStripMenuItem
            // 
            this.üyeListesiToolStripMenuItem.Name = "üyeListesiToolStripMenuItem";
            this.üyeListesiToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.üyeListesiToolStripMenuItem.Size = new System.Drawing.Size(334, 28);
            this.üyeListesiToolStripMenuItem.Text = "Üye Listesi";
            this.üyeListesiToolStripMenuItem.Click += new System.EventHandler(this.üyeListesiToolStripMenuItem_Click);
            // 
            // ödünçtekiKitaplarınListesiToolStripMenuItem
            // 
            this.ödünçtekiKitaplarınListesiToolStripMenuItem.Name = "ödünçtekiKitaplarınListesiToolStripMenuItem";
            this.ödünçtekiKitaplarınListesiToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.ödünçtekiKitaplarınListesiToolStripMenuItem.Size = new System.Drawing.Size(334, 28);
            this.ödünçtekiKitaplarınListesiToolStripMenuItem.Text = "Ödünç Kitapların Listesi";
            this.ödünçtekiKitaplarınListesiToolStripMenuItem.Click += new System.EventHandler(this.ödünçtekiKitaplarınListesiToolStripMenuItem_Click);
            // 
            // kullaniciToolStripMenuItem
            // 
            this.kullaniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.yeniKullanıcıEklemeToolStripMenuItem1});
            this.kullaniciToolStripMenuItem.Name = "kullaniciToolStripMenuItem";
            this.kullaniciToolStripMenuItem.Size = new System.Drawing.Size(153, 27);
            this.kullaniciToolStripMenuItem.Text = "Kullanıcı İşlemleri";
            this.kullaniciToolStripMenuItem.Click += new System.EventHandler(this.hakkındaToolStripMenuItem_Click);
            // 
            // yeniKullanıcıEklemeToolStripMenuItem1
            // 
            this.yeniKullanıcıEklemeToolStripMenuItem1.Image = global::kutuphane.Properties.Resources.kullaniciekle;
            this.yeniKullanıcıEklemeToolStripMenuItem1.Name = "yeniKullanıcıEklemeToolStripMenuItem1";
            this.yeniKullanıcıEklemeToolStripMenuItem1.Size = new System.Drawing.Size(239, 28);
            this.yeniKullanıcıEklemeToolStripMenuItem1.Text = "Yeni Kullanıcı Ekleme";
            this.yeniKullanıcıEklemeToolStripMenuItem1.Click += new System.EventHandler(this.yeniKullanıcıEklemeToolStripMenuItem1_Click);
            // 
            // hakkindaToolStripMenuItem1
            // 
            this.hakkindaToolStripMenuItem1.Name = "hakkindaToolStripMenuItem1";
            this.hakkindaToolStripMenuItem1.Size = new System.Drawing.Size(92, 27);
            this.hakkindaToolStripMenuItem1.Text = "Hakkında";
            this.hakkindaToolStripMenuItem1.Click += new System.EventHandler(this.çıkışToolStripMenuItem1_Click);
            // 
            // cikis
            // 
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(56, 27);
            this.cikis.Text = "Çıkış";
            this.cikis.Click += new System.EventHandler(this.kullanıcıİşlemleriToolStripMenuItem_Click);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1924, 1017);
            this.shapeContainer1.TabIndex = 10;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lineShape1.BorderWidth = 3;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 175;
            this.lineShape1.X2 = 175;
            this.lineShape1.Y1 = 0;
            this.lineShape1.Y2 = 1100;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Location = new System.Drawing.Point(3, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 1685);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::kutuphane.Properties.Resources.kitapara;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 70);
            this.button1.TabIndex = 17;
            this.button1.Text = "Üye Kitap Raporu";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Image = global::kutuphane.Properties.Resources.oturum;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(1, 449);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(200, 70);
            this.button6.TabIndex = 16;
            this.button6.Text = "Kullanıcı Değiştir";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::kutuphane.Properties.Resources.yeniuye;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(0, 72);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 70);
            this.button4.TabIndex = 8;
            this.button4.Text = "Yeni Üye Kaydı    ";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::kutuphane.Properties.Resources.cikis;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(0, 546);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(200, 70);
            this.button5.TabIndex = 11;
            this.button5.Text = "Çıkış";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::kutuphane.Properties.Resources.kitapteslim;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(0, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 70);
            this.button2.TabIndex = 5;
            this.button2.Text = "Kitap Teslim Al/Ver";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Image = global::kutuphane.Properties.Resources.kitapara;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(1, 266);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 70);
            this.button3.TabIndex = 6;
            this.button3.Text = "Kitap Arama";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // iadesiYaklaşanlarVeGeçenlerToolStripMenuItem
            // 
            this.iadesiYaklaşanlarVeGeçenlerToolStripMenuItem.Name = "iadesiYaklaşanlarVeGeçenlerToolStripMenuItem";
            this.iadesiYaklaşanlarVeGeçenlerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.iadesiYaklaşanlarVeGeçenlerToolStripMenuItem.Size = new System.Drawing.Size(334, 28);
            this.iadesiYaklaşanlarVeGeçenlerToolStripMenuItem.Text = "İadesi Yaklaşanlar ve Geçenler";
            this.iadesiYaklaşanlarVeGeçenlerToolStripMenuItem.Click += new System.EventHandler(this.iadesiYaklaşanlarVeGeçenlerToolStripMenuItem_Click);
            // 
            // anamenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1924, 1017);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.shapeContainer1);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "anamenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Ana Menu";
            this.Load += new System.EventHandler(this.anamenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem anaMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitapEklemeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kitapEklemeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kitapÖdünçVermeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem raporlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem kitapListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem üyeListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kullaniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hakkindaToolStripMenuItem1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem cikis;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStripMenuItem yeniKullanıcıEklemeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ödünçtekiKitaplarınListesiToolStripMenuItem;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem iadesiYaklaşanlarVeGeçenlerToolStripMenuItem;
    }
}