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
    public partial class edinim : Form
    {
        public edinim()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
        public void GridDoldur()
        {

            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from edinim_tablo", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "E.No";
            dataGridView1.Columns[1].HeaderText = "Edinim Türü";
            dataGridView1.Columns[0].Width = 50;
            baglanti.Close();

        }
        private void edinim_Load(object sender, EventArgs e)
        {
         GridDoldur();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {

                SqlCommand edinimekle = new SqlCommand("insert into edinim_tablo(edinim_adi) values('" + textBox2.Text + "') ", baglanti);
                try
                {
                    baglanti.Open();
                    edinimekle.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı bir şekilde eklendi.");
                    baglanti.Close();
                    GridDoldur();

                    textBox2.Text = "";
                    baglanti.Close();
                }
                catch
                {
                    MessageBox.Show("Kayıt yapılamadı...!");
                }


            }
            else
                MessageBox.Show("Lütfen boş geçmeyiniz..!");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != "")
            {

                SqlCommand edinimduzelt = new SqlCommand("update edinim_tablo set edinim_adi='" + textBox2.Text + "' where edinim_no='" + textBox1.Text + "' ", baglanti);
                try
                {
                    baglanti.Open();
                    edinimduzelt.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı bir şekilde güncellendi.");
                    baglanti.Close();
                    GridDoldur();

                    textBox2.Text = "";
                }
                catch
                {
                    MessageBox.Show("Kayıt güncellenemedi...!");
                }


            }
            else
                MessageBox.Show("Lütfen boş geçmeyiniz..!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {

                SqlCommand sil = new SqlCommand("delete from edinim_tablo where edinim_no='" + textBox1.Text + "' ", baglanti);
                try
                {
                    baglanti.Open();
                    sil.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarılı bir şekilde silindi.");
                    baglanti.Close();
                    GridDoldur();
                    textBox2.Text = "";
                    baglanti.Close();
                }
                catch
                {
                    MessageBox.Show("Kayıt silinemedi...!");
                }


            }
            else
                MessageBox.Show("Lütfen boş geçmeyiniz..!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";

            button2.Enabled = false;
            button3.Enabled = false;
            button5.Visible = false;
            button1.Visible = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string no = (dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string edinim = (dataGridView1.CurrentRow.Cells[1].Value.ToString());

            textBox1.Text = no;
            textBox2.Text = edinim;

            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button5.Enabled = true;
            button5.Visible = true;
            button1.Visible = false;
        }
    }
}
