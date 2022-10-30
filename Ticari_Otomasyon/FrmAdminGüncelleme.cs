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
    public partial class FrmAdminGüncelleme : Form
    {
        public FrmAdminGüncelleme()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmAyarlar fr = new FrmAyarlar();
            this.Close();
            fr.Show();
        }
        void AdminListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmAdminGüncelleme_Load(object sender, EventArgs e)
        {
            AdminListesi();
        }
        void Temizle()
        {
            TxtKadi.Text = "";
            TxtSifre.Text = "";
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtKadi.Text = dr["KULLANICIAD"].ToString();
                TxtSifre.Text = dr["SIFRE"].ToString();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
           DialogResult sor = MessageBox.Show("Bu Admin Bilgilerini Güncellemek İstediğine Emin Misin?", "SORU", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
           if (sor == DialogResult.Yes)
            {
              SqlCommand komut = new SqlCommand("Update TBL_ADMIN set SIFRE=@P1 Where KULLANICIAD=@P2", bgl.baglanti());
              komut.Parameters.AddWithValue("@P1", TxtSifre.Text);
              komut.Parameters.AddWithValue("@P2", TxtKadi.Text);
              komut.ExecuteNonQuery();
              bgl.baglanti().Close();
              MessageBox.Show("Admin Güncellendi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                AdminListesi();
            }
        }

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Bu Admin Silmek İstediğine Emin Misin?", "SORU", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TBL_ADMIN where KULLANICIAD=@P1", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", TxtKadi.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Admin Silindi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();
                AdminListesi();
            }
        }
    }
}
