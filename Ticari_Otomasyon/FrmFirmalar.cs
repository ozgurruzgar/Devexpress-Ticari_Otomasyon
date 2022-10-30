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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void Cmbil_Properties_SelectedIndexChanged(object sender, EventArgs e)
        { 
            // İl'e Göre İlçeleri Getirme
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE from TBL_ILCELER Where SEHIR=@P1",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1",Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void carikodAciklamalar()
        {
            //Özel Kod Açıklamalarını SQL'den Çekme
            SqlCommand komut = new SqlCommand("Select FIRMAKOD1 from TBL_KODLAR ",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                RchKod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }
         void FirmaListesi()
        {
            // Firmaları Listeleme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FIRMALAR",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void İller()
        {
            // İlleri Listeleme
            SqlCommand komut = new SqlCommand("Select SEHIR from TBL_ILLER",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            { 
                Cmbil.Properties.Items.Add(dr[0]); 
            }
            bgl.baglanti().Close();
        }
        void Temizle()
        { 
            //Toollardaki Dataları Temizleme
            Txtİd.Text = "";
            TxtAd.Text = "";
            TxtSektör.Text = "";
            TxtYetkili.Text = "";
            TxtYGörev.Text = "";
            MskTC.Text = "";
            MskTel1.Text = "";
            MskTel2.Text = "";
            MskTel3.Text = "";
            MskFax.Text = "";
            TxtMail.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            TxtVDaire.Text = "";
            RchAdres.Text = "";
            TxtÖKod1.Text = "";
            TxtÖKod2.Text = "";
            TxtÖKod3.Text = "";
        }
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            FirmaListesi();
            İller(); 
            Temizle();
            carikodAciklamalar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //GridViewdaki Dataları Toollara Aktarma
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtİd.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSektör.Text = dr["SEKTOR"].ToString();
                TxtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                TxtYGörev.Text = dr["YETKILISTATU"].ToString();
                MskTC.Text = dr["YETKILITC"].ToString();
                MskTel1.Text = dr["TELEFON1"].ToString();
                MskTel2.Text = dr["TELEFON2"].ToString();
                MskTel3.Text = dr["TELEFON3"].ToString();
                MskFax.Text = dr["FAX"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                TxtVDaire.Text = dr["VERGIDAIRE"].ToString();
                RchAdres.Text = dr["ADRES"].ToString();
                TxtÖKod1.Text = dr["OZELKOD1"].ToString();
                TxtÖKod2.Text = dr["OZELKOD2"].ToString();
                TxtÖKod3.Text = dr["OZELKOD3"].ToString();
            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        { 
            //Firma Ekleme
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,YETKILITC,SEKTOR,OZELKOD1,OZELKOD2,OZELKOD3) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P15,@P16,@P17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1",TxtAd.Text);
            komut.Parameters.AddWithValue("@P2",TxtYGörev.Text);
            komut.Parameters.AddWithValue("@P3",TxtYetkili.Text);
            komut.Parameters.AddWithValue("@P4",MskTel1.Text);
            komut.Parameters.AddWithValue("@P5",MskTel2.Text);
            komut.Parameters.AddWithValue("@P6",MskTel3.Text);
            komut.Parameters.AddWithValue("@P7",TxtMail.Text);
            komut.Parameters.AddWithValue("@P8",MskFax.Text);
            komut.Parameters.AddWithValue("@P9",Cmbil.Text);
            komut.Parameters.AddWithValue("@P10",Cmbilce.Text);
            komut.Parameters.AddWithValue("@P11",TxtVDaire.Text);
            komut.Parameters.AddWithValue("@P12",RchAdres.Text);
            komut.Parameters.AddWithValue("@P13",MskTC.Text);
            komut.Parameters.AddWithValue("@P14",TxtSektör.Text);
            komut.Parameters.AddWithValue("@P15",TxtÖKod1.Text);
            komut.Parameters.AddWithValue("@P16",TxtÖKod2.Text);
            komut.Parameters.AddWithValue("@P17",TxtÖKod3.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Eklendi!!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            FirmaListesi();
            Temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        { 
            //Firma Silme 
            DialogResult sor = MessageBox.Show("Bu Firma Bilgilerini Sistemden Silmek İstediğine Emin Misin?","Uyarı",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if(sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete from TBL_FIRMALAR where ID=@P1",bgl.baglanti());
                komut.Parameters.AddWithValue("@P1",Txtİd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Firma Bilgileri Sistemden Silindi!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                FirmaListesi();
                Temizle();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            //Firma Datalarını Update Etme
            DialogResult sor = MessageBox.Show("Bu Firma Bilgilerini Güncellemek İstediğine Emin Misin?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Update TBL_FIRMALAR set AD=@P1,YETKILISTATU=@P2,YETKILIADSOYAD=@P3,TELEFON1=@P4,TELEFON2=@P5,TELEFON3=@P6,MAIL=@P7,FAX=@P8,IL=@P9,ILCE=@P10,VERGIDAIRE=@P11,ADRES=@P12,YETKILITC=@P13,SEKTOR=@P14,OZELKOD1=@P15,OZELKOD2=@P16,OZELKOD3=@P17 Where ID=@P18",bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", TxtAd.Text);
                komut.Parameters.AddWithValue("@P2", TxtYGörev.Text);
                komut.Parameters.AddWithValue("@P3", TxtYetkili.Text);
                komut.Parameters.AddWithValue("@P4", MskTel1.Text);
                komut.Parameters.AddWithValue("@P5", MskTel2.Text);
                komut.Parameters.AddWithValue("@P6", MskTel3.Text);
                komut.Parameters.AddWithValue("@P7", TxtMail.Text);
                komut.Parameters.AddWithValue("@P8", MskFax.Text);
                komut.Parameters.AddWithValue("@P9", Cmbil.Text);
                komut.Parameters.AddWithValue("@P10", Cmbilce.Text);
                komut.Parameters.AddWithValue("@P11", TxtVDaire.Text);
                komut.Parameters.AddWithValue("@P12", RchAdres.Text);
                komut.Parameters.AddWithValue("@P13", MskTC.Text);
                komut.Parameters.AddWithValue("@P14", TxtSektör.Text);
                komut.Parameters.AddWithValue("@P15", TxtÖKod1.Text);
                komut.Parameters.AddWithValue("@P16", TxtÖKod2.Text);
                komut.Parameters.AddWithValue("@P17", TxtÖKod3.Text);
                komut.Parameters.AddWithValue("@P18", Txtİd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Firma Bilgileri Güncellendi!!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FirmaListesi();
                Temizle();
            }
        }
    }
}
