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
    public partial class FrmFaturaÜrünDüzenleme : Form
    {
        public FrmFaturaÜrünDüzenleme()
        {
            InitializeComponent();
        }
        public string urunid;
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmFaturaÜrünDüzenleme_Load(object sender, EventArgs e)
        {
            TxtUrunİd.Text = urunid.ToString();
            SqlCommand komut = new SqlCommand("Select * From TBL_FATURADETAY Where FATURAURUNID=@P1",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1",urunid);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                TxturunAd.Text = dr[1].ToString();
                TxtMiktar.Text = dr[2].ToString();
                TxtFiyat.Text = dr[3].ToString();
                TxtTutar.Text = dr[4].ToString();
                TxtFaturaİd.Text = dr[5].ToString();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Bu Ürünün Bilgilerini Güncellemek İstediğinize Emin Misiniz?","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Question);
            if(sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Update TBL_FATURADETAY set URUNAD=@P1,MIKTAR=@P2,FIYAT=@P3,TUTAR=@P4 Where FATURAURUNID=@P5",bgl.baglanti());
                komut.Parameters.AddWithValue("@P1",TxturunAd.Text);
                komut.Parameters.AddWithValue("@P2",TxtMiktar.Text);
                komut.Parameters.AddWithValue("@P3",decimal.Parse(TxtFiyat.Text));
                komut.Parameters.AddWithValue("@P4",decimal.Parse(TxtTutar.Text));
                komut.Parameters.AddWithValue("@P5",TxtUrunİd.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("Ürün Bilgileri Güncellendi!!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                bgl.baglanti().Close();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

        }
    }
}
