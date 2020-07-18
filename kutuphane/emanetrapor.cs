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
    public partial class emanetrapor : Form
    {
        public emanetrapor()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
         
        private void emanetrapor_Load(object sender, EventArgs e)
           {
              emanet_raport rapor = new emanet_raport();
               DataSet ds = new DataSet();
               ds.Clear();
               SqlDataAdapter adptr = new SqlDataAdapter("select  k.kitap_barkod,k.kitap_adi,u.uye_adi,u.uye_soyadi,y.yazar_adi,t.kategori_adi,o.odunc_teslim_tarihi from kutuphanedb.dbo.kitap_tablo k inner join kutuphanedb.dbo.yazar_tablo y on k.yazar_no=y.yazar_no  inner join kutuphanedb.dbo.kategori_tablo t on k.kategori_no=t.kategori_no   inner join kutuphanedb.dbo.edinim_tablo e on k.edinim_no=e.edinim_no   inner join kutuphanedb.dbo.odunc_tablo o on k.kitap_no=o.kitap_no   inner join kutuphanedb.dbo.uye_tablo u on u.uye_no=o.uye_no where o.odunc_teslim_tarihi is null", baglanti);
               adptr.Fill(ds);
               rapor.SetDataSource(ds);
              // rapor.SetParameterValue("param_Tarih", "NULL");
               crystalReportViewer1.ReportSource = rapor;
               crystalReportViewer1.Refresh();

        }
    
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
