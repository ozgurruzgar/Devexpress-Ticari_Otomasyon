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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURABILGI",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Temizle()
        {
            TxtSeri.Text = "";
            TxtSirano.Text = "";
            MskSaat.Text = "";
            MskTarih.Text = "";
            TxtVDaire.Text = "";
            TxtAlici.Text = "";
            CmbTeden.Text = "";
            TxtTalan.Text = "";
            TxtFaturaİd.Text = "";
            TxtUrunİd.Text = "";
            TxturunAd.Text = "";
            TxtMiktar.Text = "";
            TxtTutar.Text = "";
            TxtFiyat.Text = "";
        }

        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            Temizle();
            Listele();
            PersonelListesi();

            //Look Up'a Personelleri Adlarıyla Listelettirme
            SqlDataAdapter da = new SqlDataAdapter("Select ID,(AD+' '+SOYAD) AS ADSOYAD From TBL_PERSONELLER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "ADSOYAD";
            lookUpEdit1.Properties.DataSource = dt;

            //Look Up'a Firmaları Adlarıyla Listelettirme
            SqlDataAdapter da2 = new SqlDataAdapter("Select ID,AD From TBL_FIRMALAR", bgl.baglanti());
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            LookUpFirma.Properties.ValueMember = "ID";
            LookUpFirma.Properties.DisplayMember = "AD";
            LookUpFirma.Properties.DataSource = dt2;
        }
        void PersonelListesi()
        {
            SqlCommand komut = new SqlCommand("Execute Yetkililer", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbTeden.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //Cari Tür Firma
            if(TxtFaturaİd.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) Values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)",bgl.baglanti());
                komut.Parameters.AddWithValue("@P1",TxtSeri.Text);
                komut.Parameters.AddWithValue("@P2",TxtSirano.Text);
                komut.Parameters.AddWithValue("@P3",MskTarih.Text);
                komut.Parameters.AddWithValue("@P4",MskSaat.Text);
                komut.Parameters.AddWithValue("@P5",TxtVDaire.Text);
                komut.Parameters.AddWithValue("@P6",TxtAlici.Text);
                komut.Parameters.AddWithValue("@P7",CmbTeden.Text);
                komut.Parameters.AddWithValue("@P8",TxtTalan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Sisteme Eklendi!!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
            if(TxtFaturaİd.Text != ""&&CmbCariTur.Text=="FİRMA")
            {
                double miktar, fiyat, tutar;
                fiyat = Convert.ToDouble(TxtFiyat.Text);
                miktar = Convert.ToDouble(TxtMiktar.Text);
                tutar = miktar * fiyat;
                TxtTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) Values (@P1,@P2,@P3,@P4,@P5)",bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1", TxturunAd.Text);
                komut2.Parameters.AddWithValue("@P2", TxtMiktar.Text);
                komut2.Parameters.AddWithValue("@P3", decimal.Parse(TxtFiyat.Text));
                komut2.Parameters.AddWithValue("@P4", decimal.Parse(TxtTutar.Text));
                komut2.Parameters.AddWithValue("@P5", TxtFaturaİd.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();


                SaveLookUp();
                SaveLookUpFirma();
                //Hareketler Tablosuna Veri Çekme
                SqlCommand komut = new SqlCommand("insert into TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",bgl.baglanti());
                komut.Parameters.AddWithValue("@p1",TxtUrunİd.Text);
                komut.Parameters.AddWithValue("@p2",TxtMiktar.Text);
                komut.Parameters.AddWithValue("@p3",lookUpEdit1.Text);
                komut.Parameters.AddWithValue("@p4",LookUpFirma.Text);
                komut.Parameters.AddWithValue("@p5",decimal.Parse(TxtFiyat.Text));
                komut.Parameters.AddWithValue("@p6",decimal.Parse(TxtTutar.Text));
                komut.Parameters.AddWithValue("@p7",TxtFaturaİd.Text);
                komut.Parameters.AddWithValue("@p8",MskTarih.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok Sayısını Azaltma
                SqlCommand kmt = new SqlCommand("Update TBL_URUNLER Set ADET=ADET-@P1 Where ID=@P2",bgl.baglanti());
                kmt.Parameters.AddWithValue("@P1",TxtMiktar.Text);
                kmt.Parameters.AddWithValue("@P2",TxtUrunİd.Text);
                kmt.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya Ait Ürün Sisteme Eklendi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
                }

            //Cari Tür Müşteri
            if (TxtFaturaİd.Text != "" && CmbCariTur.Text == "MÜŞTERİ")
            {
                double miktar, fiyat, tutar;
                fiyat = Convert.ToDouble(TxtFiyat.Text);
                miktar = Convert.ToDouble(TxtMiktar.Text);
                tutar = miktar * fiyat;
                TxtTutar.Text = tutar.ToString();
                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) Values (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@P1", TxturunAd.Text);
                komut2.Parameters.AddWithValue("@P2", TxtMiktar.Text);
                komut2.Parameters.AddWithValue("@P3", decimal.Parse(TxtFiyat.Text));
                komut2.Parameters.AddWithValue("@P4", decimal.Parse(TxtTutar.Text));
                komut2.Parameters.AddWithValue("@P5", TxtFaturaİd.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();


                SaveLookUp();
                SaveLookUpFirma();
                //Hareketler Tablosuna Veri Çekme
                SqlCommand komut = new SqlCommand("insert into TBL_MUSTERIHAREKETLER (URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtUrunİd.Text);
                komut.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut.Parameters.AddWithValue("@p3", lookUpEdit1.Text);
                komut.Parameters.AddWithValue("@p4", LookUpFirma.Text);
                komut.Parameters.AddWithValue("@p5", decimal.Parse(TxtFiyat.Text));
                komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtTutar.Text));
                komut.Parameters.AddWithValue("@p7", TxtFaturaİd.Text);
                komut.Parameters.AddWithValue("@p8", MskTarih.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok Sayısını Azaltma
                SqlCommand kmt = new SqlCommand("Update TBL_URUNLER Set ADET=ADET-@P1 Where ID=@P2", bgl.baglanti());
                kmt.Parameters.AddWithValue("@P1", TxtMiktar.Text);
                kmt.Parameters.AddWithValue("@P2", TxtUrunİd.Text);
                kmt.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya Ait Ürün Sisteme Eklendi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!=null)
            {
                Txtİd.Text = dr["FATURABILGID"].ToString();
                TxtSeri.Text = dr["SERI"].ToString();
                TxtSirano.Text = dr["SIRANO"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                TxtVDaire.Text = dr["VERGIDAIRE"].ToString();
                TxtAlici.Text = dr["ALICI"].ToString();
                CmbTeden.Text = dr["TESLIMEDEN"].ToString();
                TxtTalan.Text = dr["TESLIMALAN"].ToString();
            }
        }


        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Bu Fatura Bilgilerini Silmek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                SqlCommand Komut = new SqlCommand("Delete from TBL_FATURABILGI where FATURABILGID=@P1", bgl.baglanti());
                Komut.Parameters.AddWithValue("@P1", Txtİd.Text);
                Komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgileri Silindidi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Bu Fatura Bilgilerini Güncellemek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Update TBL_FATURABILGI set SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TESLIMALAN=@P8 Where FATURABILGID=@P9", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", TxtSeri.Text);
                komut.Parameters.AddWithValue("@P2", TxtSirano.Text);
                komut.Parameters.AddWithValue("@P3", MskTarih.Text);
                komut.Parameters.AddWithValue("@P4", MskSaat.Text);
                komut.Parameters.AddWithValue("@P5", TxtVDaire.Text);
                komut.Parameters.AddWithValue("@P6", TxtAlici.Text);
                komut.Parameters.AddWithValue("@P7", CmbTeden.Text);
                komut.Parameters.AddWithValue("@P8", TxtTalan.Text);
                komut.Parameters.AddWithValue("@P9", Txtİd.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgisi Güncellendi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
                Temizle();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.id = dr["FATURABILGID"].ToString();
                fr.Show();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select URUNAD,SATISFIYAT From TBL_URUNLER Where ID=@P1",bgl.baglanti());
            komut.Parameters.AddWithValue("@P1",TxtUrunİd.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                TxturunAd.Text = dr[0].ToString();
                TxtFiyat.Text = dr[1].ToString();
            }
        }

        void SaveLookUp()
        {
            //Look Up'a Personelleri Adlarıyla Listelettirme
            SqlDataAdapter da = new SqlDataAdapter("Select ID,(AD+' '+SOYAD) AS ADSOYAD From TBL_PERSONELLER", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ADSOYAD";
            lookUpEdit1.Properties.DisplayMember = "ID";
            lookUpEdit1.Properties.DataSource = dt;
        }      
        void SaveLookUpFirma()
        {
            //Look Up'a Personelleri Adlarıyla Listelettirme
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD From TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            LookUpFirma.Properties.ValueMember = "AD";
            LookUpFirma.Properties.DisplayMember = "ID";
            LookUpFirma.Properties.DataSource = dt;
        }
    }
}
