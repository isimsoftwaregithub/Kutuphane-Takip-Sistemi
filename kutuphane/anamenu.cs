using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace kutuphane
{
    public partial class anamenu : Form
    {
        public anamenu()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool durum = false;
            kitapara frm = new kitapara();
            foreach (Form eleman in this.MdiChildren)
            {
                if (eleman.Text == frm.Text)
                {
                    durum = true;
                    eleman.Activate();
                    MessageBox.Show("Yeni bir form açmak için açık olan formu kapatınız.!");
                }
            }
            if (durum == false)
            {
                frm.MdiParent = this;
                frm.Show();
            }

        }
      

       public static void baglanti_fonksiyonu()
        {
            SqlConnection baglanti = new SqlConnection();
            baglanti.ConnectionString = "Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true";
            baglanti.Close();
            baglanti.Open();
         }

        private void anamenu_Load(object sender, EventArgs e)
       {
           
          
            //   baglanti_fonksiyonu();
           giris degisken = new giris();
            string yetki =giris.yetki;
             if (yetki== "1111")
            {
                yeniKullanıcıEklemeToolStripMenuItem1.Enabled = true;
                
            }
            else
            {
                yeniKullanıcıEklemeToolStripMenuItem1.Enabled = false;
                
            }
            if (yetki.Substring(0, 1).ToString() == "0")
            {
                button4.Enabled = false;
                kitapEklemeToolStripMenuItem.Enabled = false;
                kitapEklemeToolStripMenuItem1.Enabled = false;
             }
            else
            {
                button4.Enabled = true;
                kitapEklemeToolStripMenuItem.Enabled = true;
                kitapEklemeToolStripMenuItem1.Enabled = true;
            }
            if (yetki.Substring(1, 1).ToString() == "0")
            {
                button2.Enabled = false;
                kitapÖdünçVermeToolStripMenuItem.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
                kitapÖdünçVermeToolStripMenuItem.Enabled = true;
            }
            if (yetki.Substring(2, 1).ToString() == "0")
            {
                button3.Enabled = false;
                çıkışToolStripMenuItem.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
                çıkışToolStripMenuItem.Enabled = true;
            }
            if (yetki.Substring(3, 1).ToString() == "0")
               raporlarToolStripMenuItem.Enabled = false;
            else
              raporlarToolStripMenuItem.Enabled = true;
         
        }

        private void kitapEklemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool durum = false;
            yeniuyekaydi uyekaydi = new yeniuyekaydi();
            foreach(Form eleman in this.MdiChildren)
            {
                if (eleman.Text == uyekaydi.Text)
                {
                    durum = true;
                    eleman.Activate();
                    MessageBox.Show("Yeni bir form açmak için açık olan formu kapatınız.!");
                }
            }
            if (durum == false)
            {
                uyekaydi.MdiParent = this;
                uyekaydi.Show();
            }
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kitapEklemeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool durum = false;
            kitapekle frm = new kitapekle ();
           
            foreach (Form eleman in this.MdiChildren)
            {
                if (eleman.Text ==frm.Text)
                {
                    durum = true;
                    eleman.Activate();
                    MessageBox.Show("Yeni bir form açmak için açık olan formu kapatınız.!");
                }
            }
            if (durum == false)
            {
                frm.MdiParent = this;
                frm.Show();
            }
            
           
                
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void kullanıcıİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programı kapatmak istiyormusunuz?", "Çıkış", MessageBoxButtons.YesNo) == DialogResult.Yes)
            Application.Exit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
           


            bool durum = false;
            yeniuyekaydi frm = new yeniuyekaydi ();
            foreach (Form eleman in this.MdiChildren)
            {
                if (eleman.Text == frm.Text)
                {
                    durum = true;
                    eleman.Activate();
                    MessageBox.Show("Yeni bir form açmak için açık olan formu kapatınız.!");
                }
            }
            if (durum == false)
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void kitapÖdünçVermeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            bool durum = false;
            kitapodunc frm = new kitapodunc();
            foreach (Form eleman in this.MdiChildren)
            {
                if (eleman.Text == frm.Text)
                {
                    durum = true;
                    eleman.Activate();
                    MessageBox.Show("Yeni bir form açmak için açık olan formu kapatınız.!");
                }
            }
            if (durum == false)
            {
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            bool durum = false;
            kitapodunc frm = new kitapodunc();
            foreach (Form eleman in this.MdiChildren)
            {
                if (eleman.Text == frm.Text)
                {
                    durum = true;
                    eleman.Activate();
                    MessageBox.Show("Yeni bir form açmak için açık olan formu kapatınız.!");
                }
            }
            if (durum == false)
            {
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void yeniKullanıcıEklemeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            bool durum = false;
            kullanici  frm = new kullanici();
            foreach (Form eleman in this.MdiChildren)
            {
                if (eleman.Text == frm.Text)
                {
                    durum = true;
                    eleman.Activate();
                    MessageBox.Show("Yeni bir form açmak için açık olan formu kapatınız.!");
                }
            }
            if (durum == false)
            {
                frm.MdiParent = this;
                frm.Show();
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Programı kapatmak istiyormusunuz?", "Çıkış", MessageBoxButtons.YesNo) == DialogResult.Yes)
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
            bool durum = false;
            kitapara frm = new kitapara();
            foreach (Form eleman in this.MdiChildren)
            {
                if (eleman.Text == frm.Text)
                {
                    durum = true;
                    eleman.Activate();
                    MessageBox.Show("Yeni bir form açmak için açık olan formu kapatınız.!");
                }
            }
            if (durum == false)
            {
                frm.MdiParent = this;
                frm.Show();
            }

        }

        private void kitapListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            raporkitaplistesi kitapliste = new raporkitaplistesi();
            kitapliste.MdiParent = this;
            kitapliste.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Oturumu kapatmak istiyormusunuz?", "Çıkış", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                giris giris = new giris();
                giris.Show();
                this.Close();
            }
            
            
        }

        private void ödünçtekiKitaplarınListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {      
            emanetrapor emanet = new  emanetrapor ();
            emanet.MdiParent = this;
            emanet.Show();
        }

        private void üyeListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uye_rapor uye = new uye_rapor();
            uye.MdiParent = this;
            uye.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool durum = false;
            uye_kitap_rapor frm = new uye_kitap_rapor ();
            foreach (Form eleman in this.MdiChildren)
            {
                if (eleman.Text == frm.Text)
                {
                    durum = true;
                    eleman.Activate();
                    MessageBox.Show("Yeni bir form açmak için açık olan formu kapatınız.!");
                }
            }
            if (durum == false)
            {
                frm.MdiParent = this;
                frm.Show();
            }
        }

        private void iadesiYaklaşanlarVeGeçenlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iadeler iadeler = new iadeler();
            iadeler.MdiParent = this;
            iadeler.Show();
        }
    }
}
