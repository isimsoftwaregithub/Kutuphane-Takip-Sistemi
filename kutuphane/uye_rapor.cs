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
    public partial class uye_rapor : Form
    {
        public uye_rapor()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=localhost;Initial Catalog=kutuphanedb;Integrated Security= true");
        private void uye_rapor_Load(object sender, EventArgs e)
        {
            uye_report  rapor = new uye_report();
            DataSet ds = new DataSet();
            ds.Clear();
            SqlDataAdapter adptr = new SqlDataAdapter("select  * from kutuphanedb.dbo.uye_tablo", baglanti);
            adptr.Fill(ds);
            rapor.SetDataSource(ds);
            // rapor.SetParameterValue("param_Tarih", "NULL");
            crystalReportViewer1.ReportSource = rapor;
            crystalReportViewer1.Refresh();
        }
    }
}
