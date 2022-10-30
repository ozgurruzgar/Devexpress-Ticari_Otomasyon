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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void BankaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute BankaBilgileri", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void İller()
        {
            SqlCommand komut = new SqlCommand("Select SEHIR From TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        void FirmaListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "ID";
            lookUpEdit1.Properties.DisplayMember = "AD";
            lookUpEdit1.Properties.DataSource = dt;
        }
        void SaveLookUp()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            lookUpEdit1.Properties.ValueMember = "AD";
            lookUpEdit1.Properties.DisplayMember = "ID";
            lookUpEdit1.Properties.DataSource = dt;
        }
        private void Cmbil_Properties_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("Select ILCE From TBL_ILCELER Where SEHIR=@P1", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti();
        }
        void Temizle()
        {
            Txtid.Text = "";
            TxtBankaAd.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            TxtSube.Text = "";
            Txtİban.Text = "";
            TxtHesapNo.Text = "";
            TxtYetkili.Text = "";
            MskTel.Text = "";
            MskTarih.Text = "";
            TxtHesapTuru.Text = "";
            lookUpEdit1.EditValue = "";
        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            BankaListesi();
            İller();
            Temizle();
            FirmaListesi();
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SaveLookUp();


            SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,IBAN,HESAPNO,YETKILI,TELEFON,TARIH,HESAPTURU,FIRMAID) values (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtBankaAd.Text);
            komut.Parameters.AddWithValue("@P2", Cmbil.Text);
            komut.Parameters.AddWithValue("@P3", Cmbilce.Text);
            komut.Parameters.AddWithValue("@P4", TxtSube.Text);
            komut.Parameters.AddWithValue("@P5", Txtİban.Text);
            komut.Parameters.AddWithValue("@P6", TxtHesapNo.Text);
            komut.Parameters.AddWithValue("@P7", TxtYetkili.Text);
            komut.Parameters.AddWithValue("@P8", MskTel.Text);
            komut.Parameters.AddWithValue("@P9", Convert.ToDateTime(MskTarih.Text));
            komut.Parameters.AddWithValue("@P10", TxtHesapTuru.Text);
            komut.Parameters.AddWithValue("@P11", lookUpEdit1.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            DialogResult eger = MessageBox.Show("Banka Bilgileri Sisteme Eklendi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if(eger == DialogResult.OK)
            {
                BankaListesi();
                Temizle();
                FirmaListesi();
            }
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult sor = MessageBox.Show("Bu Bankanın Bilgilerini Silmek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From TBL_BANKALAR Where ID=@P1", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Banka Bilgileri Sistemden Silindi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BankaListesi();
                Temizle();
            }
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            SaveLookUp();
            DialogResult sor = MessageBox.Show("Bu Bankanın Bilgilerini Güncellemek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (sor == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Update TBL_BANKALAR set BANKAADI=@P1,IL=@P2,ILCE=@P3,SUBE=@P4,IBAN=@P5,HESAPNO=@P6,YETKILI=@P7,TELEFON=@P8,TARIH=@P9,HESAPTURU=@P10,FIRMAID=@P11 Where ID=@P12", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", TxtBankaAd.Text);
                komut.Parameters.AddWithValue("@P2", Cmbil.Text);
                komut.Parameters.AddWithValue("@P3", Cmbilce.Text);
                komut.Parameters.AddWithValue("@P4", TxtSube.Text);
                komut.Parameters.AddWithValue("@P5", Txtİban.Text);
                komut.Parameters.AddWithValue("@P6", TxtHesapNo.Text);
                komut.Parameters.AddWithValue("@P7", TxtYetkili.Text);
                komut.Parameters.AddWithValue("@P8", MskTel.Text);
                komut.Parameters.AddWithValue("@P9", Convert.ToDateTime(MskTarih.Text));
                komut.Parameters.AddWithValue("@P10", TxtHesapTuru.Text);
                komut.Parameters.AddWithValue("@P11", lookUpEdit1.EditValue);
                komut.Parameters.AddWithValue("@P12", Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                DialogResult eger = MessageBox.Show("Banka Bilgileri Güncellendi!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(eger ==DialogResult.OK)
                {
                    BankaListesi();
                    Temizle();
                    FirmaListesi();
                }
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                TxtBankaAd.Text = dr["BANKAADI"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                TxtSube.Text = dr["SUBE"].ToString();
                Txtİban.Text = dr["IBAN"].ToString();
                TxtHesapNo.Text = dr["HESAPNO"].ToString();
                TxtYetkili.Text = dr["YETKILI"].ToString();
                MskTel.Text = dr["TELEFON"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                TxtHesapTuru.Text = dr["HESAPTURU"].ToString();
                lookUpEdit1.Text = dr["AD"].ToString();
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
