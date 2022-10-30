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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void İller()
        {
            //İlleri Combobox'ta Listeleme
            SqlCommand komut = new SqlCommand("Select SEHIR from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void Temizle()
        {
            Txtid.Text = "";
            TxtAd.Text = "";
            TxtGörev.Text = "";
            TxtMail.Text = "";
            TxtSoyad.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            MskTC.Text = "";
            MskTel1.Text = "";
            RchAdres.Text = "";
        }
        private void Cmbil_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            //İllere Göre İlçeleri Listeleme
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER where SEHIR=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            İller();
            Temizle();
            PersonelListesi();
        }
        void PersonelListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            //Personel Bilgilerini Update Etme Ve Emin Misin Diye Sorma
            DialogResult sor = MessageBox.Show("Bu Personelin Bilgilerini Güncellemek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Update TBL_PERSONELLER set AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7,GOREV=@P8,ADRES=@P9 where ID=@P10", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", TxtAd.Text);
                komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
                komut.Parameters.AddWithValue("@P3", MskTel1.Text);
                komut.Parameters.AddWithValue("@P4", MskTC.Text);
                komut.Parameters.AddWithValue("@P5", TxtMail.Text);
                komut.Parameters.AddWithValue("@P6", Cmbil.Text);
                komut.Parameters.AddWithValue("@P7", Cmbilce.Text);
                komut.Parameters.AddWithValue("@P8", TxtGörev.Text);
                komut.Parameters.AddWithValue("@P9", RchAdres.Text);
                komut.Parameters.AddWithValue("@P10", Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personelin Bilgileri Güncellenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PersonelListesi();
                Temizle();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            //Personel Bilgilerini Silme Ve Emin Misin Diye Sorma
            DialogResult sor = MessageBox.Show("Bu Personelin Bilgilerini Silmek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TBL_PERSONELLER Where ID=@P1",bgl.baglanti());
                komut.Parameters.AddWithValue("@P1",Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Personelin Bilgileri Silinmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PersonelListesi();
                Temizle();
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // Yeni Personel Ekleme
            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,GOREV,ADRES) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1",TxtAd.Text);
            komut.Parameters.AddWithValue("@P2",TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3",MskTel1.Text);
            komut.Parameters.AddWithValue("@P4",MskTC.Text);
            komut.Parameters.AddWithValue("@P5",TxtMail.Text);
            komut.Parameters.AddWithValue("@P6",Cmbil.Text);
            komut.Parameters.AddWithValue("@P7",Cmbilce.Text);
            komut.Parameters.AddWithValue("@P8",TxtGörev.Text);
            komut.Parameters.AddWithValue("@P9",RchAdres.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni Personel Eklenmiştir.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PersonelListesi();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtid.Text = dr["ID"].ToString();
            TxtAd.Text = dr["AD"].ToString();
            TxtGörev.Text = dr["GOREV"].ToString();
            TxtMail.Text = dr["MAIL"].ToString();
            TxtSoyad.Text = dr["SOYAD"].ToString();
            Cmbil.Text = dr["IL"].ToString();
            Cmbilce.Text = dr["ILCE"].ToString();
            MskTC.Text = dr["TC"].ToString();
            MskTel1.Text = dr["TELEFON"].ToString();
            RchAdres.Text = dr["ADRES"].ToString();
        }
    }
}
