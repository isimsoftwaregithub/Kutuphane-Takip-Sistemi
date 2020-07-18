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
    public partial class kitapara : Form
    {
        public kitapara()
        {
            InitializeComponent();
        }
      

        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
       
       public int sira;
         public string komut;
        public   int kayit_sayisi ;
        public void turuDoldur()
        {

            baglanti.Open();
            SqlDataAdapter yda = new SqlDataAdapter("Select * from kategori_tablo", baglanti);
            DataSet yds = new DataSet();
            yda.Fill(yds);
            comboBox2.DataSource = yds.Tables[0];
            comboBox2.DisplayMember = "kategori_adi";
            comboBox2.ValueMember = "kategori_no";
            baglanti.Close();

        }
        public void griddoldur(string sqlkomut)
        {    
             baglanti.Open();
            SqlDataAdapter kda = new SqlDataAdapter(sqlkomut, baglanti);
            DataSet kds = new DataSet();
            kda.Fill(kds);
            baglanti.Close();
            dataGridView1.DataSource = kds.Tables[0];

            dataGridView1.Columns[0].HeaderText = "K.No";
            dataGridView1.Columns[1].HeaderText = "Eser Adı";
            dataGridView1.Columns[2].HeaderText = "Yazar";
            dataGridView1.Columns[3].HeaderText = "Kategori";
            dataGridView1.Columns[4].HeaderText = "Açıklamalar";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 400;
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns[1].DefaultCellStyle.ForeColor = Color.Blue;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns[3].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.Columns[4].DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.YellowGreen;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
                  
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if(comboBox1.Text=="Anahtar sözcük"&&comboBox2.Text=="HEPSİ")
            {
             komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where kitap_adi like '%"+textBox2.Text+"%' or yazar_adi like '%"+textBox2.Text+"%'";
                griddoldur(komut);
            }
            if (comboBox1.Text == "Anahtar sözcük" && comboBox2.Text != "HEPSİ")
            {
                 komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where (kitap_adi like '%" + textBox2.Text + "%' or yazar_adi like '%" + textBox2.Text + "%') and kategori_adi ='"+comboBox2.Text + "'";
                griddoldur(komut);
            }
            else if (comboBox1.Text == "Yazar Adı Soyadı" && comboBox2.Text == "HEPSİ")
            {
                 komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where  yazar_adi like '%" + textBox2.Text + "%' ";
                griddoldur(komut);
            }
            else if (comboBox1.Text == "Yazar Adı Soyadı" && comboBox2.Text != "HEPSİ")
            {
                 komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where  yazar_adi like '%" + textBox2.Text + "%' and kategori_adi like '%" + comboBox2.Text + "%'";
                griddoldur(komut);
            }
            else if (comboBox1.Text == "Eser Adı" && comboBox2.Text == "HEPSİ")
            {
                 komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where kitap_adi like '%" + textBox2.Text + "%' or kategori_adi like '%" + textBox2.Text + "%'";
                griddoldur(komut);
            }
            else if (comboBox1.Text == "Eser Adı" && comboBox2.Text != "HEPSİ")
            {
                komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where kitap_adi like '%" + textBox2.Text + "%' and kategori_adi like '%" + comboBox2.Text + "%'";
                griddoldur(komut);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void kitapara_Load(object sender, EventArgs e)
        {
           
            turuDoldur();
          
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
          
            kayit_sayisi = dataGridView1.Rows.Count-1;
            sira = dataGridView1.CurrentRow.Index;
            string no = (dataGridView1.Rows[sira].Cells[0].Value.ToString());
            
            string durum = "";
            try
            {

                SqlCommand kitapgelenveri = new SqlCommand("select k.kitap_durumu,k.kitap_no,k.kitap_barkod,k.kitap_isbn,k.kitap_adi,y.yazar_adi,k.kitap_ceviri,t.kategori_adi,e.edinim_adi,yayin_evi,baski_yili,baski_sayisi,cilt_sayisi,baski_yeri,kitap_yeri,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no inner join kutuphanedb.dbo.edinim_tablo e on k.edinim_no=e.edinim_no where k.kitap_no='" + no + "'", baglanti);
                baglanti.Open();
                SqlDataReader okunanveri = kitapgelenveri.ExecuteReader();

                while (okunanveri.Read())
                {

                    label6.Text = okunanveri["kitap_no"].ToString();
                    label16.Text = okunanveri["kitap_adi"].ToString();
                    label15.Text = okunanveri["kitap_isbn"].ToString();
                    label18.Text = okunanveri["kitap_ceviri"].ToString();
                    label20.Text = okunanveri["yayin_evi"].ToString();
                    label21.Text = okunanveri["baski_yili"].ToString();
                    label22.Text = okunanveri["baski_sayisi"].ToString();
                    label23.Text = okunanveri["cilt_sayisi"].ToString();
                    label24.Text = okunanveri["baski_yeri"].ToString();
                    label26.Text = okunanveri["aciklamalar"].ToString();
                    label25.Text = okunanveri["kitap_yeri"].ToString();
                    label17.Text = okunanveri["yazar_adi"].ToString();
                    label19.Text = okunanveri["kategori_adi"].ToString();
                    durum = okunanveri["kitap_durumu"].ToString();

                }
                baglanti.Close();

                if (durum == "True")
                {
                    label28.Visible = true;
                    label27.Visible = false;
                }
                else
                {
                    label28.Visible = false;
                    label27.Visible = true;
                }
                groupBox2.Visible = true;
                groupBox1.Enabled = false;
                dataGridView1.Visible = false;
                
            }
            catch { MessageBox.Show("Böyle bir kitap kaydı bulunamadı..!"); }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Enabled = true;
            dataGridView1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Enabled = true;
            dataGridView1.Visible = true;
            dataGridView1.DataSource = "";
        }

       

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sira = sira + 1;
            if (sira > kayit_sayisi-1)
                MessageBox.Show("Başka bir kayıt bulunamadı..");
            else
            {
                string no = (dataGridView1.Rows[sira].Cells[0].Value.ToString());

                string durum = "";
                try
                {

                    SqlCommand kitapgelenveri = new SqlCommand("select k.kitap_durumu,k.kitap_no,k.kitap_barkod,k.kitap_isbn,k.kitap_adi,y.yazar_adi,k.kitap_ceviri,t.kategori_adi,e.edinim_adi,yayin_evi,baski_yili,baski_sayisi,cilt_sayisi,baski_yeri,kitap_yeri,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no inner join kutuphanedb.dbo.edinim_tablo e on k.edinim_no=e.edinim_no where k.kitap_no='" + no + "'", baglanti);
                    baglanti.Open();
                    SqlDataReader okunanveri = kitapgelenveri.ExecuteReader();

                    while (okunanveri.Read())
                    {

                        label6.Text = okunanveri["kitap_no"].ToString();
                        label16.Text = okunanveri["kitap_adi"].ToString();
                        label15.Text = okunanveri["kitap_isbn"].ToString();
                        label18.Text = okunanveri["kitap_ceviri"].ToString();
                        label20.Text = okunanveri["yayin_evi"].ToString();
                        label21.Text = okunanveri["baski_yili"].ToString();
                        label22.Text = okunanveri["baski_sayisi"].ToString();
                        label23.Text = okunanveri["cilt_sayisi"].ToString();
                        label24.Text = okunanveri["baski_yeri"].ToString();
                        label26.Text = okunanveri["aciklamalar"].ToString();
                        label25.Text = okunanveri["kitap_yeri"].ToString();
                        label17.Text = okunanveri["yazar_adi"].ToString();
                        label19.Text = okunanveri["kategori_adi"].ToString();
                        durum = okunanveri["kitap_durumu"].ToString();

                    }
                    baglanti.Close();
                }
                catch { MessageBox.Show("Beklenmeyen bir hata gerçekleşti..!"); }
            }

            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sira = sira - 1;
            if (sira < 0)
                MessageBox.Show("Başka bir kayıt bulunamadı..");
            else
            {
                string no = (dataGridView1.Rows[sira].Cells[0].Value.ToString());

                string durum = "";
                try
                {

                    SqlCommand kitapgelenveri = new SqlCommand("select k.kitap_durumu,k.kitap_no,k.kitap_barkod,k.kitap_isbn,k.kitap_adi,y.yazar_adi,k.kitap_ceviri,t.kategori_adi,e.edinim_adi,yayin_evi,baski_yili,baski_sayisi,cilt_sayisi,baski_yeri,kitap_yeri,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no inner join kutuphanedb.dbo.edinim_tablo e on k.edinim_no=e.edinim_no where k.kitap_no='" + no + "'", baglanti);
                    baglanti.Open();
                    SqlDataReader okunanveri = kitapgelenveri.ExecuteReader();

                    while (okunanveri.Read())
                    {

                        label6.Text = okunanveri["kitap_no"].ToString();
                        label16.Text = okunanveri["kitap_adi"].ToString();
                        label15.Text = okunanveri["kitap_isbn"].ToString();
                        label18.Text = okunanveri["kitap_ceviri"].ToString();
                        label20.Text = okunanveri["yayin_evi"].ToString();
                        label21.Text = okunanveri["baski_yili"].ToString();
                        label22.Text = okunanveri["baski_sayisi"].ToString();
                        label23.Text = okunanveri["cilt_sayisi"].ToString();
                        label24.Text = okunanveri["baski_yeri"].ToString();
                        label26.Text = okunanveri["aciklamalar"].ToString();
                        label25.Text = okunanveri["kitap_yeri"].ToString();
                        label17.Text = okunanveri["yazar_adi"].ToString();
                        label19.Text = okunanveri["kategori_adi"].ToString();
                        durum = okunanveri["kitap_durumu"].ToString();

                    }
                    baglanti.Close();
                }
                catch { MessageBox.Show("Beklenmeyen bir hata gerçekleşti..!"); }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (comboBox1.Text == "Anahtar sözcük" && comboBox2.Text == "HEPSİ")
            {
                komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where kitap_adi like '%" + textBox2.Text + "%' or yazar_adi like '%" + textBox2.Text + "%'";
                griddoldur(komut);
            }
            if (comboBox1.Text == "Anahtar sözcük" && comboBox2.Text != "HEPSİ")
            {
                komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where (kitap_adi like '%" + textBox2.Text + "%' or yazar_adi like '%" + textBox2.Text + "%') and kategori_adi ='" + comboBox2.Text + "'";
                griddoldur(komut);
            }
            else if (comboBox1.Text == "Yazar Adı Soyadı" && comboBox2.Text == "HEPSİ")
            {
                komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where  yazar_adi like '%" + textBox2.Text + "%' ";
                griddoldur(komut);
            }
            else if (comboBox1.Text == "Yazar Adı Soyadı" && comboBox2.Text != "HEPSİ")
            {
                komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where  yazar_adi like '%" + textBox2.Text + "%' and kategori_adi like '%" + comboBox2.Text + "%'";
                griddoldur(komut);
            }
            else if (comboBox1.Text == "Eser Adı" && comboBox2.Text == "HEPSİ")
            {
                komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where kitap_adi like '%" + textBox2.Text + "%' or kategori_adi like '%" + textBox2.Text + "%'";
                griddoldur(komut);
            }
            else if (comboBox1.Text == "Eser Adı" && comboBox2.Text != "HEPSİ")
            {
                komut = "select k.kitap_no,k.kitap_adi,y.yazar_adi,t.kategori_adi,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where kitap_adi like '%" + textBox2.Text + "%' and kategori_adi like '%" + comboBox2.Text + "%'";
                griddoldur(komut);
            }
        }

        
    }
}
