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
    public partial class kullanici : Form
    {
        public kullanici()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
        public void GridDoldur()
        {

            baglanti.Open();
            SqlDataAdapter kda = new SqlDataAdapter("select * from kullanici_tablo", baglanti);
            DataSet kds = new DataSet();
            kda.Fill(kds);
            baglanti.Close();
            dataGridView1.DataSource = kds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "K.No";
            dataGridView1.Columns[1].HeaderText = "Kullanıcı Adı";
            dataGridView1.Columns[2].HeaderText = "Şifre";
            dataGridView1.Columns[3].HeaderText = "Gizli Soru";
            dataGridView1.Columns[4].HeaderText = "Gizli Cevap";
            dataGridView1.Columns[5].HeaderText = "Kulanıcı Yetki";

            dataGridView1.Columns[2].Visible = false;

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 200;

        }
        private void button8_Click(object sender, EventArgs e)
        {
            string uye_kaydi, kitap_teslim, arama, raporlama, yetki;

            if (checkBox1.Checked == true)
                uye_kaydi = "1";
            else
                uye_kaydi = "0";
            if (checkBox2.Checked == true)
                kitap_teslim = "1";
            else
                kitap_teslim = "0";
            if (checkBox3.Checked == true)
                arama = "1";
            else
                arama = "0";
            if (checkBox4.Checked == true)
                raporlama = "1";
            else
                raporlama = "0";
            yetki = uye_kaydi + kitap_teslim + arama + raporlama;


            if (textBox2.Text == "")
                MessageBox.Show("Kullanıcı adı girilmesi gereken bir parametredir..!");
            else if (textBox3.Text == "")
                MessageBox.Show("Şifre girilmesi gereken bir parametredir..!");
            else if (textBox3.Text != textBox4.Text)
                MessageBox.Show("Girmiş olduğunuz şifreler aynı olmak zorundadır..!");
            else if (textBox5.Text == "")
                MessageBox.Show("Lütfen bir gizli soru giriniz..!");
            else if (textBox6.Text == "")
                MessageBox.Show("Gizli sorunuzun cevabı boş olamaz..!");
            else if (yetki == "0000")
                MessageBox.Show("Lütfen Yetkilendirme Yapınız..!");
            else
            {
                SqlCommand kullaniciekle = new SqlCommand("insert into kullanici_tablo(kullanici_adi,kullanici_sifre,kullanici_gizli_soru,kullanici_gizli_cevap,kullanici_yetki) values('" + textBox2.Text.ToUpper() + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + yetki + "') ", baglanti);
                try
                {
                    baglanti.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from kullanici_tablo where kullanici_adi='" + textBox2.Text + "'", baglanti);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);

                    if (dataset.Tables[0].Rows.Count == 1)
                    {
                        MessageBox.Show("Daha önce aynı isimde bir kullanıcı adı mevcuttur. Lütfen başka bir kullanıcı adı seçiniz.!");
                        baglanti.Close();
                    }

                    else
                    {
                        kullaniciekle.ExecuteNonQuery();
                        MessageBox.Show("Kullacı başarılı bir şekilde eklendi.");
                        baglanti.Close();
                        button8.Visible = false;
                        button1.Visible = true;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox5.Enabled = false;
                        textBox6.Enabled = false;

                        GridDoldur();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                    }
                }
                catch
                {
                    MessageBox.Show("Kayıt yapılamadı...!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uye_kaydi, kitap_teslim, arama, raporlama, yetki;

            if (checkBox1.Checked == true)
                uye_kaydi = "1";
            else
                uye_kaydi = "0";
            if (checkBox2.Checked == true)
                kitap_teslim = "1";
            else
                kitap_teslim = "0";
            if (checkBox3.Checked == true)
                arama = "1";
            else
                arama = "0";
            if (checkBox4.Checked == true)
                raporlama = "1";
            else
                raporlama = "0";
            yetki = uye_kaydi + kitap_teslim + arama + raporlama;


            if (textBox2.Text == "")
                MessageBox.Show("Kullanıcı adı girilmesi gereken bir parametredir..!");
            else if (textBox3.Text == "")
                MessageBox.Show("Şifre girilmesi gereken bir parametredir..!");
            else if (textBox3.Text != textBox4.Text)
                MessageBox.Show("Girmiş olduğunuz şifreler aynı olmak zorundadır..!");
            else if (textBox5.Text == "")
                MessageBox.Show("Lütfen bir gizli soru giriniz..!");
            else if (textBox6.Text == "")
                MessageBox.Show("Gizli sorunuzun cevabı boş olamaz..!");
            else if (yetki == "0000")
                MessageBox.Show("Lütfen Yetkilendirme Yapınız..!");
            else
            {
                SqlCommand kullaniciduzelt = new SqlCommand("update kullanici_tablo set kullanici_adi='" + textBox2.Text + "', kullanici_sifre='" + textBox3.Text + "',kullanici_gizli_soru='" + textBox5.Text + "',kullanici_gizli_cevap='" + textBox6.Text + "', kullanici_yetki='" + yetki + "' where kullanici_no='" + textBox1.Text + "' ", baglanti);
                try
                {
                    if (MessageBox.Show("Seçtiğiniz kullanıcıda değişiklik yapmak istediğinize emin misiniz?", "Değiştir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        baglanti.Open();
                        kullaniciduzelt.ExecuteNonQuery();
                        MessageBox.Show("Kayıt başarılı bir şekilde güncellendi.");
                        baglanti.Close();
                        GridDoldur();

                    }
                }
                catch
                {
                    MessageBox.Show("Kayıt güncellenemedi...!");
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Seçmiş olduğunu kullanıcıyı silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand uye_sil = new SqlCommand("delete from kullanici_tablo where kullanici_no='" + textBox1.Text + "' ", baglanti);
                    try
                    {
                        baglanti.Open();
                        uye_sil.ExecuteNonQuery();
                        MessageBox.Show("Kayıt başarılı bir şekilde silindi.");
                        baglanti.Close();
                        GridDoldur();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";




                    }
                    catch
                    {
                        MessageBox.Show("Kayıt silinemedi...!");
                    }
                }

            }
            else
                MessageBox.Show("Lütfen boş geçmeyiniz..!");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string no = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string adi = (dataGridView1.CurrentRow.Cells[1].Value.ToString());
            string sifre = (dataGridView1.CurrentRow.Cells[2].Value.ToString());
            string gsoru = (dataGridView1.CurrentRow.Cells[3].Value.ToString());
            string gcevap = (dataGridView1.CurrentRow.Cells[4].Value.ToString());
            string yetki = (dataGridView1.CurrentRow.Cells[5].Value.ToString());
            if (yetki.Substring(0, 1).ToString() == "0")
                checkBox1.Checked = false;
            else
                checkBox1.Checked = true;
            if (yetki.Substring(1, 1).ToString() == "0")
                checkBox2.Checked = false;
            else
                checkBox2.Checked = true;
            if (yetki.Substring(2, 1).ToString() == "0")
                checkBox3.Checked = false;
            else
                checkBox3.Checked = true;
            if (yetki.Substring(3, 1).ToString() == "0")
                checkBox4.Checked = false;
            else
                checkBox4.Checked = true;

            textBox1.Text = no;
            textBox2.Text = adi;
            textBox3.Text = sifre;
            textBox4.Text = sifre;
            textBox5.Text = gsoru;
            textBox6.Text = gcevap;


            button2.Enabled = true;
            button3.Enabled = true;
            button8.Visible = false;
            button1.Visible = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;

        }

        private void kullanici_Load(object sender, EventArgs e)
        {

            this.Location = new Point(205, 0);
            GridDoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button8.Visible = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
            }
            else
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;


            }

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
