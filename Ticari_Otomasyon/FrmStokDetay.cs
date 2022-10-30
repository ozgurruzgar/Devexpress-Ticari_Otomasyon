using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmStokDetay : Form
    {
        public string ad;
        SqlBaglantisi bgl = new SqlBaglantisi();
        public FrmStokDetay()
        {
            InitializeComponent();
        }

        private void FrmStokDetay_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER Where URUNAD='" + ad + "'", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
