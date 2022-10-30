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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void AdminListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_ADMIN",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Temizle()
        {
            TxtKadi.Text = "";
            TxtSifre.Text = "";
            TxtMail.Text = "";
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            AdminListesi();
            Temizle();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtKadi.Text = dr["KULLANICIAD"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                TxtSifre.Text = dr["SIFRE"].ToString();
            }
        }
        private void Btnİslem_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_ADMIN (KULLANICIAD,SIFRE,MAIL) Values (@P1,@P2,@P3)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtKadi.Text);
            komut.Parameters.AddWithValue("@P2", TxtSifre.Text);
            komut.Parameters.AddWithValue("@P3", TxtMail.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Admin Eklendi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Temizle();
            AdminListesi();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmAdminGüncelleme fr = new FrmAdminGüncelleme();
            if (fr != null )
            {
                fr.Show();
                this.Close();
            }
        }
    }
}
