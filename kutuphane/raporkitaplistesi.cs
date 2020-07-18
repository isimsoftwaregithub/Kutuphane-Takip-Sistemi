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
    public partial class raporkitaplistesi : Form
    {
        public raporkitaplistesi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
        
       
        private void raporkitaplistesi_Load(object sender, EventArgs e)
        {

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kitap_report rapor = new kitap_report();
            DataSet ds = new DataSet();
            ds.Clear();
            SqlDataAdapter adptr = new SqlDataAdapter("select k.kitap_barkod,k.kitap_adi,y.yazar_adi,t.kategori_adi,e.edinim_adi,k.kitap_yeri from kutuphanedb.dbo.kitap_tablo as k inner join kutuphanedb.dbo.yazar_tablo as y on y.yazar_no=k.yazar_no inner join kutuphanedb.dbo.kategori_tablo as t on t.kategori_no=k.kategori_no inner join kutuphanedb.dbo.edinim_tablo as e on e.edinim_no=k.edinim_no", baglanti);
            adptr.Fill(ds);
            rapor.SetDataSource(ds);

            tumkitaplar_report tum_rapor = new tumkitaplar_report();
            DataSet tum_ds = new DataSet();
           tum_ds.Clear();
            SqlDataAdapter tum_adptr = new SqlDataAdapter("select k.kitap_barkod,k.kitap_adi,y.yazar_adi,t.kategori_adi,e.edinim_adi,k.kitap_yeri from kutuphanedb.dbo.kitap_tablo as k inner join kutuphanedb.dbo.yazar_tablo as y on y.yazar_no=k.yazar_no inner join kutuphanedb.dbo.kategori_tablo as t on t.kategori_no=k.kategori_no inner join kutuphanedb.dbo.edinim_tablo as e on e.edinim_no=k.edinim_no", baglanti);
           tum_adptr.Fill(ds);
           tum_rapor.SetDataSource(tum_ds);

           yazar_report yazar_rapor = new yazar_report ();
           DataSet yazar_ds = new DataSet();
           yazar_ds.Clear();
           SqlDataAdapter yazar_adptr = new SqlDataAdapter("select k.kitap_barkod,k.kitap_adi,y.yazar_adi,t.kategori_adi,e.edinim_adi,k.kitap_yeri from kutuphanedb.dbo.kitap_tablo as k inner join kutuphanedb.dbo.yazar_tablo as y on y.yazar_no=k.yazar_no inner join kutuphanedb.dbo.kategori_tablo as t on t.kategori_no=k.kategori_no inner join kutuphanedb.dbo.edinim_tablo as e on e.edinim_no=k.edinim_no", baglanti);
           yazar_adptr.Fill(yazar_ds);
           yazar_rapor.SetDataSource(yazar_ds);

           kategori_report kategori_rapor = new kategori_report();
           DataSet kategori_ds = new DataSet();
           kategori_ds.Clear();
           SqlDataAdapter kategori_adptr = new SqlDataAdapter("select k.kitap_barkod,k.kitap_adi,y.yazar_adi,t.kategori_adi,e.edinim_adi,k.kitap_yeri from kutuphanedb.dbo.kitap_tablo as k inner join kutuphanedb.dbo.yazar_tablo as y on y.yazar_no=k.yazar_no inner join kutuphanedb.dbo.kategori_tablo as t on t.kategori_no=k.kategori_no inner join kutuphanedb.dbo.edinim_tablo as e on e.edinim_no=k.edinim_no", baglanti);
           kategori_adptr.Fill(kategori_ds);
           kategori_rapor.SetDataSource(kategori_ds);

           edinim_report  edinim_rapor = new edinim_report();
           DataSet edinim_ds = new DataSet();
           edinim_ds.Clear();
           SqlDataAdapter edinim_adptr = new SqlDataAdapter("select k.kitap_barkod,k.kitap_adi,y.yazar_adi,t.kategori_adi,e.edinim_adi,k.kitap_yeri from kutuphanedb.dbo.kitap_tablo as k inner join kutuphanedb.dbo.yazar_tablo as y on y.yazar_no=k.yazar_no inner join kutuphanedb.dbo.kategori_tablo as t on t.kategori_no=k.kategori_no inner join kutuphanedb.dbo.edinim_tablo as e on e.edinim_no=k.edinim_no", baglanti);
           edinim_adptr.Fill(edinim_ds);
           edinim_rapor.SetDataSource(edinim_ds);

            /*TÜMÜ
            KİTAP ADINA GÖRE
            YAZAR ADINA GÖRE
            KATEGORİSİNE GÖRE
            EDİNİM ŞEKLİNE GÖRE*/
           if (comboBox1.Text == "TÜMÜ")
           {
               tum_rapor.SetParameterValue("param_tumu", "*" + textBox1.Text + "*");
               crystalReportViewer2.ReportSource = tum_rapor;
               crystalReportViewer2.Visible = true;
               crystalReportViewer1.Visible = false;
               crystalReportViewer3.Visible = false;
               crystalReportViewer4.Visible = false;
               crystalReportViewer5.Visible = false;
           }
           else if (comboBox1.Text == "KİTAP ADINA GÖRE")
           {
              
               rapor.SetParameterValue("param_kitap_adi", "*" + textBox1.Text + "*");
               crystalReportViewer1.ReportSource = rapor;
               crystalReportViewer1.Visible = true;
               crystalReportViewer2.Visible = false;
               crystalReportViewer3.Visible = false;
               crystalReportViewer4.Visible = false;
               crystalReportViewer5.Visible = false;

           }
           else if (comboBox1.Text == "YAZAR ADINA GÖRE")
           {
              yazar_rapor.SetParameterValue("param_yazar_adi", "*" + textBox1.Text + "*");
               crystalReportViewer3.ReportSource = yazar_rapor;
               crystalReportViewer1.Visible = false;
               crystalReportViewer2.Visible = false;
               crystalReportViewer3.Visible = true;
               crystalReportViewer4.Visible = false;
               crystalReportViewer5.Visible = false;
           }
           else if (comboBox1.Text == "KATEGORİSİNE GÖRE")
           {
               kategori_rapor.SetParameterValue("param_kategori_adi", "*" + textBox1.Text + "*");
               crystalReportViewer4.ReportSource = kategori_rapor;
               crystalReportViewer1.Visible = false;
               crystalReportViewer2.Visible = false;
               crystalReportViewer3.Visible = false;
               crystalReportViewer4.Visible = true;
               crystalReportViewer5.Visible = false;
           }
           else if (comboBox1.Text == "EDİNİM ŞEKLİNE GÖRE")
           {
               edinim_rapor.SetParameterValue("param_edinim_adi", "*" + textBox1.Text + "*");
               crystalReportViewer5.ReportSource = edinim_rapor;
               crystalReportViewer1.Visible = false;
               crystalReportViewer2.Visible = false;
               crystalReportViewer3.Visible = false;
               crystalReportViewer4.Visible = false;
               crystalReportViewer5.Visible = true;

           }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
