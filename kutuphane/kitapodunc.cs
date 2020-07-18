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
    public partial class kitapodunc : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
        public void mask_doldur()
        {
            maskedTextBox1.BackColor = Color.White;
            try
            {
                if (maskedTextBox1.Text != "")
                {
                    baglanti.Open();
                    SqlDataAdapter kda = new SqlDataAdapter("select  u.uye_adi,u.uye_soyadi, k.kitap_barkod,k.kitap_adi,y.yazar_adi,t.kategori_adi,o.odunc_alim_tarihi,o.odunc_teslim_tarihi,o.odunc_no from kutuphanedb.dbo.odunc_tablo o  inner join kutuphanedb.dbo.uye_tablo u on u.uye_no=o.uye_no  inner join kutuphanedb.dbo.kitap_tablo k on o.kitap_no=k.kitap_no  inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no   inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where u.uye_tcno='" + maskedTextBox1.Text + "'  ORDER BY o.odunc_no DESC", baglanti);
                    DataSet kds = new DataSet();
                    kda.Fill(kds);
                    baglanti.Close();
                    dataGridView1.DataSource = kds.Tables[0];
                    dataGridView1.Columns[0].HeaderText = "Adı";
                    dataGridView1.Columns[1].HeaderText = "Soyadı";
                    dataGridView1.Columns[2].HeaderText = "Barkod No";
                    dataGridView1.Columns[3].HeaderText = "Kitap Adı";
                    dataGridView1.Columns[4].HeaderText = "Yazar Adı";
                    dataGridView1.Columns[5].HeaderText = "Kategori";
                    dataGridView1.Columns[6].HeaderText = "Ö.Alım Tarihi";
                    dataGridView1.Columns[7].HeaderText = "Ö.Teslim Tarihi";
                    dataGridView1.Columns[8].HeaderText = "Ödünç No";
                    dataGridView1.Columns[0].Width = 200;
                    dataGridView1.Columns[1].Width = 200;
                    dataGridView1.Columns[2].Width = 200;
                    dataGridView1.Columns[3].Width = 200;
                    dataGridView1.Columns[4].Width = 150;
                    dataGridView1.Columns[5].Width = 200;
                    dataGridView1.Columns[6].Width = 200;
                    dataGridView1.Columns[7].Width = 200;

                    SqlCommand gelenveri = new SqlCommand("select uye_no,uye_adi,uye_soyadi from uye_tablo where uye_tcno='" + maskedTextBox1.Text + "'", baglanti);
                    baglanti.Open();
                    SqlDataReader okunanveri = gelenveri.ExecuteReader();
                    while (okunanveri.Read())
                    {
                        textBox16.Text = okunanveri["uye_no"].ToString();
                        textBox14.Text = okunanveri["uye_adi"].ToString();
                        textBox15.Text = okunanveri["uye_soyadi"].ToString();
                    }
                    baglanti.Close();
                    maskedTextBox2.Enabled = true;
                }
                //  else { MessageBox.Show("Lütfen T.C. Kimlik No'yu boş geçmeyiniz!"); }

            }
            catch { MessageBox.Show("Lütfen Girmiş Olduğunuz T.C. No'yu kontrol ediniz.!"); }


        }


        public void GridDoldur()
        {
            baglanti.Open();
            SqlDataAdapter kda = new SqlDataAdapter("select  u.uye_adi,u.uye_soyadi, k.kitap_barkod,k.kitap_adi,y.yazar_adi,t.kategori_adi,o.odunc_alim_tarihi,o.odunc_teslim_tarihi,o.odunc_no from kutuphanedb.dbo.odunc_tablo o  inner join kutuphanedb.dbo.uye_tablo u on u.uye_no=o.uye_no  inner join kutuphanedb.dbo.kitap_tablo k on o.kitap_no=k.kitap_no  inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no   inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where u.uye_tcno='" + maskedTextBox1.Text + "' ORDER BY o.odunc_no DESC", baglanti);
            DataSet kds = new DataSet();
            kda.Fill(kds);
            baglanti.Close();
            dataGridView1.DataSource = kds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Adı";
            dataGridView1.Columns[1].HeaderText = "Soyadı";
            dataGridView1.Columns[2].HeaderText = "Barkod No";
            dataGridView1.Columns[3].HeaderText = "Kitap Adı";
            dataGridView1.Columns[4].HeaderText = "Yazar Adı";
            dataGridView1.Columns[5].HeaderText = "Kategori";
            dataGridView1.Columns[6].HeaderText = "Ö.Alım Tarihi";
            dataGridView1.Columns[7].HeaderText = "Ö.Teslim Tarihi";
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].Width = 200;
            dataGridView1.Columns[6].Width = 200;
            dataGridView1.Columns[7].Width = 200;
            try
            {
                SqlCommand gelenveri = new SqlCommand("select uye_no,uye_adi,uye_soyadi from uye_tablo where uye_tcno='" + maskedTextBox1.Text + "'", baglanti);
                baglanti.Open();
                SqlDataReader okunanveri = gelenveri.ExecuteReader();
                while (okunanveri.Read())
                {
                    textBox16.Text = okunanveri["uye_no"].ToString();
                    textBox14.Text = okunanveri["uye_adi"].ToString();
                    textBox15.Text = okunanveri["uye_soyadi"].ToString();
                }
                baglanti.Close();
            }
            catch { MessageBox.Show("Lütfen Girmiş Olduğunuz T.C. No'yu kontrol ediniz.!"); }

        }
        public kitapodunc()
        {
            InitializeComponent();
        }

        private void kitapodunc_Load(object sender, EventArgs e)
        {
            this.Location = new Point(205, 0);
        }

        private void textBox13_Leave(object sender, EventArgs e)
        {




        }

        private void textBox12_Leave(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (comboBox4.Text == "ET")
            {

                DateTime dt = DateTime.Now;
                String zaman_Aldigi = dt.ToString("yyyy-MM-dd hh:mm:ss");
                String zaman_TeslimEtmesiGereken = dt.AddDays(15).ToString("yyyy-MM-dd hh:mm:ss");


                if (textBox14.Text == "")
                    MessageBox.Show("Lütfen istenilen değerleri giriniz.!");
                else if (textBox1.Text == "")
                    MessageBox.Show("Lütfen istenilen değerleri giriniz..!");
                else if (label21.Visible == false)
                    MessageBox.Show("Bu kitap zaten ödünç verilmiştir...!");
                else
                {

                    if (MessageBox.Show("Seçmiş olduğunu kitabı " + textBox14.Text + " " + textBox15.Text + " isimli kişiye vermek istiyormusunuz?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string komut = "insert into odunc_tablo(uye_no,kitap_no,odunc_alim_tarihi,odunc_teslimetmesi_gereken_tarih) values('" + textBox16.Text + "','" + textBox1.Text + "','" + zaman_Aldigi + "','"+ zaman_TeslimEtmesiGereken+"')";

                        SqlCommand odunckaydet = new SqlCommand(komut, baglanti);
                        try
                        {
                            baglanti.Open();
                            odunckaydet.ExecuteNonQuery();
                            MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
                            SqlCommand kitapduzelt = new SqlCommand("update kitap_tablo set kitap_durumu='False' where kitap_no='" + textBox1.Text + "' ", baglanti);
                            kitapduzelt.ExecuteNonQuery();
                            label22.Visible = true;
                            label21.Visible = false;
                            baglanti.Close();
                            GridDoldur();

                        }
                        catch
                        {
                            MessageBox.Show("Kayıt yapılamadı...!");
                        }
                    }
                }
            }
            if (comboBox4.Text == "AL")
            {
                
                String zaman = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");


                if (textBox14.Text == "")
                    MessageBox.Show("Lütfen istenilen değerleri giriniz.!");
                else if (textBox1.Text == "")
                    MessageBox.Show("Lütfen istenilen değerleri giriniz..!");
                else if (label21.Visible == true)
                    MessageBox.Show("Lütfen kayıtları kontrol ediniz. Kitap kütüphanede görülüyor...!");
                else
                {

                    if (MessageBox.Show("Seçmiş olduğunuz " + textBox2.Text + " isimli kitabı teslim almak istiyormusunuz?", "Teslim Al", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        textBox17.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                        string komut = "update odunc_tablo set iadeEdildiMi=True, odunc_teslim_tarihi='" + zaman + "' where odunc_no='" + textBox17.Text + "'";
                        SqlCommand odunckaydet = new SqlCommand(komut, baglanti);
                        try
                        {
                            baglanti.Open();
                            odunckaydet.ExecuteNonQuery();
                            MessageBox.Show("Kitap teslim işlemi başarılı bir şekilde tamamlandı.");
                            SqlCommand kitapduzelt = new SqlCommand("update kitap_tablo set kitap_durumu='True' where kitap_no='" + textBox1.Text + "' ", baglanti);
                            kitapduzelt.ExecuteNonQuery();
                            textBox17.Text = "";
                            label22.Visible = true;
                            label21.Visible = false;
                            baglanti.Close();
                            GridDoldur();

                        }
                        catch
                        {
                            MessageBox.Show("Kayıt yapılamadı...!");
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                textBox17.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                string barkod_no = (dataGridView1.CurrentRow.Cells[2].Value.ToString());
                SqlCommand kitapgelenveri = new SqlCommand("select k.kitap_no,k.kitap_durumu,k.kitap_barkod,k.kitap_isbn,k.kitap_adi,y.yazar_adi,k.kitap_ceviri,t.kategori_adi,e.edinim_adi,yayin_evi,baski_yili,baski_sayisi,cilt_sayisi,baski_yeri,kitap_yeri,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no inner join kutuphanedb.dbo.edinim_tablo e on k.edinim_no=e.edinim_no where k.kitap_barkod='" + barkod_no + "'", baglanti);
                baglanti.Open();
                SqlDataReader okunanveri = kitapgelenveri.ExecuteReader();

                while (okunanveri.Read())
                {
                    textBox1.Text = okunanveri["kitap_no"].ToString();
                    textBox2.Text = okunanveri["kitap_adi"].ToString();
                    textBox3.Text = okunanveri["kitap_isbn"].ToString();
                    textBox4.Text = okunanveri["kitap_ceviri"].ToString();
                    textBox5.Text = okunanveri["yayin_evi"].ToString();
                    textBox6.Text = okunanveri["baski_yili"].ToString();
                    textBox7.Text = okunanveri["baski_sayisi"].ToString();
                    textBox8.Text = okunanveri["cilt_sayisi"].ToString();
                    textBox9.Text = okunanveri["baski_yeri"].ToString();
                    textBox10.Text = okunanveri["aciklamalar"].ToString();
                    textBox11.Text = okunanveri["kitap_yeri"].ToString();
                    maskedTextBox2.Text = okunanveri["kitap_barkod"].ToString();

                    comboBox1.Text = okunanveri["yazar_adi"].ToString();
                    comboBox2.Text = okunanveri["kategori_adi"].ToString();
                    comboBox3.Text = okunanveri["edinim_adi"].ToString();
                    label26.Text = okunanveri["kitap_durumu"].ToString();

                }
                baglanti.Close();
                if (label26.Text == "True")
                {
                    label22.Visible = false;
                    label21.Visible = true;
                }
                else if (label26.Text == "False")
                {
                    label21.Visible = false;
                    label22.Visible = true;

                    try
                    {
                        if (maskedTextBox1.Text != "")
                        {
                            baglanti.Open();
                            SqlDataAdapter kda = new SqlDataAdapter("select  u.uye_adi,u.uye_soyadi, k.kitap_barkod,k.kitap_adi,y.yazar_adi,t.kategori_adi,o.odunc_alim_tarihi,o.odunc_teslim_tarihi,o.odunc_no from kutuphanedb.dbo.odunc_tablo o  inner join kutuphanedb.dbo.uye_tablo u on u.uye_no=o.uye_no  inner join kutuphanedb.dbo.kitap_tablo k on o.kitap_no=k.kitap_no  inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no   inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where u.uye_tcno='" + maskedTextBox1.Text + "'  ORDER BY o.odunc_no DESC", baglanti);
                            DataSet kds = new DataSet();
                            kda.Fill(kds);
                            baglanti.Close();
                            dataGridView1.DataSource = kds.Tables[0];
                            dataGridView1.Columns[0].HeaderText = "Adı";
                            dataGridView1.Columns[1].HeaderText = "Soyadı";
                            dataGridView1.Columns[2].HeaderText = "Barkod No";
                            dataGridView1.Columns[3].HeaderText = "Kitap Adı";
                            dataGridView1.Columns[4].HeaderText = "Yazar Adı";
                            dataGridView1.Columns[5].HeaderText = "Kategori";
                            dataGridView1.Columns[6].HeaderText = "Ö.Alım Tarihi";
                            dataGridView1.Columns[7].HeaderText = "Ö.Teslim Tarihi";
                            dataGridView1.Columns[8].HeaderText = "Ödünç No";
                            dataGridView1.Columns[0].Width = 200;
                            dataGridView1.Columns[1].Width = 200;
                            dataGridView1.Columns[2].Width = 200;
                            dataGridView1.Columns[3].Width = 200;
                            dataGridView1.Columns[4].Width = 150;
                            dataGridView1.Columns[5].Width = 200;
                            dataGridView1.Columns[6].Width = 200;
                            dataGridView1.Columns[7].Width = 200;

                        }
                        else { MessageBox.Show("Lütfen T.C. Kimlik No'yu boş geçmeyiniz!"); }

                    }
                    catch { MessageBox.Show("Lütfen Girmiş Olduğunuz T.C. No'yu kontrol ediniz.!"); }



                }
            }
            catch { MessageBox.Show("Beklenmeyen bir hata gerçekleşti..!"); }
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                if (dataGridView1.Rows[i].Cells[7].Value.ToString() == "")
                {

                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;

                }

                else
                {

                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightSteelBlue;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;

                }

            }

        }

        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
                e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.
            else if ((int)e.KeyChar == 8)
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            else
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma



        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
                e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.
            else if ((int)e.KeyChar == 8)
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            else
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            mask_doldur();
            /*  maskedTextBox1.BackColor = Color.White;
              try
              {
                  if (maskedTextBox1.Text != "")
                  {
                      baglanti.Open();
                      SqlDataAdapter kda = new SqlDataAdapter("select  u.uye_adi,u.uye_soyadi, k.kitap_barkod,k.kitap_adi,y.yazar_adi,t.kategori_adi,o.odunc_alim_tarihi,o.odunc_teslim_tarihi,o.odunc_no from kutuphanedb.dbo.odunc_tablo o  inner join kutuphanedb.dbo.uye_tablo u on u.uye_no=o.uye_no  inner join kutuphanedb.dbo.kitap_tablo k on o.kitap_no=k.kitap_no  inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no   inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no where u.uye_tcno='" +maskedTextBox1.Text + "'  ORDER BY o.odunc_no DESC", baglanti);
                      DataSet kds = new DataSet();
                      kda.Fill(kds);
                      baglanti.Close();
                      dataGridView1.DataSource = kds.Tables[0];
                      dataGridView1.Columns[0].HeaderText = "Adı";
                      dataGridView1.Columns[1].HeaderText = "Soyadı";
                      dataGridView1.Columns[2].HeaderText = "Barkod No";
                      dataGridView1.Columns[3].HeaderText = "Kitap Adı";
                      dataGridView1.Columns[4].HeaderText = "Yazar Adı";
                      dataGridView1.Columns[5].HeaderText = "Kategori";
                      dataGridView1.Columns[6].HeaderText = "Ö.Alım Tarihi";
                      dataGridView1.Columns[7].HeaderText = "Ö.Teslim Tarihi";
                      dataGridView1.Columns[8].HeaderText = "Ödünç No";
                      dataGridView1.Columns[0].Width = 200;
                      dataGridView1.Columns[1].Width = 200;
                      dataGridView1.Columns[2].Width = 200;
                      dataGridView1.Columns[3].Width = 200;
                      dataGridView1.Columns[4].Width = 150;
                      dataGridView1.Columns[5].Width = 200;
                      dataGridView1.Columns[6].Width = 200;
                      dataGridView1.Columns[7].Width = 200;

                      SqlCommand gelenveri = new SqlCommand("select uye_no,uye_adi,uye_soyadi from uye_tablo where uye_tcno='" +maskedTextBox1.Text + "'", baglanti);
                      baglanti.Open();
                      SqlDataReader okunanveri = gelenveri.ExecuteReader();
                      while (okunanveri.Read())
                      {
                          textBox16.Text = okunanveri["uye_no"].ToString();
                          textBox14.Text = okunanveri["uye_adi"].ToString();
                          textBox15.Text = okunanveri["uye_soyadi"].ToString();
                      }
                      baglanti.Close();
                     maskedTextBox2.Enabled= true;
                  }
                //  else { MessageBox.Show("Lütfen T.C. Kimlik No'yu boş geçmeyiniz!"); }

              }
              catch { MessageBox.Show("Lütfen Girmiş Olduğunuz T.C. No'yu kontrol ediniz.!"); }*/

        }

       
        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            maskedTextBox1.BackColor = Color.LightYellow;
        }

        private void maskedTextBox2_Enter(object sender, EventArgs e)
        {
            maskedTextBox2.BackColor = Color.LightYellow;
        }

        

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text.Length == 13)
                Sorgula();

           
        }


        void Sorgula()
        {
           

            label21.Visible = false;
            label22.Visible = false;
            maskedTextBox2.BackColor = Color.White;
            string durum = "";
            try
            {

                SqlCommand kitapgelenveri = new SqlCommand("select k.kitap_durumu,k.kitap_no,k.kitap_barkod,k.kitap_isbn,k.kitap_adi,y.yazar_adi,k.kitap_ceviri,t.kategori_adi,e.edinim_adi,yayin_evi,baski_yili,baski_sayisi,cilt_sayisi,baski_yeri,kitap_yeri,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no inner join kutuphanedb.dbo.edinim_tablo e on k.edinim_no=e.edinim_no where k.kitap_barkod='" + maskedTextBox2.Text + "'", baglanti);
                baglanti.Open();
                SqlDataReader okunanveri = kitapgelenveri.ExecuteReader();



                while (okunanveri.Read())
                {

                    textBox1.Text = okunanveri["kitap_no"].ToString();
                    textBox2.Text = okunanveri["kitap_adi"].ToString();
                    textBox3.Text = okunanveri["kitap_isbn"].ToString();
                    textBox4.Text = okunanveri["kitap_ceviri"].ToString();
                    textBox5.Text = okunanveri["yayin_evi"].ToString();
                    textBox6.Text = okunanveri["baski_yili"].ToString();
                    textBox7.Text = okunanveri["baski_sayisi"].ToString();
                    textBox8.Text = okunanveri["cilt_sayisi"].ToString();
                    textBox9.Text = okunanveri["baski_yeri"].ToString();
                    textBox10.Text = okunanveri["aciklamalar"].ToString();
                    textBox11.Text = okunanveri["kitap_yeri"].ToString();
                    comboBox1.Text = okunanveri["yazar_adi"].ToString();
                    comboBox2.Text = okunanveri["kategori_adi"].ToString();
                    comboBox3.Text = okunanveri["edinim_adi"].ToString();
                    durum = okunanveri["kitap_durumu"].ToString();
                }
                baglanti.Close();

                if (durum == "True")
                {
                    label21.Visible = true;
                    label22.Visible = false;
                    maskedTextBox1.Enabled = true;
                }
                else if (durum == "False")
                {
                    label21.Visible = false;
                    label22.Visible = true;



                    SqlCommand gelenveri = new SqlCommand("select  u.uye_no,u.uye_adi,u.uye_soyadi,u.uye_tcno from kutuphanedb.dbo.odunc_tablo o inner join kutuphanedb.dbo.uye_tablo u on u.uye_no=o.uye_no  where o.kitap_no=" + textBox1.Text + " and o.odunc_teslim_tarihi is null", baglanti);
                    baglanti.Open();
                    SqlDataReader okunanveri1 = gelenveri.ExecuteReader();

                    while (okunanveri1.Read())
                    {
                        textBox16.Text = okunanveri1["uye_no"].ToString();
                        textBox14.Text = okunanveri1["uye_adi"].ToString();
                        textBox15.Text = okunanveri1["uye_soyadi"].ToString();
                        maskedTextBox1.Text = okunanveri1["uye_tcno"].ToString();

                    }
                    baglanti.Close();
                    maskedTextBox2.Enabled = true;
                    mask_doldur();



                }
                else
                {// MessageBox.Show("Böyle bir kitap kaydı bulunamadı");
                }

            }
            catch { MessageBox.Show("Böyle bir kitap kaydı bulunamadı..!"); maskedTextBox2.Text = ""; kitapodunc.ActiveForm.Refresh(); }

        }

    }
}
