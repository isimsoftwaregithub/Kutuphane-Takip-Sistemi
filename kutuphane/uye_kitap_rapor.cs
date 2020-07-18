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
    public partial class uye_kitap_rapor : Form
    {
        public uye_kitap_rapor()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "")
            {
                try
                {
                    uye_kitap_report rapor = new uye_kitap_report();
                    DataSet ds = new DataSet();
                    ds.Clear();
                    SqlDataAdapter adptr = new SqlDataAdapter("select  u.uye_tcno,u.uye_adi,u.uye_soyadi, k.kitap_barkod,k.kitap_adi,y.yazar_adi,t.kategori_adi,o.odunc_alim_tarihi,o.odunc_teslim_tarihi,o.odunc_no from kutuphanedb.dbo.odunc_tablo o inner join kutuphanedb.dbo.uye_tablo u on u.uye_no=o.uye_no inner join kutuphanedb.dbo.kitap_tablo k on o.kitap_no=k.kitap_no inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no ORDER BY o.odunc_no DESC", baglanti);
                    adptr.Fill(ds);
                    rapor.SetDataSource(ds);
                    rapor.SetParameterValue("param_tc", maskedTextBox1.Text);
                    crystalReportViewer1.ReportSource = rapor;
                    crystalReportViewer1.Visible = true;
                }
                catch
                {
                    MessageBox.Show("Geçerli bir kimlik no giriniz.!");
                }
            }
            else
                MessageBox.Show("Lütfen t.c. kimlik no'yu boş bırakmayınız.!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void uye_kitap_rapor_Load(object sender, EventArgs e)
        {
          //  crystalReportViewer1.Visible = false;
        }
    }
}
