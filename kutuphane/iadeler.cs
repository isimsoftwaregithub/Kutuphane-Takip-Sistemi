using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using kutuphane.Database;

namespace kutuphane
{
    public partial class iadeler : Form
    {
        List<view_iade> iade;

        public iadeler()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {

            dataGridView1.AutoGenerateColumns = false;
            DateTime SonGun = DateTime.Now.AddDays(3);

            using (dbDataContext db = new dbDataContext())
            {
                iade = (from f in db.view_iades
                        where
                        f.iadeEdildiMi == false &&
                        (f.odunc_teslimetmesi_gereken_tarih < SonGun ||
                        f.odunc_teslimetmesi_gereken_tarih < DateTime.Now)
                        select f).ToList();
                dataGridView1.DataSource = iade;




            }




        }





        private void r1_Click(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            if (r.Name == "r1")
            {
                dataGridView1.DataSource = iade;
            }
            else if (r.Name == "r2")
            {
                dataGridView1.DataSource = iade.Where(p => p.odunc_teslimetmesi_gereken_tarih < DateTime.Now).ToList();
            }
            else if (r.Name == "r3")
            {
                DateTime SonGun = DateTime.Now.AddDays(3);
                dataGridView1.DataSource = iade.Where(p => p.odunc_teslimetmesi_gereken_tarih < SonGun && p.odunc_teslimetmesi_gereken_tarih >= DateTime.Now).ToList();
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            string _TeslimEtmGerekenTarih = dataGridView1.Rows[e.RowIndex].Cells["Column8"].Value.ToString();


            DateTime dtNow = DateTime.Now;

            DateTime dt_TeslimEtmGerekenTarih = DateTime.Parse(_TeslimEtmGerekenTarih);


            TimeSpan ts = dtNow.Subtract(dt_TeslimEtmGerekenTarih);

            if (ts.TotalDays > 0)
            {
                this.dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;

                double CezaBirimFiyati = 2.5;
                string ceza = string.Format("{1}x{0:c}={2:c}", CezaBirimFiyati, (int)ts.TotalDays, ((int)ts.TotalDays) * CezaBirimFiyati);
                dataGridView1.Rows[e.RowIndex].Cells["Column10"].Value = ceza;
            }



        }


    }
}
