using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace kutuphane
{




    public partial class kitapekle : Form
    {

        public kitapekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
        PrintDocument doc = new PrintDocument();
        kutuphane.Ean13 barcode = new kutuphane.Ean13();
                 
        
        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString( "",new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Black, new PointF(425, 135));
            e.Graphics.DrawString("", new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Black, new PointF(425, 150));
            e.Graphics.DrawString(textBox2.Text, new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Black, new PointF(600, 125));
            e.Graphics.DrawString("Yeri:"+ textBox11.Text, new System.Drawing.Font(new FontFamily("Arial"), 10, FontStyle.Bold), Brushes.Black, new PointF(600, 140));
            //Burası önemli aşağıdaki kod barkodu yazan kod
            barcode.DrawEan13Barcode(e.Graphics, (new PointF(Convert.ToInt32("150"), Convert.ToInt32("10"))));
            
        }
       
        public void GridDoldur()
        {
           
            baglanti.Open();
            SqlDataAdapter kda = new SqlDataAdapter("select k.kitap_no,k.kitap_barkod,k.kitap_isbn,k.kitap_adi,y.yazar_adi,k.kitap_ceviri,t.kategori_adi,e.edinim_adi,yayin_evi,baski_yili,baski_sayisi,cilt_sayisi,baski_yeri,kitap_yeri,aciklamalar from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no inner join kutuphanedb.dbo.edinim_tablo e on k.edinim_no=e.edinim_no order by kitap_adi", baglanti);
            DataSet kds = new DataSet();
            kda.Fill(kds);
            baglanti.Close();
            dataGridView1.DataSource = kds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "K.No";
            dataGridView1.Columns[1].HeaderText = "K.Barkod";
            dataGridView1.Columns[2].HeaderText = "K.ISBN";
            dataGridView1.Columns[3].HeaderText = "Kitap Adı";
            dataGridView1.Columns[4].HeaderText = "Yazar Adı";
            dataGridView1.Columns[5].HeaderText = "Çeviri";
            dataGridView1.Columns[6].HeaderText = "Kategori";
            dataGridView1.Columns[7].HeaderText = "Edinim";
            dataGridView1.Columns[8].HeaderText = "Yayın evi";
            dataGridView1.Columns[9].HeaderText = "Baskı Yılı";
            dataGridView1.Columns[10].HeaderText = "Baskı Sayısı";
            dataGridView1.Columns[11].HeaderText = "Cİlt Sayısı";
            dataGridView1.Columns[12].HeaderText = "Baskı Yeri";
            dataGridView1.Columns[13].HeaderText = "Kitap Yeri/Raf";
            dataGridView1.Columns[14].HeaderText = "Açıklamalar";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 250;
            dataGridView1.Columns[3].Width = 250;
            dataGridView1.Columns[4].Width = 250;
            dataGridView1.Columns[13].Width = 300;
        }
        public void yazaradiDoldur()
        {

            baglanti.Open();
         /*   SqlDataAdapter yda = new SqlDataAdapter("Select * from yazar_tablo", baglanti);
            DataSet yds = new DataSet();
            yda.Fill(yds);
            comboBox1.DataSource = yds.Tables[0];
            comboBox1.DisplayMember = "yazar_adi";
            comboBox1.ValueMember = "yazar_no";
            */
            //
            AutoCompleteStringCollection aCsC = new AutoCompleteStringCollection();
            
            DataTable dt = new DataTable();
            string sql = "Select * From yazar_tablo order by yazar_adi asc";
            SqlDataAdapter da = new SqlDataAdapter(sql, baglanti);
            da.Fill(dt);
            //Bu for döngüsü ile datatable deki verilerimizi,içinde arama yapacağımız koleksiyona teker teker ekliyoruz.
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                aCsC.Add(dt.Rows[i][1].ToString());
               
            }
            //cb combobox ımızın ismi.comboboxımızın hangi koleksiyonu kullanacağını belirtiyoruz.
           comboBox1.AutoCompleteCustomSource = aCsC;
            //combobox ımızı datatable ile dolduruyoruz.
         comboBox1.DataSource = dt;
         comboBox1.DisplayMember = "yazar_adi";
         comboBox1.ValueMember = "yazar_no"; 



            //


            baglanti.Close();

        }
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
        public void edinimDoldur()
        {

            baglanti.Open();
            SqlDataAdapter yda = new SqlDataAdapter("Select * from edinim_tablo", baglanti);
            DataSet yds = new DataSet();
            yda.Fill(yds);
            comboBox3.DataSource = yds.Tables[0];
            comboBox3.DisplayMember = "edinim_adi";
            comboBox3.ValueMember = "edinim_no";


            baglanti.Close();

        }

        private void kitapekle_Load(object sender, EventArgs e)
        {
            /* MessageBox.Show(baglanti.State.ToString());

             GridDoldur();
           
             */
            yazaradiDoldur();
            edinimDoldur();
            turuDoldur();
            GridDoldur();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kitapyazari frm = new kitapyazari();
            frm.MdiParent = anamenu.ActiveForm;
            frm.Show();
            anamenu.baglanti_fonksiyonu();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            turu frm = new turu();
            frm.MdiParent = anamenu.ActiveForm;
            frm.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            edinim frm = new edinim();
            frm.MdiParent = anamenu.ActiveForm;
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
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
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //anamenu.ActiveForm.IsMdiContainer = false;
            
            
        
          
           
            if (textBox12.Text == "")
                MessageBox.Show("Kitap barkod numarası girilmesi gereken bir parametredir..!");
            else if (textBox3.Text == "")
                MessageBox.Show("Kitap ISBN numarası girilmesi gereken bir parametredir..!");
            else if (textBox2.Text == "")
                MessageBox.Show("Kitabın adı girilmesi gereken bir parametredir..!");
            else if (textBox5.Text == "")
                MessageBox.Show("Kitab yayın evi girilmesi gereken bir parametredir..!");
            else
            {
                SqlCommand kitapkaydet = new SqlCommand("insert into kitap_tablo(kitap_barkod,kitap_isbn,kitap_adi,yazar_no,kitap_ceviri,kategori_no,edinim_no,yayin_evi,baski_yili,baski_sayisi,cilt_sayisi,baski_yeri,kitap_yeri,aciklamalar,kitap_durumu) values('"+textBox12.Text+"','" + textBox3.Text + "','" + textBox2.Text + "'," + comboBox1.SelectedValue + ",'" + textBox4.Text + "'," + comboBox2.SelectedValue + "," + comboBox3.SelectedValue + ",'" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox11.Text + "','" + textBox10.Text + "','True') ", baglanti);
                try
                {
                    baglanti.Open();
                    kitapkaydet.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
                    if (MessageBox.Show("Barkodun çıktısını almak istiyormusunuz?", "Çıktı al", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DialogResult yazdırma;
                        yazdırma = printDialog1.ShowDialog();
                        if (yazdırma == DialogResult.OK)
                        {   doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
                            doc.Print();
                        }
                       
                    }
                    baglanti.Close();
                    
                    button8.Visible = false;
                    button1.Visible = true;
                    textBox2.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                    textBox10.Enabled = false;
                    textBox11.Enabled = false;
                    textBox12.Enabled = false;
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    comboBox3.Enabled = false;
                    GridDoldur();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";


                }
                catch
                {
                    MessageBox.Show("Kayıt yapılamadı...!");
                }
            }

        }



        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            turuDoldur();
        }

        private void comboBox3_MouseClick_1(object sender, MouseEventArgs e)
        {
            edinimDoldur();
        }

        private void comboBox1_MouseClick_1(object sender, MouseEventArgs e)
        {
           // yazaradiDoldur();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "")
                MessageBox.Show("Kitap Barkod numarası girilmesi gereken bir parametredir..!");
            else if (textBox3.Text == "")
                MessageBox.Show("Kitap ISBN numarası girilmesi gereken bir parametredir..!");
            else if (textBox2.Text == "")
                MessageBox.Show("Kitabın adı girilmesi gereken bir parametredir..!");
            else if (textBox5.Text == "")
                MessageBox.Show("Kitab yayın evi girilmesi gereken bir parametredir..!");
            else
            {
                SqlCommand kitapduzelt = new SqlCommand("update kitap_tablo set kitap_barkod='"+textBox12.Text+"', kitap_isbn='" + textBox3.Text + "',kitap_adi='" + textBox2.Text + "',yazar_no=" + comboBox1.SelectedValue + ",kitap_ceviri='" + textBox4.Text + "',kategori_no='" + comboBox2.SelectedValue + "',edinim_no='" + comboBox3.SelectedValue + "',yayin_evi='" + textBox5.Text + "',baski_yili='" + textBox6.Text + "',baski_sayisi='" + textBox7.Text + "',cilt_sayisi='" + textBox8.Text + "',baski_yeri='" + textBox9.Text + "',kitap_yeri='" + textBox11.Text + "', aciklamalar='" + textBox10.Text + "' where kitap_no='" + textBox1.Text + "' ", baglanti);
                try
                {
                    if (MessageBox.Show("Verilerde değişiklik yapmak istediğinize emin misiniz?", "Değiştir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                   {
                        baglanti.Open();
                        kitapduzelt.ExecuteNonQuery();
                        MessageBox.Show("Kayıt başarılı bir şekilde güncellendi.");
                        baglanti.Close();
                        GridDoldur();

                        textBox2.Text = "";
                    }
                }
                catch
                      {
                    MessageBox.Show("Kayıt güncellenemedi...!");
                      }

            }




        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string no = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string barkod = (dataGridView1.CurrentRow.Cells[1].Value.ToString());
            string isbn = (dataGridView1.CurrentRow.Cells[2].Value.ToString());
            string kitap_adi = (dataGridView1.CurrentRow.Cells[3].Value.ToString());
            string kitap_yazari = (dataGridView1.CurrentRow.Cells[4].Value.ToString());
            string ceviri = (dataGridView1.CurrentRow.Cells[5].Value.ToString());
            string turu = (dataGridView1.CurrentRow.Cells[6].Value.ToString());
            string edinim = (dataGridView1.CurrentRow.Cells[7].Value.ToString());
            string yayinevi = (dataGridView1.CurrentRow.Cells[8].Value.ToString());
            string baskiyili = (dataGridView1.CurrentRow.Cells[9].Value.ToString());
            string baskisayisi = (dataGridView1.CurrentRow.Cells[10].Value.ToString());
            string ciltsayisi = (dataGridView1.CurrentRow.Cells[11].Value.ToString());
            string baskiyeri = (dataGridView1.CurrentRow.Cells[12].Value.ToString());
            string kitabinyeri = (dataGridView1.CurrentRow.Cells[13].Value.ToString());
            string aciklamalar = (dataGridView1.CurrentRow.Cells[14].Value.ToString());
            textBox1.Text = no;
            textBox2.Text = kitap_adi;
            textBox3.Text = isbn;
            comboBox1.Text = kitap_yazari;
            textBox4.Text = ceviri;
            comboBox2.Text = turu;
            comboBox3.Text = edinim;
            textBox5.Text = yayinevi;
            textBox6.Text = baskiyili;
            textBox7.Text = baskisayisi;
            textBox8.Text = ciltsayisi;
            textBox9.Text = baskiyeri;
            textBox10.Text = aciklamalar;
            textBox11.Text = kitabinyeri;
            textBox12.Text = barkod;
            button2.Enabled = true;
            button3.Enabled = true;
            button8.Visible = false;
            button1.Visible = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;
            textBox11.Enabled = true;
            textBox12.Enabled = true;
            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (MessageBox.Show("Seçmiş olduğunu kitabı silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand kitap_sil = new SqlCommand("delete from kitap_tablo where kitap_no='" + textBox1.Text + "' ", baglanti);
                    try
                    {
                        baglanti.Open();
                        kitap_sil.ExecuteNonQuery();
                        MessageBox.Show("Kayıt başarılı bir şekilde silindi.");
                        baglanti.Close();
                        GridDoldur();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox9.Text = "";
                        textBox10.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        comboBox3.Text = "";

                        baglanti.Close();
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

        private void label15_Click(object sender, EventArgs e)
        {

        }


        private void textBox12_Leave(object sender, EventArgs e)
        {
            textBox12.BackColor = Color.White;
            string barkod;
            barkod = textBox12.Text;
            if (textBox12.TextLength >= 13)
            {
                pictureBox1.Visible = true;
                //bu kod barkodun ilk 2 hanesi -ülke kodu
                barcode.CountryCode = barkod.Substring(0, 3);
                //Bu kod üretici-imalatçı numarası -bu kısımın legal illegal gibi durumları da var
                barcode.ManufacturerCode = barkod.Substring(3, 4);
                //Bu kod öğrenci -ID si 
                barcode.ProductCode = barkod.Substring(7, 5);
                //Bu kısım boş geçilsede birşey değişmiyor EAN-13 te zaten 12 veri okuyorsunuz ,bu sayı  barkodun sonunda oluyor.
                barcode.ChecksumDigit = "5";
                pictureBox1.Image = barcode.CreateBitmap();
            }
           
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
                e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.
            else if ((int)e.KeyChar == 8)
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            else
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
                e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.
            else if ((int)e.KeyChar == 8)
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            else
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
                e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.
            else if ((int)e.KeyChar == 8)
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            else
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
                e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.
            else if ((int)e.KeyChar == 8)
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            else
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
          
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

               

                DateTime dtnow = DateTime.Now;
                string yil = dtnow.ToString("yy");
                string saniye = dtnow.ToString("ss");
                string dakika = dtnow.ToString("mm"); ;

                string gun = dtnow.ToString("dd");
               
                  
                
                textBox12.Enabled = false;
                textBox12.Text = "";
                textBox12.Text = "936" + dakika + saniye + "0" + yil;

              
                
                pictureBox1.Visible = true;
                //bu kod barkodun ilk 2 hanesi -ülke kodu
                barcode.CountryCode = "936";

                //Bu kod üretici-imalatçı numarası -bu kısımın legal illegal gibi durumları da var
                barcode.ManufacturerCode = dakika + saniye;

                //Bu kod öğrenci -ID si 
                barcode.ProductCode = "0" + gun+yil;

                //Bu kısım boş geçilsede birşey değişmiyor EAN-13 te zaten 12 veri okuyorsunuz ,bu sayı  barkodun sonunda oluyor.
                barcode.ChecksumDigit = "5";


                


                textBox12.Text = barcode.CountryCode + barcode.ManufacturerCode + barcode.ProductCode + barcode.ChecksumDigit;

                pictureBox1.Image = barcode.CreateBitmap();
            }
            else
            {
                textBox12.Text = "";
                textBox12.Enabled = true;
            }
        }

        private void textBox12_Enter(object sender, EventArgs e)
        {
            textBox12.BackColor = Color.LightYellow;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.LightYellow;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.LightYellow;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.White;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.LightYellow;
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            textBox5.BackColor = Color.White;
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.BackColor = Color.LightYellow;
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            textBox6.BackColor = Color.White;
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            textBox6.BackColor = Color.LightYellow;
        }

        private void textBox7_Leave(object sender, EventArgs e)
        {
            textBox7.BackColor = Color.White;
        }

        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.BackColor = Color.LightYellow;
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            textBox8.BackColor = Color.White;
        }

        private void textBox8_Enter(object sender, EventArgs e)
        {
            textBox8.BackColor = Color.LightYellow;
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            textBox9.BackColor = Color.White;
        }

        private void textBox9_Enter(object sender, EventArgs e)
        {
            textBox9.BackColor = Color.LightYellow;
        }

        private void textBox11_Leave(object sender, EventArgs e)
        {
            textBox11.BackColor = Color.White;
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            textBox11.BackColor = Color.LightYellow;
        }

        private void textBox10_Leave(object sender, EventArgs e)
        {
            textBox10.BackColor = Color.White;
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            textBox10.BackColor = Color.LightYellow;
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            yazaradiDoldur();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
         
        }

        

       
    }
}