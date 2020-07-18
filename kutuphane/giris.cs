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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();

            

        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
    static public string yetki;
    string sifre,soru,cevap;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void giris_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { MessageBox.Show("Kullanıcı adını lütfen boş bırakmayınız..!"); }
            else if (textBox2.Text == "")
                MessageBox.Show("Şifrenizi giriniz..!");
            else
            {
                try
                {
                    baglanti.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from kullanici_tablo where kullanici_adi='" + textBox1.Text + "' and kullanici_sifre='" + textBox2.Text + "'", baglanti);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);
                    baglanti.Close();
                    yetki = "";
                    yetki = dataset.Tables[0].Rows[0][5].ToString();



                    if (dataset.Tables[0].Rows.Count == 1)
                    {
                        anamenu anamenu = new anamenu();
                        anamenu.Show();
                        this.Visible = false;

                    }
                    else MessageBox.Show("Lütfen kullanıcı adı ve şifrenizi doğru giriniz.!");
                }
                catch
                {
                    MessageBox.Show("Lütfen kullanıcı adı ve şifrenizi doğru giriniz.!");
                    baglanti.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                baglanti.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select kullanici_sifre from kullanici_tablo where kullanici_adi='" + textBox1.Text + "'", baglanti);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                if (dataset.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Lütfen kullanıcı adını doğru yazdığınıza emin olunuz.!");
                    baglanti.Close();
                }
                else
                {

                    sifre = dataset.Tables[0].Rows[0][0].ToString();
                    baglanti.Close();
                    groupBox3.Visible = true;
                    groupBox4.Visible = false;
                    groupBox4.Left += 500;
                    groupBox3.Left -= 500;

                }
            }
            else
                MessageBox.Show("Lütfen kullanıcı adınızı giriniz");
            
           

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == cevap)
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
                groupBox1.Left += 1000;
                groupBox2.Left -= 1500;
            }
            else
                MessageBox.Show("Girmiş olduğunu cevabınız hatalı.!");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                

                baglanti.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select kullanici_gizli_soru,kullanici_gizli_cevap from kullanici_tablo where kullanici_adi='" + textBox1.Text + "'", baglanti);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                if (dataset.Tables[0].Rows.Count == 0)
                {
                    MessageBox.Show("Lütfen kullanıcı adını doğru yazdığınıza emin olunuz.!");
                    baglanti.Close();
                }
                else
                {
                    soru = dataset.Tables[0].Rows[0][0].ToString();
                    cevap = dataset.Tables[0].Rows[0][1].ToString();
                    label7.Text = soru;
                    baglanti.Close();
                    groupBox1.Visible = true;
                    groupBox4.Visible = false;
                    groupBox1.Left -=1000;
                    groupBox4.Left += 1000;
                    textBox2.Text = "";

                }
            }
            else
                MessageBox.Show("Lütfen kullanıcı adınızı giriniz");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == sifre)
            {
                if (textBox6.Text == "")
                    MessageBox.Show("Lütfen boş geçmeyiniz!");
                else if( textBox8.Text == "" )
                    MessageBox.Show("Lütfen yeni şifrenizi boş geçmeyiniz!");
                else if(textBox6.Text=="")
                    MessageBox.Show("Lütfen yeni şifrenizi boş geçmeyiniz!");
                    else if(textBox8.Text!=textBox6.Text)
                    MessageBox.Show("Girmiş olduğunuz şifrelerin aynı olması gerekmektedir.!");
                        else
                {
                    SqlCommand kullaniciduzelt = new SqlCommand("update kullanici_tablo set  kullanici_sifre='" + textBox6.Text + "' where kullanici_adi='" + textBox1.Text + "' ", baglanti);
                    try
                    {
                        if (MessageBox.Show("Şifrenizde değişiklik yapmak istediğinize emin misiniz?", "Değiştir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            baglanti.Open();
                            kullaniciduzelt.ExecuteNonQuery();
                            MessageBox.Show("Şifreniz başarılı bir şekilde değiştirildi.");
                            textBox6.Text = "";
                            textBox7.Text = "";
                            textBox8.Text = "";
                            groupBox3.Visible = false;
                            groupBox4.Visible = true;
                            groupBox4.Left -= 500;
                            baglanti.Close();
                         }
                    }
                    catch
                    {
                        MessageBox.Show("Şifreniz değiştirlemedi...!");
                    }
                   
              
                 }
            }
            else
            {
                MessageBox.Show("Girmiş olduğunuz şifreniz hatalı..!");
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox4.Visible = true;
            groupBox4.Left -= 1000;
            groupBox1.Left += 1000;
            label7.Text = "";
            textBox5.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            groupBox4.Visible = true;
            groupBox4.Left -= 500;
            groupBox3.Left += 500;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text != sifre)
                errorProvider1.SetError(textBox7, "Şifre Hatalı.!");
            else
                errorProvider1.Clear();
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text != cevap)
                errorProvider2.SetError(textBox5, "Cevap Hatalı.!");
            else
                errorProvider2.Clear();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("Lütfen boş geçmeyeniz.!");
            else   if(textBox3.Text!=textBox4.Text)
                    MessageBox.Show("Girmiş olduğunuz şifrelerin aynı olması gerekmektedir.!");
                        else
                {
                    SqlCommand kullaniciduzelt = new SqlCommand("update kullanici_tablo set  kullanici_sifre='" + textBox3.Text + "' where kullanici_adi='" + textBox1.Text + "' ", baglanti);
                    try
                    {
                        if (MessageBox.Show("Şifrenizde değişiklik yapmak istediğinize emin misiniz?", "Değiştir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            baglanti.Open();
                            kullaniciduzelt.ExecuteNonQuery();
                            MessageBox.Show("Şifreniz başarılı bir şekilde değiştirildi.");
                            textBox4.Text = "";
                            textBox3.Text = "";
                            baglanti.Close();
                            groupBox4.Visible = true;
                            groupBox2.Visible = false;
                            groupBox4.Left -= 1000;
                            groupBox2.Left += 1500;
                         }
                    }
                    catch
                    {
                        MessageBox.Show("Şifreniz değiştirlemedi...!");
                    }
                   
              
                 }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = true;
            groupBox2.Visible = false;
            groupBox2.Left += 1500;
            groupBox4.Left -= 1000;
            textBox3.Text = "";
            textBox4.Text = "";

        }

       
    }
}
