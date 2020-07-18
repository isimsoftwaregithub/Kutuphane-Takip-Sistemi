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
    public partial class yeniuyekaydi : Form
    {
        public yeniuyekaydi()
        {
            InitializeComponent();
        }
       SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
        public void GridDoldur()
        {

            baglanti.Open();
            SqlDataAdapter kda = new SqlDataAdapter("select * from uye_tablo order by uye_adi", baglanti);
            DataSet kds = new DataSet();
            kda.Fill(kds);
            baglanti.Close();
            dataGridView1.DataSource = kds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Üye No";
            dataGridView1.Columns[1].HeaderText = "T.C. No";
            dataGridView1.Columns[2].HeaderText = "Üye Adı";
            dataGridView1.Columns[3].HeaderText = "Üye Soyadı";
            dataGridView1.Columns[4].HeaderText = "Tel";
            dataGridView1.Columns[5].HeaderText = "E-Posta";
            dataGridView1.Columns[6].HeaderText = "Adres";

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 300;
        }
        private void yeniuyekaydi_Load(object sender, EventArgs e)
        {
            this.Location = new Point(205, 0);
            GridDoldur();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("T.C Kimlik numarası girilmesi gereken bir parametredir..!");
            else if (textBox3.Text == "")
                MessageBox.Show("Üye adı girilmesi gereken bir parametredir..!");
            else if (textBox4.Text == "")
                MessageBox.Show("Üye soyadı girilmesi gereken bir parametredir..!");
            else
            {
                try
                {
                    baglanti.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("select * from uye_tablo where uye_tcno='" + textBox2.Text + "'", baglanti);
                    DataSet dataset = new DataSet();
                    adapter.Fill(dataset);

                    if (dataset.Tables[0].Rows.Count == 1)
                    {
                        MessageBox.Show("Daha önce aynı T.C. kimlik numaralı bir üye mevcuttur..!");
                        baglanti.Close();
                    }

                    else
                    {
                        SqlCommand kitapkaydet = new SqlCommand("insert into uye_tablo(uye_tcno,uye_adi,uye_soyadi,uye_tel,uye_eposta,uye_adres) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + maskedTextBox1.Text + "','" + textBox6.Text + "','" + textBox7.Text + "') ", baglanti);
                        try
                        {
                           
                            kitapkaydet.ExecuteNonQuery();
                            MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
                            baglanti.Close();
                            button8.Visible = false;
                            button1.Visible = true;
                            textBox2.Enabled = false;
                            textBox3.Enabled = false;
                            textBox4.Enabled = false;
                            maskedTextBox1.Enabled = false;
                            textBox6.Enabled = false;
                            textBox7.Enabled = false;
                            GridDoldur();
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                            maskedTextBox1.Text = "";
                            textBox6.Text = "";
                            textBox7.Text = "";



                        }
                        catch
                        {
                            MessageBox.Show("Kayıt yapılamadı...!");
                        }
                    }
                }
               catch 
                      {
                          MessageBox.Show("Lütfen bağlantılarınızı kontrol ediniz.!");
                       }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button8.Visible = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
           maskedTextBox1.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
          maskedTextBox1.Text= "";
            textBox6.Text = "";
            textBox7.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Seçmiş olduğunu üyeyi silmek istediğinize emin misiniz?", "Sil", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlCommand uye_sil = new SqlCommand("delete from uye_tablo where uye_no='" + textBox1.Text + "' ", baglanti);
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
                      maskedTextBox1.Text= "";
                        textBox6.Text = "";
                        textBox7.Text = "";



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
            string tcno = (dataGridView1.CurrentRow.Cells[1].Value.ToString());
            string adi = (dataGridView1.CurrentRow.Cells[2].Value.ToString());
            string soyadi = (dataGridView1.CurrentRow.Cells[3].Value.ToString());
            string tel = (dataGridView1.CurrentRow.Cells[4].Value.ToString());
            string eposta = (dataGridView1.CurrentRow.Cells[5].Value.ToString());
            string adres = (dataGridView1.CurrentRow.Cells[6].Value.ToString());

            textBox1.Text = no;
            textBox2.Text = tcno;
            textBox3.Text = adi;
            textBox4.Text = soyadi;
maskedTextBox1.Text = tel;
            textBox6.Text = eposta;
            textBox7.Text = adres;

            button2.Enabled = true;
            button3.Enabled = true;
            button8.Visible = false;
            button1.Visible = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            maskedTextBox1.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Üye No girilmesi gereken bir parametredir..!");
            else if (textBox2.Text == "")
                MessageBox.Show("T.C. Kimlik numarası girilmesi gereken bir parametredir..!");
            else if (textBox3.Text == "")
                MessageBox.Show("Üye adı girilmesi gereken bir parametredir..!");
            else if (textBox4.Text == "")
                MessageBox.Show("Kitab soyadı evi girilmesi gereken bir parametredir..!");
            else
            {
                try
                    {
                        baglanti.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("select * from uye_tablo where uye_tcno='" + textBox2.Text + "'", baglanti);
                        DataSet dataset = new DataSet();
                        adapter.Fill(dataset);

                        if (dataset.Tables[0].Rows.Count == 1)
                            {
                                MessageBox.Show("Daha önce aynı T.C. kimlik numaralı bir üye mevcuttur..!");
                                baglanti.Close();
                            }
                       else
                            {
                                SqlCommand uyeduzelt = new SqlCommand("update uye_tablo set uye_tcno='" + textBox2.Text + "', uye_adi='" + textBox3.Text + "',uye_soyadi='" + textBox4.Text + "',uye_tel='" + maskedTextBox1.Text + "',uye_eposta='" + textBox6.Text + "',uye_adres='" + textBox7.Text + "' where uye_no='" + textBox1.Text + "' ", baglanti);
                                try
                                    {
                                        baglanti.Close();
                                        if (MessageBox.Show("Verilerde değişiklik yapmak istediğinize emin misiniz?", "Değiştir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                            {
                                                baglanti.Open();
                                                uyeduzelt.ExecuteNonQuery();
                                                MessageBox.Show("Kayıt başarılı bir şekilde güncellendi.");
                                                baglanti.Close();
                                                GridDoldur();
                                                textBox1.Text = "";
                                                textBox2.Text = "";
                                                textBox3.Text = "";
                                                textBox4.Text = "";
                                                maskedTextBox1.Text = "";
                                                textBox6.Text = "";
                                                textBox7.Text = "";
                                              }
                                   }
                              catch
                                   {
                                        MessageBox.Show("Kayıt güncellenemedi...!");
                                    }
                        } 

                }
            catch
                {MessageBox.Show("Bağlantılarınızı kontrol ediniz.!");}
            }
            
        
        }

        private void textBox2_CursorChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
           textBox2.BackColor = Color.LightYellow;
           

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.LightYellow;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.White;
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.BackColor = Color.LightYellow;
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
           maskedTextBox1.BackColor = Color.LightYellow;
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            maskedTextBox1.BackColor = Color.White;
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
                e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.
            else if ((int)e.KeyChar == 8)
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
            else
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
        }
    }
}
