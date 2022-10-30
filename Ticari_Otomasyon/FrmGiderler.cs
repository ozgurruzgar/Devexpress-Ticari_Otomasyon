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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void GiderListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_GIDERLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Temizle()
        {
            Txtid.Text = "";
            CmbAy.Text = "";
            CmbYil.Text = "";
            TxtElektrik.Text = "";
            TxtSu.Text = "";
            TxtDogalgaz.Text = "";
            Txtİnternet.Text = "";
            TxtMaaslar.Text = "";
            TxtEkstra.Text = "";
            RchNotlar.Text = "";
        }


        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            GiderListesi();
            Temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtid.Text = dr["ID"].ToString();
            CmbAy.Text = dr["AY"].ToString();
            CmbYil.Text = dr["YIL"].ToString();
            TxtElektrik.Text = dr["ELEKTRIK"].ToString();
            TxtSu.Text = dr["SU"].ToString();
            TxtDogalgaz.Text = dr["DOGALGAZ"].ToString();
            Txtİnternet.Text = dr["INTERNET"].ToString(); 
            TxtMaaslar.Text = dr["MAASLAR"].ToString();
            TxtEkstra.Text = dr["EKSTRA"].ToString();
            RchNotlar.Text = dr["NOTLAR"].ToString();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1",CmbAy.Text);
            komut.Parameters.AddWithValue("@P2",CmbYil.Text);
            komut.Parameters.AddWithValue("@P3",decimal.Parse(TxtElektrik.Text));
            komut.Parameters.AddWithValue("@P4",decimal.Parse(TxtSu.Text));
            komut.Parameters.AddWithValue("@P5",decimal.Parse(TxtDogalgaz.Text));
            komut.Parameters.AddWithValue("@P6",decimal.Parse(Txtİnternet.Text));
            komut.Parameters.AddWithValue("@P7",decimal.Parse(TxtMaaslar.Text));
            komut.Parameters.AddWithValue("@P8",decimal.Parse(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@P9",RchNotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Gider Eklendi!!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            GiderListesi();
            Temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Bu Gideri Sİlmek İstediğnize Emin Misniz?","Uyarı",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
            if(sor ==DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TBL_GIDERLER where ID=@P1",bgl.baglanti());
                komut.Parameters.AddWithValue("@P1",Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Gider Silindi!!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GiderListesi();
                Temizle();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Bu Gideri Güncellemek İstediğnize Emin Misniz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Update TBL_GIDERLER set AY=@P1,YIL=@P2,ELEKTRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6,MAASLAR=@P7,EKSTRA=@P8,NOTLAR=@P9 where ID=@P10", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", CmbAy.Text);
                komut.Parameters.AddWithValue("@P2", CmbYil.Text);
                komut.Parameters.AddWithValue("@P3", decimal.Parse(TxtElektrik.Text));
                komut.Parameters.AddWithValue("@P4", decimal.Parse(TxtSu.Text));
                komut.Parameters.AddWithValue("@P5", decimal.Parse(TxtDogalgaz.Text));
                komut.Parameters.AddWithValue("@P6", decimal.Parse(Txtİnternet.Text));
                komut.Parameters.AddWithValue("@P7", decimal.Parse(TxtMaaslar.Text));
                komut.Parameters.AddWithValue("@P8", decimal.Parse(TxtEkstra.Text));
                komut.Parameters.AddWithValue("@P9", RchNotlar.Text);
                komut.Parameters.AddWithValue("@P10", Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Gider Bilgileri Güncellendi!!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GiderListesi();
                Temizle();
            }
        }
    }
}
