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
    public partial class FrmRehber : Form
    {
        public FrmRehber()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmRehbercs_Load(object sender, EventArgs e)
        {
            //Müşterileri Grid'e Listeleme
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAIL From TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Firmaları Grid'e Listeleme
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select AD,YETKILIADSOYAD,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX From TBL_FIRMALAR", bgl.baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //Gridde 2 kere tıklayınça Müşteriye Mail Gönderme Sayfası Açma
            FrmMail fr = new FrmMail();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (fr != null | fr.IsDisposed)
            {
                fr.mail = dr["MAIL"].ToString();
            }
            fr.Show();

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            //Gridde 2 kere tıklayınça Müşteriye Mail Gönderme Sayfası Açma
            FrmMail fr2 = new FrmMail();
            DataRow dr2 = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (fr2 != null | fr2.IsDisposed)
            {
                fr2.mail = dr2["MAIL"].ToString();
            }
            fr2.Show();
        }
    }
}