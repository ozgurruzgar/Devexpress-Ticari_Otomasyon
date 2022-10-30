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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_NOTLAR",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Temizle()
        {
            Txtid.Text = "";
            TxtBaslik.Text = "";
            TxtHitap.Text = "";
            CmbOlusturan.Text = "";
            MskSaat.Text = "";
            MskTarih.Text = "";
            RchDetay.Text = "";
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            Listele();
            Temizle();
            PersonelListesi();
        }
        void PersonelListesi()
        {
            CmbOlusturan.Items.Clear();
            SqlCommand Komut = new SqlCommand("Execute Yetkililer", bgl.baglanti());
            SqlDataReader dr = Komut.ExecuteReader();
            while(dr.Read())
            {
                CmbOlusturan.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR (NOTTARIH,NOTSAAT,NOTBASLIK,NOTOLUSTURAN,NOTHITAP,NOTDETAY) Values (@P1,@P2,@P3,@P4,@P5,@P6)",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1",MskTarih.Text);
            komut.Parameters.AddWithValue("@P2",MskSaat.Text);
            komut.Parameters.AddWithValue("@P3",TxtBaslik.Text);
            komut.Parameters.AddWithValue("@P4",CmbOlusturan.Text);
            komut.Parameters.AddWithValue("@P5",TxtHitap.Text);
            komut.Parameters.AddWithValue("@P6",RchDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Sisteme Eklendi!!!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Bu Notu Silmek İstediğinize Emin Misiniz?","Uyarı",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if(sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TBL_NOTLAR Where NOTID=@P1",bgl.baglanti());
                komut.Parameters.AddWithValue("@P1",Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Not Sistemden Silindi!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Bu Notu Güncellemek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Update TBL_NOTLAR set NOTTARIH=@P1,NOTSAAT=@P2,NOTBASLIK=@P3,NOTOLUSTURAN=@P4,NOTHITAP=@P5,NOTDETAY=@P6 Where NOTID=@P7",bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", MskTarih.Text);
                komut.Parameters.AddWithValue("@P2", MskSaat.Text);
                komut.Parameters.AddWithValue("@P3", TxtBaslik.Text);
                komut.Parameters.AddWithValue("@P4", CmbOlusturan.Text);
                komut.Parameters.AddWithValue("@P5", TxtHitap.Text);
                komut.Parameters.AddWithValue("@P6", RchDetay.Text);
                komut.Parameters.AddWithValue("@P7", Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Not Güncellendi!!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["NOTID"].ToString();
                MskTarih.Text = dr["NOTTARIH"].ToString();
                MskSaat.Text = dr["NOTSAAT"].ToString();
                TxtBaslik.Text = dr["NOTBASLIK"].ToString();
                CmbOlusturan.Text = dr["NOTOLUSTURAN"].ToString();
                TxtHitap.Text = dr["NOTHITAP"].ToString();
                RchDetay.Text = dr["NOTDETAY"].ToString();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
