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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl= new SqlBaglantisi();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_URUNLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
        }
        void Temizle()
        {
            Txtid.Text = "";
            TxtAd.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            MskYil.Text = "";
            NudAdet.Value = 0;
            TxtAFiyat.Text = "";
            TxtSFiyat.Text = "";
            RchDetay.Text = "";
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Ürün Ekleme || Toollardaki SQL'e Verileri Kaydetme
            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",TxtAd.Text);
            komut.Parameters.AddWithValue("@p2",TxtMarka.Text);
            komut.Parameters.AddWithValue("@p3",TxtModel.Text);
            komut.Parameters.AddWithValue("@p4",MskYil.Text);
            komut.Parameters.AddWithValue("@p5",int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6",decimal.Parse(TxtAFiyat.Text));
            komut.Parameters.AddWithValue("@p7",decimal.Parse(TxtSFiyat.Text));
            komut.Parameters.AddWithValue("@p8",RchDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Sisteme Eklendi!!!","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            // Tıkladığımızda Satırdaki Verileri Toollara Aktarma
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtid.Text = dr["ID"].ToString();
            TxtAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["MARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            MskYil.Text = dr["YIL"].ToString();
            NudAdet.Value = decimal.Parse(dr["ADET"].ToString());
            TxtAFiyat.Text = dr["ALISFIYAT"].ToString();
            TxtSFiyat.Text = dr["SATISFIYAT"].ToString();
            RchDetay.Text = dr["DETAY"].ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Ürün Silme || Sql'deki Veriyi İd'ye Göre Silme
            SqlCommand komut = new SqlCommand("Delete from TBL_URUNLER Where ID=@P1",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Sistemden Silindi!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            //Ürün Bilgilerini Güncelleme || İd2ye Göre Ürün Bilgilerini Güncelleme
            SqlCommand komut = new SqlCommand("Update TBL_URUNLER set URUNAD=@P1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 where ID=@P9",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtMarka.Text);
            komut.Parameters.AddWithValue("@P3", TxtModel.Text);
            komut.Parameters.AddWithValue("@P4", MskYil.Text);
            komut.Parameters.AddWithValue("@P5", int.Parse((NudAdet.Value).ToString()));
            komut.Parameters.AddWithValue("@P6", decimal.Parse(TxtAFiyat.Text));
            komut.Parameters.AddWithValue("@P7", decimal.Parse(TxtSFiyat.Text));
            komut.Parameters.AddWithValue("@P8", RchDetay.Text);
            komut.Parameters.AddWithValue("@P9", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgileri Güncellendi!!!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Listele();
            Temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
