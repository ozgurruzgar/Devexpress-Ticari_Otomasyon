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
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void MusteriGetir()
        {
            //Müşteri Verilerini Sql'den Çekme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_MUSTERILER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void İller()
        {
            //İlleri Combobox'a Aktarma
            SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER",bgl.baglanti());
            SqlDataReader dr= komut.ExecuteReader();
            while(dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[0]);
                bgl.baglanti().Close();
            } 
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            MusteriGetir();
            İller();
        }

        private void Cmbil_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Şehirlere Göre İlçeleri Combobox'a Aktarma
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut2 = new SqlCommand("Select ILCE From TBL_ILCELER Where SEHIR=@S1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@S1",Cmbil.SelectedIndex + 1 );
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                Cmbilce.Properties.Items.Add(dr2[0]);
            }
            bgl.baglanti().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Müşteri Ekleme
            SqlCommand komut3 = new SqlCommand("insert into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10)", bgl.baglanti());
            komut3.Parameters.AddWithValue("@P1",TxtAd.Text);
            komut3.Parameters.AddWithValue("@P2",TxtSoyad.Text);
            komut3.Parameters.AddWithValue("@P3",MskTel1.Text);
            komut3.Parameters.AddWithValue("@P4",MskTel2.Text);
            komut3.Parameters.AddWithValue("@P5",MskTC.Text);
            komut3.Parameters.AddWithValue("@P6",TxtMail.Text);
            komut3.Parameters.AddWithValue("@P7",Cmbil.Text);
            komut3.Parameters.AddWithValue("@P8",Cmbilce.Text);
            komut3.Parameters.AddWithValue("@P9",RchAdres.Text);
            komut3.Parameters.AddWithValue("@P10",TxtVDaire.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri Sisteme Eklendi!!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            MusteriGetir();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Müşteri Silme || Silmek İstediğine Emin Misin Diye Sorma
            DialogResult dr = MessageBox.Show("Bu Müşteriyi Silmek İstediğine Emin Misin ? ","Uyarı",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                SqlCommand komut4 = new SqlCommand("Delete From TBL_MUSTERILER Where ID=@P1", bgl.baglanti());
                komut4.Parameters.AddWithValue("@P1", Txtid.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Müşteri Sistemden Silindi!!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MusteriGetir();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //Verileri Toollara Aktarma
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTel1.Text = dr["TELEFON"].ToString();
                MskTel2.Text = dr["TELEFON2"].ToString();
                MskTC.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtVDaire.Text = dr["VERGIDAIRE"].ToString();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            //Müşteri Güncelleme || Bu Müşterinin Bilgilerini Güncellemek İstediğine Emin Misin Diye Sorma
            DialogResult updt = MessageBox.Show("Bu Müşterinin Bilgilerini Güncellemek İstediğine Emin Misin ? ", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (updt == DialogResult.Yes)
            {
                SqlCommand komut4 = new SqlCommand("Update TBL_MUSTERILER set AD=@P1,SOYAD=@P2,TELEFON=@P3,TELEFON2=@P4,TC=@P5,MAIL=@P6,IL=@P7,ILCE=@P8,ADRES=@P9,VERGIDAIRE=@P10 Where ID=@P11", bgl.baglanti());
                komut4.Parameters.AddWithValue("@P1", TxtAd.Text);
                komut4.Parameters.AddWithValue("@P2", TxtSoyad.Text);
                komut4.Parameters.AddWithValue("@P3", MskTel1.Text);
                komut4.Parameters.AddWithValue("@P4", MskTel2.Text);
                komut4.Parameters.AddWithValue("@P5", MskTC.Text);
                komut4.Parameters.AddWithValue("@P6", TxtMail.Text);
                komut4.Parameters.AddWithValue("@P7", Cmbil.Text);
                komut4.Parameters.AddWithValue("@P8", Cmbilce.Text);
                komut4.Parameters.AddWithValue("@P9", RchAdres.Text);
                komut4.Parameters.AddWithValue("@P10", TxtVDaire.Text);
                komut4.Parameters.AddWithValue("@P11", Txtid.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Müşteri Bilgileri Güncellendi!!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MusteriGetir();
            }
        }
    }
}
