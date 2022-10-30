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
    public partial class FrmHareketler : Form
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        void MusteriHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute MUSTERIHAREKETLERI",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute FIRMAHAREKETLERI", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        public FrmHareketler()
        {
            InitializeComponent();
        }

        private void FrmHareketler_Load(object sender, EventArgs e)
        {
            MusteriHareketleri();
            FirmaHareketleri();
        }
    }
}
